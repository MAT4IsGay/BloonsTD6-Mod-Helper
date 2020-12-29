using Assets.Scripts.Unity.UI_New.Main;
using Harmony;

namespace BloonsTD6_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(MainMenu), nameof(MainMenu.OnEnable))]
    internal class MainMenu_OnEnable
    {
        [HarmonyPostfix]
        internal static void Postfix()
        {
            ResetPlayerInPublic();
        }

        private static void ResetPlayerInPublic()
        {
            CoopQuickMatchScreen_Open.IsInPublicCoop = false;
            MainMenuEventPanel_OpenRaceEventScreen.IsInRace = false;
            OdysseyEventScreen_Update.IsInOdyssey = false;
        }
    }
}