using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace LethalPaintingSync
{
    [HarmonyPatch]
    internal class Patches
    {
        [HarmonyBefore("LethalPaintings")]
        [HarmonyPatch(typeof(GrabbableObject))]
        [HarmonyPatch(nameof(GrabbableObject.SetScrapValue))]
        static void SetScrapValuePatch(GrabbableObject __instance) 
        {
            // Seed the RNG with the painting's Network Object ID, thereby (hopefully) keeping the image selection synced,
            // provided that everyone has the same set of painting textures
            LethalPaintings.Plugin.Rand = new((int) __instance.NetworkObjectId);
        }
    }
}
