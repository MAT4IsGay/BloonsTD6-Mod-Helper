using Assets.Scripts.Unity.UI_New.Main;
using BloonsTD6_Mod_Helper.Api;
using Harmony;
using System;
using System.Collections.Generic;

namespace BloonsTD6_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(MainMenu), nameof(MainMenu.OnEnable))]
    internal class MainMenu_OnEnable
    {
        [HarmonyPostfix]
        internal static void Postfix()
        {
            ResetSessionData();
        }

        private static void ResetSessionData()
        {
            SessionData.PoppedBloons = new Dictionary<string, int>();
            SessionData.RoundSet = null;

            SessionData.IsInPublicCoop = false;
            SessionData.IsInRace = false;
            SessionData.IsInOdyssey = false;
        }
    }
}