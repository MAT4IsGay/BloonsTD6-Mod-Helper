using BloonsTD6_Mod_Helper.Api.Utils;
using System;
using System.Collections.Generic;
using UnhollowerBaseLib;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class ArrayExt
    {
        /// <summary>
        /// Theres a decent chance this doesn't work. Need to test
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static Il2CppReferenceArray<T> ToIl2CppReferenceArray<T>(this Array list) where T : Il2CppObjectBase
        {
            var il2cppArray = new Il2CppReferenceArray<T>(0);
            foreach (var item in list)
                Il2CppUtils.Add(ref il2cppArray, item as T); // using keyword "as" to cast might not work for il2cpp types

            return il2cppArray;
        }
    }
}
