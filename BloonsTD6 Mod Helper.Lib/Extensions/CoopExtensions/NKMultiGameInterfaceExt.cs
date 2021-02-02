using Assets.Scripts.Unity;
using BloonsTD6_Mod_Helper.Api.Coop;
using NinjaKiwi.NKMulti;
using UnhollowerBaseLib;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class NKMultiGameInterfaceExt
    {

        public static void SendMessage(this NKMultiGameInterface nkGI, Message message)
        {
            Game.instance.nkGI.relayConnection.Writer.Write(message);
        }

        public static void SendMessage<T>(this NKMultiGameInterface nkGI, T objectToSend, byte? peerId = null, string code = "") where T : Il2CppSystem.Object
        {
            Message message = MessageUtils.CreateMessage(objectToSend, code);

            if (peerId.HasValue && peerId != null)
                nkGI.SendToPeer(peerId.Value, message);
            else
                nkGI.relayConnection.Writer.Write(message);
        }

        public static void SendMessage(this NKMultiGameInterface nkGI, Il2CppSystem.String objectToSend, byte? peerId = null, string code = "")
        {
            Message message = MessageUtils.CreateMessage(objectToSend, code);
            if (peerId.HasValue && peerId != null)
                nkGI.SendToPeer(peerId.Value, message);
            else
                nkGI.relayConnection.Writer.Write(message);
        }

        public static T ReadMessage<T>(this NKMultiGameInterface nkGI, Il2CppStructArray<byte> messageBytes)
        {
            return MessageUtils.ReadMessage<T>(messageBytes);
        }

        public static Chat_Message ReadChatMessage(this NKMultiGameInterface nkGI, Message message)
        {
            if (message.Code != Chat_Message.chatCoopCode)
                return null;
            string json = Game.instance.nkGI.ReadMessage<string>(message.bytes);
            Chat_Message deserialized = Game.instance.GetJsonSerializer().DeserializeJson<Chat_Message>(json);
            return deserialized;
        }
    }
}