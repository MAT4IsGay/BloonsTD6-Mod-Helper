using Assets.Scripts.Unity.UI_New.Main;
using BloonsTD6_Mod_Helper.Api;
using Harmony;
using System.Collections.Generic;
using Assets.Main.Scenes;

namespace BloonsTD6_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(TitleScreen), nameof(TitleScreen.Start))]
    internal class TitleScreen_Start
    {
        [HarmonyPostfix]
        internal static void Postfix()
        {
            MelonMain.DoPatchMethods(mod => mod.OnTitleScreen());
        }
    }
}