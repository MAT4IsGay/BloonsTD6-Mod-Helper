using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnhollowerBaseLib;
using BloonsTD6_Mod_Helper.Extensions;

namespace BloonsTD6_Mod_Helper.Api.Utils
{
    public static class BehaviorUtils
    {
        public static bool HasBehavior<T>(Il2CppReferenceArray<T> array) where T : Model
        {
            if (array == null || array.Count == 0)
                return false;

            try { var result = array.First(item => item.name.Contains(typeof(T).Name)); }
            catch (Exception) { return false; }

            return true;
        }

        public static void AddBehavior<T>(ref Il2CppReferenceArray<T> array, T behavior) where T : Model
        {
            var behaviors = array;
            Il2CppUtils.Add(ref behaviors, behavior);
            array = behaviors;
        }

        public static T GetBehavior<T>(ref Il2CppReferenceArray<T> array) where T : Model
        {
            var behaviors = array;
            var result = behaviors.FirstOrDefault(behavior => behavior.name.Contains(typeof(T).Name));
            return result.TryCast<T>();
        }

        public static List<T> GetBehaviors<T>(ref Il2CppReferenceArray<T> array) where T : Model
        {
            if (!HasBehavior(array))
                return null;

            var results = array.OfType<T>().Where(behavior => behavior.name.Contains(typeof(T).Name));

            //replaced with code above
            //var results = new Il2CppReferenceArray<T>(0);
            /*foreach (var behavior in array)
            {
                if (behavior.name.Contains(typeof(T).Name))
                    Il2CppUtils.Add(ref results, behavior.TryCast<T>());
            }*/



            return results.ToList();
        }


        /// <summary>
        /// This is probably not done. Make sure you can remove a SINGLE behavior
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="towerModel"></param>
        public static void RemoveBehavior<T>(ref Il2CppReferenceArray<T> array) where T : Model
        {
            if (!HasBehavior(array))
                return;

            var behaviors = GetBehaviors(ref array);
            foreach (var item in behaviors)
                RemoveBehavior(ref array, item);
        }

        /// <summary>
        /// This is probably not done. Make sure it removes a SINGLE behavior
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="towerModel"></param>
        /// <param name="behavior"></param>
        public static void RemoveBehavior<T>(ref Il2CppReferenceArray<T> array, T behavior) where T : Model
        {
            if (!HasBehavior(array))
                return;

            int itemsRemoved = 0;
            var behaviors = array;
            array = new Il2CppReferenceArray<T>(behaviors.Length - 1);

            for (int i = 0; i < behaviors.Length; i++)
            {
                var item = behaviors[i];
                if (item.name == behavior.name)
                {
                    itemsRemoved++;
                    continue;
                }

                array[i - itemsRemoved] = item;
            }
        }

        public static void RemoveBehaviors<T>(ref Il2CppReferenceArray<T> array) where T : Model
        {
            
        }
    }
}