using BepInEx;
using HarmonyLib;
using System.Reflection;
using UnityEngine;

namespace LethalPaintingSync
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            // Apply another patch over LethalPaintings
            var harmony = new Harmony("LethalPaintingSync");

            harmony.PatchAll();

            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        }
    }
}