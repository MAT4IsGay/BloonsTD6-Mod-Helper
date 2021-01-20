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
            return default;
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

        public static int FindIndex<T>(this List<T> source, Func<T, bool> predicate) where T : Il2CppSystem.Object
        {
            for (int i = 0; i < source.Count; i++)
            {
                if (predicate(source[i]))
                    return i;
            }

            return -1;
        }

        public static bool Any<T>(this List<T> source) where T : Il2CppSystem.Object
        {
            if (source is null)
                return false;

            bool hasItems = false;
            foreach (var item in source)
            {
                hasItems = true;
                break;
            }

            return hasItems;
        }
    }
}