using Assets.Scripts.Unity.UI_New.Odyssey;
using Harmony;

namespace BloonsTD6_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(OdysseyEventScreen), nameof(OdysseyEventScreen.Update))]
    internal class OdysseyEventScreen_Update
    {
        internal static bool IsInOdyssey;

        [HarmonyPostfix]
        internal static void Postfix()
        {
            // Setting only if false because this method is called constantly when screen is open
            if (!IsInOdyssey)
            {
                IsInOdyssey = true;
            }
        }
    }
}
