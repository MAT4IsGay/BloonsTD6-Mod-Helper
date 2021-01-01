using Assets.Scripts.Utils;
using BloonsTD6_Mod_Helper.Api.Utils;
using System;
using System.Collections.Generic;
using UnhollowerBaseLib;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class ArrayExt
    {
        /// <summary>
        /// Not Tested
        /// </summary>
        public static Il2CppSystem.Collections.Generic.List<T> ToIl2CppList<T>(this T[] array) where T : Il2CppObjectBase
        {
            Il2CppSystem.Collections.Generic.List<T> il2CppList = new Il2CppSystem.Collections.Generic.List<T>();
            foreach (var item in array)
                il2CppList.Add(item);

            return il2CppList;
        }

        /// <summary>
        /// Not Tested
        /// </summary>
        public static Il2CppReferenceArray<T> ToIl2CppReferenceArray<T>(this T[] array) where T : Il2CppObjectBase
        {
            var il2cppArray = new Il2CppReferenceArray<T>(0);
            for (int i = 0; i < array.Length; i++)
                Il2CppUtils.Add(il2cppArray, array[i], out il2cppArray);

            return il2cppArray;
        }

        /// <summary>
        /// Not Tested
        /// </summary>
        public static SizedList<T> ToSizedList<T>(this T[] array)
        {
            SizedList<T> sizedList = new SizedList<T>();
            foreach (var item in array)
                sizedList.Add(item);

            return sizedList;
        }

        /// <summary>
        /// Not Tested
        /// </summary>
        public static LockList<T> ToLockList<T>(this T[] array)
        {
            LockList<T> lockList = new LockList<T>();
            foreach (var item in array)
                lockList.Add(item);

            return lockList;
        }
    }
}
