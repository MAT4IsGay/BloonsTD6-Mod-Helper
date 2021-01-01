using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using UnhollowerBaseLib;
using BloonsTD6_Mod_Helper.Extensions;
using Assets.Scripts.Utils;
using Assets.Scripts.Simulation.Objects;
using Assets.Scripts.Simulation.Map.Gizmos;

namespace BloonsTD6_Mod_Helper.Api.Utils
{
    public static class BehaviorUtils_SizedList
    {
        /// <summary>
        /// Check if Behaviors Array contains any behaviors of type T
        /// </summary>
        /// <typeparam name="TSource">Type of behavior to check</typeparam>
        /// <param name="behaviors">Array of behaviors to check</param>
        /// <returns></returns>
        public static bool HasBehavior<TSource, TCast>(SizedList<TSource> behaviors) 
            where TSource : RootBehavior
            where TCast : RootBehavior
        {
            for (int i = 0; i < behaviors.count; i++)
            {
                try
                {
                    if (behaviors[i].TryCast<TCast>() != null)
                        return true;
                }
                catch (Exception) { continue; }
            }

            return false;
        }


        public static void AddBehavior<TSource, TCast>(SizedList<TSource> array, TCast behavior, out SizedList<TSource> moddedArray) 
            where TSource : RootBehavior
            where TCast : RootBehavior
        {
            Il2CppUtils.Add(array, behavior, out moddedArray);
        }


        public static TCast GetBehavior<TSource, TCast>(SizedList<TSource> array) 
            where TCast : RootBehavior
            where TSource : RootBehavior
        {
            if (!HasBehavior<TSource, TCast>(array))
                return null;

            for (int i = 0; i < array.count; i++)
            {
                var behavior = array[i].TryCast<TCast>();
                if (behavior != null)
                    return behavior;
            }

            return null;
        }

        public static SizedList<TCast> GetBehaviors<TSource, TCast>(SizedList<TSource> array) 
            where TSource : RootBehavior
            where TCast : RootBehavior
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

        public static void RemoveBehavior<TSource, TCast>(SizedList<TSource> array, out SizedList<TSource> newArray)
            where TSource : RootBehavior
            where TCast : RootBehavior
        {
            var behavior = GetBehavior<TSource, TCast>(array);
            RemoveBehavior(array, behavior, out newArray);
        }


        public static void RemoveBehavior<TSource, TCast>(SizedList<TSource> array, TCast behavior, out SizedList<TSource> newArray)
            where TSource : RootBehavior
            where TCast : RootBehavior
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

            newArray = arrayList.ToSizedList();
        }

        
        public static void RemoveBehaviors<TSource, TCast>(SizedList<TSource> array, out SizedList<TSource> newArray)
            where TSource : RootBehavior
            where TCast : RootBehavior
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

            newArray = arrayList.ToSizedList();
        }
    }
}