using MelonLoader;
using System;
using System.Collections.Generic;
using UnhollowerBaseLib;

namespace BloonsTD6_Mod_Helper.Api.Coop
{
    public class ModMessage : Il2CppSystem.Object
    {
        /*public Type Type { get; set; } = null;
        public Il2CppSystem.Type Il2Cpp_Type { get; set; } = null;*/

        //public Il2CppStructArray<byte> MessageBytes { get; set; }

        //public List<byte> MessageBytes { get; set; } = new List<byte>();

        public List<MelonMod> Test { get; set; } = new List<MelonMod>();
        public ModMessage()
        {

        }

        //public ModMessage(Il2CppStructArray<byte> msgBytes, Type type = null, Il2CppSystem.Type il2CppType = null)
        /*public ModMessage(Il2CppStructArray<byte> msgBytes)
        {
            *//*foreach (var b in msgBytes)
            {
                MessageBytes.Add(b);
            }*//*
            
            //MessageBytes = msgBytes;

            *//*try { this.Type = type; }
            catch (Exception) { }

            try { this.Il2Cpp_Type = il2CppType; }
            catch (Exception) { }*//*
            
        }*/
    }
}
