using Harmony;
using NinjaKiwi.NKMulti;

namespace BloonsTD6_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(NKMultiConnection), nameof(NKMultiConnection.Receive))]
    internal class NKMultiConnection_Receive
    {
        [HarmonyPostfix]
        internal static void Postfix(NKMultiConnection __instance)
        {

        }
    }
}