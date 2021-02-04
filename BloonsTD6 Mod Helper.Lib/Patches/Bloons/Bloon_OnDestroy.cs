using System;
using Assets.Scripts.Simulation.Bloons;
using Assets.Scripts.Simulation.Towers;
using Assets.Scripts.Simulation.Towers.Projectiles;
using BloonsTD6_Mod_Helper.Api;
using Harmony;
using UnhollowerBaseLib;

namespace BloonsTD6_Mod_Helper.Patches.Bloons
{
    [HarmonyPatch(typeof(Bloon), nameof(Bloon.OnDestroy))]
    internal class Bloon_OnDestroy
    {
        [HarmonyPostfix]
        internal static void Postfix(Bloon __instance)
        {
            MelonMain.DoPatchMethods(mod => { mod.OnBloonDestroy(__instance); });
        }
    }
}