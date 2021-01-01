using Assets.Scripts.Utils;
using BloonsTD6_Mod_Helper.Api.Utils;
using System;
using System.Collections.Generic;
using UnhollowerBaseLib;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class SizedListExt
    {
        public static List<T> ToList<T> (this SizedList<T> sizedList)
        {
            List<T> newList = new List<T>();
            for (int i = 0; i < sizedList.count; i++)
                newList.Add(sizedList[i]);

            return newList;
        }

        public static Il2CppSystem.Collections.Generic.List<T> ToIl2CppList<T>(this SizedList<T> sizedList)
        {
            Il2CppSystem.Collections.Generic.List<T> il2CppList = new Il2CppSystem.Collections.Generic.List<T>();
            for (int i = 0; i < sizedList.count; i++)
                il2CppList.Add(sizedList[i]);

            return il2CppList;
        }

        public static T[] ToArray<T>(this SizedList<T> sizedList)
        {
            T[] newArray = new T[] { };
            for (int i = 0; i < sizedList.count; i++)
            {
                var item = sizedList[i];
                Array.Resize(ref newArray, newArray.Length + 1);
                newArray[newArray.Length - 1] = item;
            }

            return newArray;
        }        

        public static Il2CppReferenceArray<T> ToIl2CppReferenceArray<T>(this SizedList<T> sizedList) where T : Il2CppObjectBase
        {
            var il2cppArray = new Il2CppReferenceArray<T>(0);
            for (int i = 0; i < sizedList.count; i++)
                Il2CppUtils.Add(il2cppArray, sizedList[i], out il2cppArray);

            return il2cppArray;
        }

        /// <summary>
        /// Not Tested
        /// </summary>
        public static LockList<T> ToLockList<T>(this SizedList<T> sizedList)
        {
            LockList<T> lockList = new LockList<T>();
            for (int i = 0; i < sizedList.count; i++)
                lockList.Add(sizedList[i]);

            return lockList;
        }
    }
}