using Harmony;
using NinjaKiwi.NKMulti;
using Il2CppSystem.Collections.Generic;
using MelonLoader;

namespace BloonsTD6_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(NKMultiConnection), nameof(NKMultiConnection.Send))]
    internal class NKMultiConnection_Send
    {
        [HarmonyPostfix]
        internal static void Postfix(NKMultiConnection __instance)
        {
            
        }
    }
}