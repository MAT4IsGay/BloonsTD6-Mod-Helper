using Il2CppSystem.Collections.Generic;
using System;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class LINQ_Il2CppGenerics
    {
        public static T First<T>(this List<T> source, Func<T, bool> predicate) where T : Il2CppSystem.Object
        {
            foreach (var item in source)
            {
                if (predicate(item))
                    return item;
            }
            throw new NullReferenceException();
        }

        public static T FirstOrDefault<T>(this List<T> source, Func<T, bool> predicate) where T : Il2CppSystem.Object
        {
            foreach (var item in source)
            {
                if (predicate(item))
                    return item;
            }
            return null;
        }

        public static List<T> Where<T>(this List<T> source, Func<T, bool> predicate) where T : Il2CppSystem.Object
        {
            List<T> result = new List<T>();
            foreach (var item in source)
            {
                if (predicate(item))
                    result.Add(item);
            }
            return result;
        }
    }
}
