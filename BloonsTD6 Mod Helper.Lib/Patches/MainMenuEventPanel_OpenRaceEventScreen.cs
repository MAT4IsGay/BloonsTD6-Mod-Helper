using Assets.Scripts.Unity.UI_New.Main.EventPanel;
using BloonsTD6_Mod_Helper.Api;
using Harmony;

namespace BloonsTD6_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(MainMenuEventPanel), nameof(MainMenuEventPanel.OpenRaceEventScreen))]
    internal class MainMenuEventPanel_OpenRaceEventScreen
    {
        [HarmonyPostfix]
        internal static void Postfix()
        {
            SessionData.IsInRace = true;
        }
    }
}
