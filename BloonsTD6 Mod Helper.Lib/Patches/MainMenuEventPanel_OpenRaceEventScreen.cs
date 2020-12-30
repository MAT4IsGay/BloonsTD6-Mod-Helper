using Assets.Scripts.Unity.UI_New.Main.EventPanel;
using Harmony;

namespace BloonsTD6_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(MainMenuEventPanel), nameof(MainMenuEventPanel.OpenRaceEventScreen))]
    internal class MainMenuEventPanel_OpenRaceEventScreen
    {
        internal static bool IsInRace;

        [HarmonyPostfix]
        internal static void Postfix()
        {
            IsInRace = true;
        }
    }
}
