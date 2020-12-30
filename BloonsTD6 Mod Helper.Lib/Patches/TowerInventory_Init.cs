﻿using Assets.Scripts.Models.TowerSets;
using Assets.Scripts.Simulation.Input;
using Harmony;
using Il2CppSystem.Collections.Generic;

namespace BloonsTD6_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(TowerInventory), nameof(TowerInventory.Init))]
    internal class TowerInventory_Init
    {
        internal static List<TowerDetailsModel> allTowers = new List<TowerDetailsModel>();
        internal static TowerInventory towerInventory;

        [HarmonyPrefix]
        internal static bool Prefix(TowerInventory __instance, ref List<TowerDetailsModel> allTowersInTheGame)
        {
            towerInventory = __instance;
            allTowers = allTowersInTheGame;
            return true;
        }
    }
}
