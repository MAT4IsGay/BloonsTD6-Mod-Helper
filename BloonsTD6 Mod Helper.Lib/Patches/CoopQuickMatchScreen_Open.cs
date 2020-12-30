using Assets.Scripts.Unity.UI_New.Coop;
using Harmony;

namespace BloonsTD6_Mod_Helper.Patches
{

    [HarmonyPatch(typeof(CoopQuickMatchScreen), nameof(CoopQuickMatchScreen.Open))]
    internal class CoopQuickMatchScreen_Open
    {
        internal static bool IsInPublicCoop;

        [HarmonyPostfix]
        internal static void Postfix()
        {
            IsInPublicCoop = true;
        }
    }
}
