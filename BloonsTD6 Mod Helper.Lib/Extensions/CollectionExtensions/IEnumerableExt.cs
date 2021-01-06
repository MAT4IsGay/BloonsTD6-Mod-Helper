using Assets.Scripts.Utils;
using System.Collections.Generic;
using System.Linq;
using UnhollowerBaseLib;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class IEnumerableExt
    {
        public static Il2CppSystem.Collections.Generic.List<T> ToIl2CppList<T>(this IEnumerable<T> enumerable)
        {
            Il2CppSystem.Collections.Generic.List<T> il2CppList = new Il2CppSystem.Collections.Generic.List<T>();
            for (int i = 0; i < enumerable.Count(); i++)
                il2CppList.Add(enumerable.ElementAt(i));
            
            return il2CppList;
        }

        public static Il2CppReferenceArray<T> ToIl2CppReferenceArray<T>(this IEnumerable<T> enumerable) where T : Il2CppSystem.Object
        {
            var il2cppArray = new Il2CppReferenceArray<T>(enumerable.Count());

            for (int i = 0; i < enumerable.Count(); i++)
                il2cppArray[i] = enumerable.ElementAt(i);

            return il2cppArray;
        }

        /// <summary>
        /// Not Tested
        /// </summary>
        public static LockList<T> ToLockList<T>(this IEnumerable<T> enumerable)
        {
            LockList<T> lockList = new LockList<T>();
            for (int i = 0; i < enumerable.Count(); i++)
                lockList.Add(enumerable.ElementAt(i));

            return lockList;
        }




        public static IEnumerable<T> Clone<T>(this IEnumerable<T> enumerable)
        {
            List<T> test = new List<T>();
            foreach (var item in enumerable)
                test.Add(item);

            return test.AsEnumerable();
        }

        public static IEnumerable<TCast> CloneAs<TSource, TCast>(this IEnumerable<TSource> enumerable)
            where TSource : Il2CppSystem.Object where TCast : Il2CppSystem.Object
        {
            List<TCast> test = new List<TCast>();
            foreach (var item in enumerable)
                test.Add(item.TryCast<TCast>());

            return test.AsEnumerable();
        }
    }
}