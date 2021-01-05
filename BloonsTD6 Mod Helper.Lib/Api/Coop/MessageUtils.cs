using MelonLoader;
using NinjaKiwi.NKMulti;
using UnhollowerBaseLib;

namespace BloonsTD6_Mod_Helper.Api.Coop
{
    public class MessageUtils
    {
        public static Message CreateMessage<T>(T objectToSend, string code = "") where T : Il2CppSystem.Object
        {
            var serialize = SerialisationUtil.Serialise(objectToSend);

            code = (string.IsNullOrEmpty(code)) ? MelonMain.coopMessageCode : code;
            return new Message(code, serialize);
        }

        public static T ReadMessage<T>(Il2CppStructArray<byte> serializedMessage) where T : class
        {
            var deserialize = SerialisationUtil.Deserialise<T>(serializedMessage);
            return deserialize;
        }
    }
}