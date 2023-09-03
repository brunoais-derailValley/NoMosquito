using UnityEngine;
using System.Reflection;
using System;
using UnityModManagerNet;
using HarmonyLib;
using System.Text.RegularExpressions;

namespace NoMosquito
{
#if DEBUG || RELOAD
    [EnableReloading]
#endif
    public class Main
    {
        public static bool enabled;
        public static int disableCount = 0;
        public static UnityModManager.ModEntry mod;

        public static Regex beeMatch;

        private static Harmony harmony;

        static Main(){
            beeMatch = new Regex(@"Env-Insect-(?:Bee|Mosquito)[0-9]{1,2}", RegexOptions.Compiled);
        }

        public static bool Load(UnityModManager.ModEntry modEntry)
        {
            harmony = new Harmony(modEntry.Info.Id);
            harmony.PatchAll(Assembly.GetExecutingAssembly());

            mod = modEntry;
            modEntry.OnToggle = OnToggle;
    #if DEBUG || RELOAD
            modEntry.OnUnload = Unload;
    #endif

            return true;
        }

        static bool OnToggle(UnityModManager.ModEntry modEntry, bool value)
        {
            enabled = value;
            modEntry.Logger.Log(Application.loadedLevelName);

            return true;
        }
    #if DEBUG || RELOAD
        static bool Unload(UnityModManager.ModEntry modEntry)
        {
            harmony.UnpatchAll();

            return true;
        }
    #endif
    }

    [HarmonyPatch(typeof(UnityEngine.AudioSource), nameof(UnityEngine.AudioSource.PlayOneShot), new[]{typeof(UnityEngine.AudioClip), typeof(System.Single)})]
    static class NoMosquitoSoundPatch
    {
        static bool Prefix(ref UnityEngine.AudioClip clip, ref System.Single volumeScale)
        {
            if(!Main.enabled){
        #if DEBUG
                if(Main.disableCount == 0){
                    Debug.Log("[NoMosquito] disabled");
                }
                Main.disableCount = Main.disableCount + 1 % 100;
        #endif
                return true;
            }

            var averted = "";
            if(Main.beeMatch.IsMatch(clip.name)){
                averted = " averted";
            }
        #if DEBUG
            Debug.Log($"[NoMosquito]{averted}: Audio name: {clip.name} at volume {volumeScale}");
        #endif

            return averted == "";
        }
    }
}
