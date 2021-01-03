using MelonLoader;
using NinjaKiwi.NKMulti;
using UnhollowerBaseLib;
using UnhollowerRuntimeLib;
using BloonsTD6_Mod_Helper.Extensions;
using Newtonsoft.Json;

namespace BloonsTD6_Mod_Helper.Api.Coop
{
    public class MessageUtils
    {
        /* public static Message CreateMessage(string objectToSend, string code = "")
         {
             var serialize = SerialisationUtil.Serialise(objectToSend);
             code = (string.IsNullOrEmpty(code)) ? MelonMain.coopMessageCode : code;

             return new Message(code, serialize);
         }*/

        /*public static Message CreateMessage(ModMessage objectToSend, string code = "")
        {
            var serialize = SerialisationUtil.Serialise(objectToSend);
            code = (string.IsNullOrEmpty(code)) ? MelonMain.coopMessageCode : code;

            return new Message(code, serialize);
        }*/



        /*public static Message CreateMessage(string objectToSend, string code = "")
        {
            var modMessage = CreateModMessage<Il2CppSystem.String>(objectToSend);
            var serialize = SerialisationUtil.Serialise(modMessage);

            code = (string.IsNullOrEmpty(code)) ? MelonMain.coopMessageCode : code;

            return new Message(code, serialize);
        }*/

        /*private static ModMessage CreateModMessage(string message)
        {
            var serialize = SerialisationUtil.Serialise(message);
            ModMessage modMessage = new ModMessage(serialize);

            return modMessage;
        }*/

        public static Message CreateMessage<T>(T objectToSend, string code = "") where T : Il2CppSystem.Object
        {
            //var modMessage = CreateModMessage(objectToSend);
            var serialize = SerialisationUtil.Serialise(objectToSend);

            code = (string.IsNullOrEmpty(code)) ? MelonMain.coopMessageCode : code;
            return new Message(code, serialize);
        }
        

        private static ModMessage CreateModMessage<T> (T objectToSend) where T : Il2CppSystem.Object
        {
            var serialize = SerialisationUtil.Serialise(objectToSend);

            /*System.Type type = null;
            try { type = typeof(T); }
            catch (System.Exception) { }

            Il2CppSystem.Type il2cppType = null;
            try { il2cppType = Il2CppType.Of<T>(); }
            catch (System.Exception) { }*/


            //ModMessage modMessage = new ModMessage(serialize, type, il2cppType);
            //ModMessage modMessage = new ModMessage(serialize);
            ModMessage modMessage = new ModMessage();
            return modMessage;
        }




        public static T ReadMessage<T>(Il2CppStructArray<byte> serializedMessage) where T : Il2CppSystem.Object
        {
            var deserialize = SerialisationUtil.Deserialise<T>(serializedMessage);
            return deserialize;
        }
    }
}