using UnityEngine;
using UnityModManagerNet;
using System.Reflection;
using HarmonyLib;

namespace NoMosquito
{
    public class Main
    {
        public static bool enabled;
        public static UnityModManager.ModEntry mod;

        static bool Load(UnityModManager.ModEntry modEntry)
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

    [HarmonyPatch(typeof(UnityEngine.AudioSource))]
    [HarmonyPatch(nameof(UnityEngine.AudioSource.PlayOneShot))]
    static class NoMosquitoSoundPatch
    {
        static bool Prefix(ref UnityEngine.AudioClip clip, ref System.Single volume)
        {
            Debug.Log($"[NoMosquito]: Audio name: {clip.name} at volume {volume}");
            return true;
        }
    }
}
