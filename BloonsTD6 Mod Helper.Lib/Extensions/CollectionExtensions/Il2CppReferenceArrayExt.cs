using Assets.Scripts.Utils;
using System;
using System.Collections.Generic;
using UnhollowerBaseLib;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class Il2CppReferenceArrayExt
    {
        /// <summary>
        /// Confirmed working
        /// </summary>
        public static List<T> ToList<T>(this Il2CppReferenceArray<T> referenceArray) where T : Il2CppObjectBase
        {
            List<T> newList = new List<T>();
            foreach (var item in referenceArray)
                newList.Add(item);

            return newList;
        }

        /// <summary>
        /// Not tested
        /// </summary>
        public static Il2CppSystem.Collections.Generic.List<T> ToIl2CppList<T>(this Il2CppReferenceArray<T> referenceArray)
            where T : Il2CppObjectBase
        {
            Il2CppSystem.Collections.Generic.List<T> il2CppList = new Il2CppSystem.Collections.Generic.List<T>();
            foreach (var item in referenceArray)
                il2CppList.Add(item);

            return il2CppList;
        }

        /// <summary>
        /// Not tested
        /// </summary>
        public static T[] ToArray<T>(this Il2CppReferenceArray<T> referenceArray) where T : Il2CppObjectBase
        {
            T[] newArray = new T[] { };
            foreach (var item in referenceArray)
            {
                Array.Resize(ref newArray, newArray.Length + 1);
                newArray[newArray.Length - 1] = item;
            }

            return newArray;
        }

        /// <summary>
        /// Not tested
        /// </summary>
        public static SizedList<T> ToSizedList<T>(this Il2CppReferenceArray<T> referenceArray) where T : Il2CppObjectBase
        {
            SizedList<T> sizedList = new SizedList<T>();
            foreach (var item in referenceArray)
                sizedList.Add(item);

            return sizedList;
        }

        /// <summary>
        /// Not Tested
        /// </summary>
        public static LockList<T> ToLockList<T>(this Il2CppReferenceArray<T> referenceArray) where T : Il2CppObjectBase
        {
            LockList<T> lockList = new LockList<T>();
            foreach (var item in referenceArray)
                lockList.Add(item);

            return lockList;
        }
    }
}