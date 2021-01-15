using Assets.Scripts.Models;
using Assets.Scripts.Models.Rounds;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.InGame;
using BloonsTD6_Mod_Helper.Api;
using Harmony;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloonsTD6_Mod_Helper.Extensions;
using Assets.Scripts.Models.SimulationBehaviors;
using Assets.Scripts.Simulation.SimulationBehaviors;

namespace BloonsTD6_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(GameModel), nameof(GameModel.GetRoundSet))]
    internal class GameModel_GetRoundSet
    {
        [HarmonyPostfix]
        internal static void Postfix(ref RoundSetModel __result)
        {
            if (SessionData.RoundSet != null)
                __result = SessionData.RoundSet;
        }
    }
}