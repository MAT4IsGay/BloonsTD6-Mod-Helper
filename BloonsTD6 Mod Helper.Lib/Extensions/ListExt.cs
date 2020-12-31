using BloonsTD6_Mod_Helper.Api.Utils;
using System;
using System.Collections.Generic;
using UnhollowerBaseLib;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class ListExt
    {
        public static Il2CppReferenceArray<T> ToIl2CppReferenceArray<T> (this List<T> list) where T : Il2CppObjectBase
        {
            var il2cppArray = new Il2CppReferenceArray<T>(0);
            foreach (var item in list)
                Il2CppUtils.Add(ref il2cppArray, item);

            return il2cppArray;
        }

        public static int GetMaxValue(this List<int> numbers)
        {
            var max = 0;
            foreach (var item in numbers)
                max = (item > max) ? item : max;

            return max;
        }

        public static float GetMaxValue(this List<float> numbers)
        {
            var max = 0f;
            foreach (var item in numbers)
                max = (item > max) ? item : max;

            return max;
        }

        public static double GetMaxValue(this List<double> numbers)
        {
            double max = 0;
            foreach (var item in numbers)
                max = (item > max) ? item : max;
            
            return max;
        }

        public static long GetMaxValue(this List<long> numbers)
        {
            long max = 0;
            foreach (var item in numbers)
                max = (item > max) ? item : max;

            return max;
        }
    }
}