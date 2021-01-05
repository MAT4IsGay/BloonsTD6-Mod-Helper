using Assets.Scripts.Utils;
using BloonsTD6_Mod_Helper.Api.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using UnhollowerBaseLib;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class ListExt
    {
        /// <summary>
        /// Not tested
        /// </summary>
        public static Il2CppSystem.Collections.Generic.List<T> ToIl2CppList<T> (this List<T> list)
        {
            Il2CppSystem.Collections.Generic.List<T> il2CppList = new Il2CppSystem.Collections.Generic.List<T>();
            foreach (var item in list)
                il2CppList.Add(item);

            return il2CppList;
        }

        /// <summary>
        /// Not tested
        /// </summary>
        public static SizedList<T> ToSizedList<T> (this List<T> list)
        {
            SizedList<T> sizedList = new SizedList<T>();
            foreach (var item in list)
                sizedList.Add(item);

            return sizedList;
        }

        /// <summary>
        /// Confirmed working
        /// </summary>
        public static Il2CppReferenceArray<T> ToIl2CppReferenceArray<T> (this List<T> list) where T : Il2CppObjectBase
        {
            var il2cppArray = new Il2CppReferenceArray<T>(0);
            foreach (var item in list)
                Il2CppUtils.Add(il2cppArray, item, out il2cppArray);

            return il2cppArray;
        }

        /// <summary>
        /// Not Tested
        /// </summary>
        public static LockList<T> ToLockList<T>(this List<T> list)
        {
            LockList<T> lockList = new LockList<T>();
            foreach (var item in list)
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

        public static List<TCast> GetItemsOfType<TSource, TCast>(this List<TSource> list)
            where TSource : Il2CppSystem.Object
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


        public static List<TSource> RemoveItemsOfType<TSource, TCast>(this List<TSource> list) where TSource : Il2CppSystem.Object
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