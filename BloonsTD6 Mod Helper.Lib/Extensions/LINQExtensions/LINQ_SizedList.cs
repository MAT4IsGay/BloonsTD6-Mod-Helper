using Assets.Scripts.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class LINQ_SizedList
    {
        public static T First<T>(this SizedList<T> source, Func<T, bool> predicate) where T : Il2CppSystem.Object
        {
            for (int i = 0; i < source.Count; i++)
            {
                var item = source[i];
                if (predicate(item))
                    return item;
            }

            throw new NullReferenceException();
        }

        public static T FirstOrDefault<T>(this SizedList<T> source, Func<T, bool> predicate) where T : Il2CppSystem.Object
        {
            for (int i = 0; i < source.Count; i++)
            {
                var item = source[i];
                if (predicate(item))
                    return item;
            }
            return default;
        }

        public static List<T> Where<T>(this SizedList<T> source, Func<T, bool> predicate) where T : Il2CppSystem.Object
        {
            if (source is null)
                return null;

            List<T> result = new List<T>();
            for (int i = 0; i < source.Count; i++)
            {
                var item = source[i];
                if (predicate(item))
                    result.Add(item);
            }
            return result;
        }

        public static int FindIndex<T>(this SizedList<T> source, Func<T, bool> predicate) where T : Il2CppSystem.Object
        {
            for (int i = 0; i < source.Count; i++)
            {
                if (predicate(source[i]))
                    return i;
            }

            return -1;
        }

        public static bool Any<T>(this SizedList<T> source) where T : Il2CppSystem.Object
        {
            return source.Count > 0;

            // will remove code below if code above works
            /*if (source is null)
                return false;

            bool hasItems = false;
            for (int i = 0; i < source.Count; i++)
            {
                hasItems = true;
                break;
            }

            return hasItems;*/
        }
    }
}
