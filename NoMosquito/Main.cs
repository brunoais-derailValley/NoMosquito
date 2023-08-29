using UnityEngine;
using System.Reflection;
using System;
using UnityModManagerNet;
using HarmonyLib;
using System.Text.RegularExpressions;

namespace NoMosquito
{
    public class Main
    {
        public static bool enabled;
        public static int disableCount = 0;
        public static UnityModManager.ModEntry mod;

        public static Regex beeMatch;

        static Main(){
            beeMatch = new Regex(@"Env-Insect-(?:Bee|Mosquito)[0-9]{1,2}", RegexOptions.Compiled);
        }

        public static bool Load(UnityModManager.ModEntry modEntry)
        {
            var harmony = new Harmony(modEntry.Info.Id);
            harmony.PatchAll(Assembly.GetExecutingAssembly());

            mod = modEntry;
            modEntry.OnToggle = OnToggle;

            return true;
        }

        static bool OnToggle(UnityModManager.ModEntry modEntry, bool value)
        {
            enabled = value;
            modEntry.Logger.Log(Application.loadedLevelName);

            return true;
        }
    }

    [HarmonyPatch(typeof(UnityEngine.AudioSource), nameof(UnityEngine.AudioSource.PlayOneShot), new[]{typeof(UnityEngine.AudioClip), typeof(System.Single)})]
    static class NoMosquitoSoundPatch
    {
        static bool Prefix(ref UnityEngine.AudioClip clip, ref System.Single volumeScale)
        {
            if(!Main.enabled){
                if(Main.disableCount == 0){
                    Debug.Log("[NoMosquito] disabled");
                }
                Main.disableCount = Main.disableCount + 1 % 100;
                return true;
            }

            var averted = "";
            if(Main.beeMatch.IsMatch(clip.name)){
                averted = " averted";
                Debug.Log($"[NoMosquito]{averted}: Audio name: {clip.name} at volume {volumeScale}");
            }

            return averted == "";
        }
    }
}
