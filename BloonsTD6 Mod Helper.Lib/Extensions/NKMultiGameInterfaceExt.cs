using NinjaKiwi.NKMulti;
using Il2CppSystem.Collections.Generic;
using BloonsTD6_Mod_Helper.Api.Coop;
using MelonLoader;
using Assets.Scripts.Unity;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class NKMultiGameInterfaceExt
    {
        public static Queue<Message> GetReceiveQueue(this NKMultiGameInterface nkGI) => Patches.NKMultiConnection_Receive.ReceiveQueue;
        public static Queue<Message> GetSendQueue(this NKMultiGameInterface nkGI) => Patches.NKMultiConnection_Send.SendQueue;

        public static void SendMessage(this NKMultiGameInterface nkGI, Message message) => Game.instance.nkGI.relayConnection.Writer.Write(message);


        public static void SendMessage<T>(this NKMultiGameInterface nkGI, T objectToSend, byte? peerId = null, string code = "") where T : Il2CppSystem.Object
        {
            var message = MessageUtils.CreateMessage(objectToSend, code);
            
            if (peerId.HasValue && peerId != null)
                nkGI.SendToPeer(peerId.Value, message);
            else
                nkGI.relayConnection.Writer.Write(message);
        }

        public static void SendMessage(this NKMultiGameInterface nkGI, Il2CppSystem.String objectToSend, byte? peerId = null, string code = "")
        {
            var message = MessageUtils.CreateMessage(objectToSend, code);
            if (peerId.HasValue && peerId != null)
                nkGI.SendToPeer(peerId.Value, message);
            else
                nkGI.relayConnection.Writer.Write(message);
        }


        /*public static void SendMessage<T>(this NKMultiGameInterface nkGI, ModMessage objectToSend, byte? peerId = null, string code = "")
        {
            var message = MessageUtils.CreateMessage(objectToSend, code);

            if (peerId.HasValue)
                nkGI.SendToPeer(peerId.Value, message);
            else
                nkGI.relayConnection.Writer.Write(message);
        }*/
    }
}