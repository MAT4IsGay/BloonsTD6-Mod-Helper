using Harmony;
using Assets.Scripts.Unity.Player;

namespace BloonsTD6_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(Btd6Player), nameof(Btd6Player.GetAnalyticsInfo))]
    internal class Btd6Player_GetAnalyticsInfo
    {
        internal static Btd6Player playerModel;

        [HarmonyPostfix]
        internal static void Postfix(Btd6Player __instance)
        {
            playerModel = __instance;
        }
    }
}
