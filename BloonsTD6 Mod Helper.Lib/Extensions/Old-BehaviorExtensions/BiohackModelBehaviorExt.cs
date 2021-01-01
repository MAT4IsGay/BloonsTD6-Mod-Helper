using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using BloonsTD6_Mod_Helper.Api.Utils;
using System.Collections.Generic;
using System.Linq;
using UnhollowerBaseLib;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class BiohackModelBehaviorExt
    {
        public static bool HasBehavior<T>(this BiohackModel model) where T : Model
        {
            return BehaviorUtils_Il2CppReferenceArray.HasBehavior<TowerBehaviorModel, T>(model.behaviors);
        }

        public static T GetBehavior<T>(this BiohackModel model) where T : Model
        {
            return BehaviorUtils_Il2CppReferenceArray.GetBehavior<TowerBehaviorModel, T>(model.behaviors);
        }

        public static List<T> GetBehaviors<T>(this BiohackModel model) where T : Model
        {
            return BehaviorUtils_Il2CppReferenceArray.GetBehaviors<TowerBehaviorModel, T>(model.behaviors)?.ToList();
        }

        public static void AddBehavior<T>(this BiohackModel model, T behavior) where T : Model
        {
            BehaviorUtils_Il2CppReferenceArray.AddBehavior(model.behaviors, behavior, out Il2CppReferenceArray<TowerBehaviorModel> moddedArray);
            model.behaviors = moddedArray;
        }

        public static void RemoveBehavior<T>(this BiohackModel model) where T : Model
        {
            BehaviorUtils_Il2CppReferenceArray.RemoveBehavior<TowerBehaviorModel, T>(model.behaviors, out Il2CppReferenceArray<TowerBehaviorModel> moddedArray);
            model.behaviors = moddedArray;
        }

        public static void RemoveBehavior<T>(this BiohackModel model, T behavior) where T : Model
        {
            BehaviorUtils_Il2CppReferenceArray.RemoveBehavior<TowerBehaviorModel, T>(model.behaviors, behavior, out Il2CppReferenceArray<TowerBehaviorModel> moddedArray);
            model.behaviors = moddedArray;
        }

        public static void RemoveBehaviors<T>(this BiohackModel model) where T : Model
        {
            BehaviorUtils_Il2CppReferenceArray.RemoveBehaviors<TowerBehaviorModel, T>(model.behaviors, out Il2CppReferenceArray<TowerBehaviorModel> moddedArray);
            model.behaviors = moddedArray;
        }
    }
}
