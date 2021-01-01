using UnhollowerBaseLib;

namespace BloonsTD6_Mod_Helper.Api.Utils
{
    public class Il2CppUtils
    {
        public static void Add<TSource, TCast>(Il2CppReferenceArray<TSource> array, TCast item, out Il2CppReferenceArray<TSource> moddedArray)
            where TSource : Il2CppObjectBase
            where TCast : Il2CppObjectBase
        {
            var initialArray = array;
            moddedArray = new Il2CppReferenceArray<TSource>(initialArray.Length + 1);
            
            for (int i = 0; i < initialArray.Length; i++)
                moddedArray[i] = initialArray[i];

            moddedArray[moddedArray.Length - 1] = item.TryCast<TSource>();
        }

        public static void Remove<T>(ref Il2CppReferenceArray<T> array, T item, out Il2CppReferenceArray<T> moddedArray) where T : Il2CppSystem.Object  // where T : Il2CppObjectBase
        {
            var initialArray = array;
            moddedArray = new Il2CppReferenceArray<T>(initialArray.Length - 1);

            int i = 0;
            foreach (var thing in initialArray)
            {
                if (thing == item)
                    continue;

                array[i] = initialArray[i];
                i++;
            }
        }
    }
}