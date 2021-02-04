﻿using Assets.Scripts.Models;
using Assets.Scripts.Simulation.Objects;
using Assets.Scripts.Simulation.Towers;
using Harmony;

namespace BloonsTD6_Mod_Helper.Patches.Towers
{

    [HarmonyPatch(typeof(Tower), nameof(Tower.OnSold))]
    internal class Tower_OnSold
    {
        [HarmonyPostfix]
        internal static void Postfix(Tower __instance, float amount)
        {
            MelonMain.DoPatchMethods(mod => mod.OnTowerSold(__instance, amount));
        }
    }






}