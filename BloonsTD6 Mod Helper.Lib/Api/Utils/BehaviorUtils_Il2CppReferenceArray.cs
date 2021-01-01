using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using UnhollowerBaseLib;
using BloonsTD6_Mod_Helper.Extensions;

namespace BloonsTD6_Mod_Helper.Api.Utils
{
    public static class BehaviorUtils_Il2CppReferenceArray
    {
        /// <summary>
        /// Check if Behaviors Array contains any behaviors of type T
        /// </summary>
        /// <typeparam name="TSource">Type of behavior to check</typeparam>
        /// <param name="behaviors">Array of behaviors to check</param>
        /// <returns></returns>
        public static bool HasBehavior<TSource, TCast>(Il2CppReferenceArray<TSource> behaviors) 
            where TSource : Model
            where TCast : Model
        {
            try { var result = behaviors.First(item => item.TryCast<TCast>() != null); }
            catch (Exception) { return false; }

            return true;
        }


        public static void AddBehavior<TSource, TCast>(Il2CppReferenceArray<TSource> array, TCast behavior, 
            out Il2CppReferenceArray<TSource> moddedArray) 
            where TSource : Model
            where TCast : Model
        {
            Il2CppUtils.Add(array, behavior, out moddedArray);
        }


        public static TCast GetBehavior<TSource, TCast>(Il2CppReferenceArray<TSource> array) 
            where TCast : Model
            where TSource : Model
        {
            if (!HasBehavior<TSource, TCast>(array))
                return null;

            var result = array.FirstOrDefault(behavior => behavior.TryCast<TCast>() != null);
            return result.TryCast<TCast>();
        }

        public static List<TCast> GetBehaviors<TSource, TCast>(Il2CppReferenceArray<TSource> array) 
            where TSource : Model
            where TCast : Model
        {
            if (!HasBehavior<TSource, TCast>(array))
                return null;

            //var results = array.OfType<T>().Where(behavior => behavior.TryCast<T>() != null); //Wont remove for the time being
            var results = array.Where(behavior => behavior.TryCast<TCast>() != null);
            
            List<TCast> behaviors = new List<TCast>();
            foreach (var item in results)
                behaviors.Add(item.TryCast<TCast>());

            return behaviors;
        }

        public static void RemoveBehavior<TSource, TCast>(Il2CppReferenceArray<TSource> array, out Il2CppReferenceArray<TSource> newArray)
            where TSource : Model
            where TCast : Model
        {
            var behavior = GetBehavior<TSource, TCast>(array);
            RemoveBehavior(array, behavior, out newArray);
        }


        public static void RemoveBehavior<TSource, TCast>(Il2CppReferenceArray<TSource> array, TCast behavior, 
            out Il2CppReferenceArray<TSource> newArray)
            where TSource : Model
            where TCast : Model
        {
            newArray = array;
            if (!HasBehavior<TSource, TCast>(array))
                return;

            var arrayList = array.ToList();

            for (int i = 0; i < array.Count; i++)
            {
                var item = array[i];
                if (item is null || !item.Equals(behavior.TryCast<TCast>()))
                    continue;

                arrayList.RemoveAt(i);
                break;
            }

            newArray = arrayList.ToIl2CppReferenceArray();
        }

        
        public static void RemoveBehaviors<TSource, TCast>(Il2CppReferenceArray<TSource> array, out Il2CppReferenceArray<TSource> newArray)
            where TSource : Model
            where TCast : Model
        {
            newArray = array;
            if (!HasBehavior<TSource, TCast>(array))
                return;

            int numRemoved = 0;
            var arrayList = array.ToList();
            for (int i = 0; i < array.Count; i++)
            {
                var item = array[i];
                if (item is null || item.TryCast<TCast>() == null)
                    continue;
                
                arrayList.RemoveAt(i - numRemoved);
                numRemoved++;
            }

            newArray = arrayList.ToIl2CppReferenceArray();
        }
    }
}