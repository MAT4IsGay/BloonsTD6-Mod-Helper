using UnhollowerBaseLib;
using NinjaKiwi.NKMulti;
using Assets.Scripts.Unity;
using Newtonsoft.Json;

namespace BloonsTD6_Mod_Helper.Api.Coop
{
    public class Chat_Message
    {
        public const string chatCoopCode = "BTD6_Chat_Msg";
        public int PeerID { get; set; }
        public string Sender { get; set; }
        public string Message { get; set; }
        public bool IsPrivateMessage { get; set; } = false;

        public Chat_Message() { }

        public Chat_Message(Il2CppStructArray<byte> messageBytes)
        {
            var json = SerialisationUtil.Deserialise<string>(messageBytes);
            var message = Read(json);
            PeerID = message.PeerID;
            Sender = message.Sender;
            Message = message.Message;
        }

        public Chat_Message Read(string json)
        {
            return JsonConvert.DeserializeObject<Chat_Message>(json);
        }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(this, Formatting.None);
        }
    }
}
