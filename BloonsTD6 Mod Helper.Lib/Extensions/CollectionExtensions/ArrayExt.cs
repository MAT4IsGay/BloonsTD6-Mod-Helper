using Assets.Scripts.Utils;
using BloonsTD6_Mod_Helper.Api.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using UnhollowerBaseLib;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class ArrayExt
    {
        /// <summary>
        /// Not Tested
        /// </summary>
        public static Il2CppSystem.Collections.Generic.List<T> ToIl2CppList<T>(this T[] array) where T : Il2CppSystem.Object
        {
            Il2CppSystem.Collections.Generic.List<T> il2CppList = new Il2CppSystem.Collections.Generic.List<T>();
            foreach (var item in array)
                il2CppList.Add(item);

            return il2CppList;
        }

        /// <summary>
        /// Not Tested
        /// </summary>
        public static Il2CppReferenceArray<T> ToIl2CppReferenceArray<T>(this T[] array) where T : Il2CppSystem.Object
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



        public static bool HasItemsOfType<TSource, TCast>(this TSource[] array) where TSource : Il2CppSystem.Object
            where TCast : Il2CppSystem.Object
        {
            for (int i = 0; i < array.Length; i++)
            {
                var item = array[i];
                try
                {
                    if (item.TryCast<TCast>() != null)
                        return true;
                }
                catch (Exception) { }
            }

            return false;
        }


        public static T[] Add<T> (this T[] array, T objectToAdd) where T : Il2CppSystem.Object
        {
            var list = array.ToList();
            list.Add(objectToAdd);
            return list.ToArray();
        }

        public static TCast GetItemOfType<TSource, TCast>(this TSource[] array) where TCast : Il2CppSystem.Object
            where TSource : Il2CppSystem.Object
        {
            if (!HasItemsOfType<TSource, TCast>(array))
                return null;

            var result = array.FirstOrDefault(item => item.TryCast<TCast>() != null);
            return result.TryCast<TCast>();
        }

        public static List<TCast> GetItemsOfType<TSource, TCast>(this TSource[] array)
            where TSource : Il2CppSystem.Object where TCast : Il2CppSystem.Object
        {
            if (!HasItemsOfType<TSource, TCast>(array))
                return null;

            List<TCast> list = new List<TCast>();
            for (int i = 0; i < array.Length; i++)
            {
                var item = array[i];
                try
                {
                    var tryCast = item.TryCast<TCast>();
                    if (tryCast != null)
                        list.Add(tryCast);
                }
                catch (Exception) { }
            }

            return list;
        }

        public static TSource[] RemoveItemOfType<TSource, TCast>(this TSource[] array)
            where TSource : Il2CppSystem.Object
            where TCast : Il2CppSystem.Object
        {
            var behavior = GetItemOfType<TSource, TCast>(array);
            return RemoveItem(array, behavior);
        }


        public static TSource[] RemoveItem<TSource, TCast>(this TSource[] array, TCast itemToRemove) 
            where TSource : Il2CppSystem.Object where TCast : Il2CppSystem.Object
        {
            if (!HasItemsOfType<TSource, TCast>(array))
                return array;

            var arrayList = array.ToList();

            for (int i = 0; i < array.Length; i++)
            {
                var item = array[i];
                if (item is null || !item.Equals(itemToRemove.TryCast<TCast>()))
                    continue;

                arrayList.RemoveAt(i);
                break;
            }

            return arrayList.ToArray();
        }


        public static TSource[] RemoveItemsOfType<TSource, TCast>(this TSource[] array) where TSource : Il2CppSystem.Object
            where TCast : Il2CppSystem.Object
        {
            if (!HasItemsOfType<TSource, TCast>(array))
                return array;

            int numRemoved = 0;
            var arrayList = array.ToList();
            for (int i = 0; i < array.Length; i++)
            {
                var item = array[i];
                if (item is null || item.TryCast<TCast>() == null)
                    continue;

                arrayList.RemoveAt(i - numRemoved);
                numRemoved++;
            }

            return arrayList.ToArray();
        }
    }
}
