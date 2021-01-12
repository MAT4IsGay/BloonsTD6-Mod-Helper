using System;
using UnhollowerBaseLib;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class LINQ_Il2CppReferenceArray
    {
        public static int? FindIndex<T>(this Il2CppReferenceArray<T> source, Func<T, bool> predicate) where T : Il2CppSystem.Object
        {
            for (int i = 0; i < source.Count; i++)
            {
                if (predicate(source[i]))
                    return i;
            }

            return null;
        }
    }
}
