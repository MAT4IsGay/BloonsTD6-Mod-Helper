using Harmony;
using NinjaKiwi.NKMulti;
using Il2CppSystem.Collections.Generic;
using MelonLoader;

namespace BloonsTD6_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(NKMultiConnection), nameof(NKMultiConnection.Receive))]
    internal class NKMultiConnection_Receive
    {
        internal static Queue<Message> ReceiveQueue = new Queue<Message>();

        [HarmonyPostfix]
        internal static void Postfix(NKMultiConnection __instance)
        {
            ReceiveQueue = __instance.ReceiveQueue;
        }
    }
}