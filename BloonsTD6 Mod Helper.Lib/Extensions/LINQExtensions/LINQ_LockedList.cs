using Assets.Scripts.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class LINQ_LockedList
    {
        public static T First<T>(this LockList<T> source, Func<T, bool> predicate) where T : Il2CppSystem.Object
        {
            for (int i = 0; i < source.Count; i++)
            {
                var item = source[i];
                if (predicate(item))
                    return item;
            }

            throw new NullReferenceException();
        }

        public static T FirstOrDefault<T>(this LockList<T> source, Func<T, bool> predicate) where T : Il2CppSystem.Object
        {
            for (int i = 0; i < source.Count; i++)
            {
                var item = source[i];
                if (predicate(item))
                    return item;
            }
            return default;
        }

        public static List<T> Where<T>(this LockList<T> source, Func<T, bool> predicate) where T : Il2CppSystem.Object
        {
            List<T> result = new List<T>();
            for (int i = 0; i < source.Count; i++)
            {
                var item = source[i];
                if (predicate(item))
                    result.Add(item);
            }
            return result;
        }

        public static int FindIndex<T>(this LockList<T> source, Func<T, bool> predicate) where T : Il2CppSystem.Object
        {
            for (int i = 0; i < source.Count; i++)
            {
                if (predicate(source[i]))
                    return i;
            }

            return -1;
        }

        public static bool Any<T>(this LockList<T> source) where T : Il2CppSystem.Object
        {
            if (source is null)
                return false;

            bool hasItems = false;
            for (int i = 0; i < source.Count; i++)
            {
                hasItems = true;
                break;
            }

            return hasItems;
        }
    }
}
