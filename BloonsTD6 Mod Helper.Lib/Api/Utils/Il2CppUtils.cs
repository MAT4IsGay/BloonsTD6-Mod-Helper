using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using MelonLoader;
using System.Linq;
using UnhollowerBaseLib;

namespace BloonsTD6_Mod_Helper.Api.Utils
{
    public class Il2CppUtils
    {
        public static void Add<T> (ref Il2CppReferenceArray<T> array, T item) where T : Il2CppObjectBase
        {
            var initialArray = array;
            array = new Il2CppReferenceArray<T>(initialArray.Length + 1);

            for (int i = 0; i < initialArray.Length; i++)
                array[i] = initialArray[i];

            array[array.Length - 1] = item;
        }

        public static void Remove<T>(ref Il2CppReferenceArray<T> array, T item) where T : Il2CppObjectBase
        {
            var initialArray = array;
            array = new Il2CppReferenceArray<T>(initialArray.Length - 1);

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