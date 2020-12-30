using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class ListExt
    {
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