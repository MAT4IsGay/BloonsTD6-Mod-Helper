using Assets.Scripts.Models;
using Assets.Scripts.Models.Rounds;
using BloonsTD6_Mod_Helper.Api;
using Harmony;

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