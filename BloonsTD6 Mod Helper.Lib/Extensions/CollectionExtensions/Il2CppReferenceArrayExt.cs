using Assets.Scripts.Models.Bloons;
using Assets.Scripts.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using UnhollowerBaseLib;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class Il2CppReferenceArrayExt
    {
        /// <summary>
        /// Confirmed working
        /// </summary>
        public static List<T> ToList<T>(this Il2CppReferenceArray<T> referenceArray) where T : Il2CppSystem.Object
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
            where T : Il2CppSystem.Object
        {
            Il2CppSystem.Collections.Generic.List<T> il2CppList = new Il2CppSystem.Collections.Generic.List<T>();
            foreach (var item in referenceArray)
                il2CppList.Add(item);

            return il2CppList;
        }

        /// <summary>
        /// Not tested
        /// </summary>
        public static T[] ToArray<T>(this Il2CppReferenceArray<T> referenceArray) where T : Il2CppSystem.Object
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
        public static SizedList<T> ToSizedList<T>(this Il2CppReferenceArray<T> referenceArray) where T : Il2CppSystem.Object
        {
            SizedList<T> sizedList = new SizedList<T>();
            foreach (var item in referenceArray)
                sizedList.Add(item);

            return sizedList;
        }

        /// <summary>
        /// Not Tested
        /// </summary>
        public static LockList<T> ToLockList<T>(this Il2CppReferenceArray<T> referenceArray) where T : Il2CppSystem.Object
        {
            LockList<T> lockList = new LockList<T>();
            foreach (var item in referenceArray)
                lockList.Add(item);

            return lockList;
        }


        public static bool HasItemsOfType<TSource, TCast>(this Il2CppReferenceArray<TSource> referenceArray)
            where TSource : Il2CppSystem.Object
            where TCast : Il2CppSystem.Object
        {
            try { var result = referenceArray.First(item => item.TryCast<TCast>() != null); }
            catch (Exception) { return false; }

            return true;
        }




        public static Il2CppReferenceArray<T> Add<T>(this Il2CppReferenceArray<T> referenceArray, T objectToAdd) where T : Il2CppSystem.Object
        {
            var list = referenceArray.ToList();
            list.Add(objectToAdd);
            return list.ToIl2CppReferenceArray();
        }

        public static TCast GetItemOfType<TSource, TCast>(this Il2CppReferenceArray<TSource> referenceArray)
            where TCast : Il2CppSystem.Object
            where TSource : Il2CppSystem.Object
        {
            if (!HasItemsOfType<TSource, TCast>(referenceArray))
                return null;

            var result = referenceArray.FirstOrDefault(item => item.TryCast<TCast>() != null);
            return result.TryCast<TCast>();
        }

        public static List<TCast> GetItemsOfType<TSource, TCast>(this Il2CppReferenceArray<TSource> referenceArray)
            where TSource : Il2CppSystem.Object
            where TCast : Il2CppSystem.Object
        {
            if (!HasItemsOfType<TSource, TCast>(referenceArray))
                return null;

            var results = referenceArray.Where(item => item.TryCast<TCast>() != null);

            List<TCast> newArray = new List<TCast>();
            foreach (var item in results)
                newArray.Add(item.TryCast<TCast>());

            return newArray;
        }

        public static Il2CppReferenceArray<TSource> RemoveItemOfType<TSource, TCast>(this Il2CppReferenceArray<TSource> referenceArray)
            where TSource : Il2CppSystem.Object
            where TCast : Il2CppSystem.Object
        {
            var behavior = GetItemOfType<TSource, TCast>(referenceArray);
            return Remove(referenceArray, behavior);
        }

        public static Il2CppReferenceArray<TSource> Remove<TSource, TCast>(this Il2CppReferenceArray<TSource> referenceArray, TCast itemToRemove)
            where TSource : Il2CppSystem.Object where TCast : Il2CppSystem.Object
        {
            if (!HasItemsOfType<TSource, TCast>(referenceArray))
                return referenceArray;

            var arrayList = referenceArray.ToList();

            for (int i = 0; i < referenceArray.Count; i++)
            {
                var item = referenceArray[i];
                if (item is null || !item.Equals(itemToRemove.TryCast<TCast>()))
                    continue;

                arrayList.RemoveAt(i);
                break;
            }

            return arrayList.ToIl2CppReferenceArray();
        }


        public static Il2CppReferenceArray<TSource> RemoveItemsOfType<TSource, TCast>(this Il2CppReferenceArray<TSource> referenceArray)
            where TSource : Il2CppSystem.Object
            where TCast : Il2CppSystem.Object
        {
            if (!HasItemsOfType<TSource, TCast>(referenceArray))
                return referenceArray;

            int numRemoved = 0;
            var arrayList = referenceArray.ToList();
            for (int i = 0; i < referenceArray.Count; i++)
            {
                var item = referenceArray[i];
                if (item is null || item.TryCast<TCast>() == null)
                    continue;

                arrayList.RemoveAt(i - numRemoved);
                numRemoved++;
            }

            return arrayList.ToIl2CppReferenceArray();
        }
    }
}