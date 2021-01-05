using Assets.Scripts.Utils;
using BloonsTD6_Mod_Helper.Api.Utils;
using Il2CppSystem.Collections.Generic;
using System;
using System.Linq;
using UnhollowerBaseLib;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class Il2CppGenericsExt
    {
        /// <summary>
        /// Not tested
        /// </summary>
        public static System.Collections.Generic.List<T> ToSystemList<T>(this List<T> il2CppList)
        {
            System.Collections.Generic.List<T> newList = new System.Collections.Generic.List<T>();
            foreach (var item in il2CppList)
                newList.Add(item);

            return newList;
        }

        /// <summary>
        /// Not tested
        /// </summary>
        public static T[] ToArray<T>(this List<T> il2CppList)
        {
            T[] newArray = new T[] { };

            foreach (var item in il2CppList)
            {
                Array.Resize(ref newArray, newArray.Length + 1);
                newArray[newArray.Length - 1] = item;
            }

            return newArray;
        }

        /// <summary>
        /// Not tested
        /// </summary>
        public static SizedList<T> ToSizedList<T>(this List<T> il2CppList)
        {
            SizedList<T> sizedList = new SizedList<T>();
            foreach (var item in il2CppList)
                sizedList.Add(item);

            return sizedList;
        }

        public static Il2CppReferenceArray<T> ToIl2CppReferenceArray<T>(this List<T> il2CppList) where T : Il2CppObjectBase
        {
            var il2cppArray = new Il2CppReferenceArray<T>(0);
            for (int i = 0; i < il2CppList.Count; i++)
                Il2CppUtils.Add(il2cppArray, il2CppList[i], out il2cppArray);

            return il2cppArray;
        }

        /// <summary>
        /// Not Tested
        /// </summary>
        public static LockList<T> ToLockList<T>(this List<T> il2CppList)
        {
            LockList<T> lockList = new LockList<T>();
            foreach (var item in il2CppList)
                lockList.Add(item);

            return lockList;
        }






        public static bool HasItemsOfType<TSource, TCast>(this List<TSource> list) where TSource : Il2CppSystem.Object
            where TCast : Il2CppSystem.Object
        {
            for (int i = 0; i < list.Count; i++)
            {
                var item = list[i];
                try
                {
                    if (item.TryCast<TCast>() != null)
                        return true;
                }
                catch (Exception) { }
            }

            return false;
        }


        public static List<T> Add<T>(this List<T> list, T objectToAdd) where T : Il2CppSystem.Object
        {
            list.Add(objectToAdd);
            return list;
        }

        public static TCast GetItemOfType<TSource, TCast>(this List<TSource> list) where TCast : Il2CppSystem.Object
            where TSource : Il2CppSystem.Object
        {
            if (!HasItemsOfType<TSource, TCast>(list))
                return null;

            for (int i = 0; i < list.Count; i++)
            {
                var item = list[i];
                try
                {
                    if (item.TryCast<TCast>() != null)
                        return item.TryCast<TCast>();
                }
                catch (Exception) { }
            }

            return null;
        }

        public static List<TCast> GetItemsOfType<TSource, TCast>(this List<TSource> list) where TSource : Il2CppSystem.Object
            where TCast : Il2CppSystem.Object
        {
            if (!HasItemsOfType<TSource, TCast>(list))
                return null;

            List<TCast> results = new List<TCast>();
            for (int i = 0; i < list.Count; i++)
            {
                var item = list[i];
                try
                {
                    var tryCast = item.TryCast<TCast>();
                    if (tryCast != null)
                        results.Add(tryCast);
                }
                catch (Exception) { }
            }

            return results;
        }

        public static List<TSource> RemoveItemOfType<TSource, TCast>(this List<TSource> list)
            where TSource : Il2CppSystem.Object
            where TCast : Il2CppSystem.Object
        {
            var item = GetItemOfType<TSource, TCast>(list);
            return RemoveItem(list, item);
        }


        public static List<TSource> RemoveItem<TSource, TCast>(this List<TSource> list, TCast itemToRemove)
            where TSource : Il2CppSystem.Object where TCast : Il2CppSystem.Object
        {
            if (!HasItemsOfType<TSource, TCast>(list))
                return list;

            var newList = list;
            for (int i = 0; i < list.Count; i++)
            {
                var item = list[i];
                if (item is null || !item.Equals(itemToRemove.TryCast<TCast>()))
                    continue;

                newList.RemoveAt(i);
                break;
            }
            return newList;
        }


        public static List<TSource> RemoveItemsOfType<TSource, TCast>(this List<TSource> list)
            where TSource : Il2CppSystem.Object
            where TCast : Il2CppSystem.Object
        {
            if (!HasItemsOfType<TSource, TCast>(list))
                return list;

            var newList = list;
            int numRemoved = 0;
            for (int i = 0; i < list.Count; i++)
            {
                var item = list[i];
                if (item is null || item.TryCast<TCast>() == null)
                    continue;

                newList.RemoveAt(i - numRemoved);
                numRemoved++;
            }

            return newList;
        }
    }
}