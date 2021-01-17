using Assets.Scripts.Simulation.Towers;
using Harmony;

namespace BloonsTD6_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(Tower), nameof(Tower.Initialise))]
    internal class Tower_Initialise
    {
        [HarmonyPrefix]
        internal static bool Prefix(Tower __instance)
        {
            return true;
        }

        [HarmonyPostfix]
        internal static void Postfix(Tower __instance)
        {
            __instance.display = __instance.entity.displayBehaviorCache;
        }
    }
}
