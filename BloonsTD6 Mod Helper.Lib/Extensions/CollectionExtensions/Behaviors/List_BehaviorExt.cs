using Assets.Scripts.Models;
using System.Collections.Generic;
using System.Linq;

namespace BloonsTD6_Mod_Helper.Extensions.CollectionExtensions.Behaviors
{
    public static class List_BehaviorExt
    {
        public static bool HasValue<TSource>(this List<TSource> list) where TSource : Model
        {
            return BehaviorUtils_Il2CppReferenceArray.HasBehavior<TowerBehaviorModel, TSource>(model.behaviors);
        }

        public static T GetValue<T>(this List<T> list) where T : Model
        {
            return BehaviorUtils_Il2CppReferenceArray.GetBehavior<TowerBehaviorModel, T>(model.behaviors);
        }

        public static List<T> GeValues<T>(this List<T> list) where T : Model
        {
            return BehaviorUtils_Il2CppReferenceArray.GetBehaviors<TowerBehaviorModel, T>(model.behaviors)?.ToList();
        }

        public static void AddValue<T>(this List<T> list, T behavior) where T : Model
        {
            BehaviorUtils_Il2CppReferenceArray.AddBehavior(model.behaviors, behavior, out Il2CppReferenceArray<TowerBehaviorModel> moddedArray);
            model.behaviors = moddedArray;
        }

        public static void RemoveValue<T>(this List<T> list) where T : Model
        {

            BehaviorUtils_Il2CppReferenceArray.RemoveBehavior<TowerBehaviorModel, T>(model.behaviors, out Il2CppReferenceArray<TowerBehaviorModel> moddedArray);
            model.behaviors = moddedArray;
        }

        public static void RemoveValue<T>(this List<T> list, T behavior) where T : Model
        {
            BehaviorUtils_Il2CppReferenceArray.RemoveBehavior(model.behaviors, behavior, out Il2CppReferenceArray<TowerBehaviorModel> moddedArray);
            model.behaviors = moddedArray;
        }

        public static void RemoveValues<T>(this List<T> list) where T : Model
        {
            BehaviorUtils_Il2CppReferenceArray.RemoveBehaviors<TowerBehaviorModel, T>(model.behaviors, out Il2CppReferenceArray<TowerBehaviorModel> moddedArray);
            model.behaviors = moddedArray;
        }
    }
}
