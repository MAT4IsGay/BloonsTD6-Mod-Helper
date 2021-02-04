﻿using Assets.Scripts.Simulation;
using Assets.Scripts.Simulation.Towers;
using Assets.Scripts.Unity.UI_New.InGame;
using Harmony;

namespace BloonsTD6_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(InGame), nameof(InGame.StartMatch))]
    internal class InGame_StartMatch
    {
        [HarmonyPostfix]
        internal static void Postfix()
        {
            MelonMain.DoPatchMethods(mod => mod.OnMatchStarted());
        }
    }
}