using Assets.Scripts.Models;
using Assets.Scripts.Models.Powers;
using BloonsTD6_Mod_Helper.Api.Utils;
using System.Collections.Generic;
using System.Linq;
using UnhollowerBaseLib;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class PowerModelBehaviorExt
    {
        public static bool HasBehavior<T>(this PowerModel model) where T : Model
        {
            return BehaviorUtils_Il2CppReferenceArray.HasBehavior<PowerBehaviorModel, T>(model.behaviors);
        }

        public static T GetBehavior<T>(this PowerModel model) where T : Model
        {
            return BehaviorUtils_Il2CppReferenceArray.GetBehavior<PowerBehaviorModel, T>(model.behaviors);
        }

        public static List<T> GetBehaviors<T>(this PowerModel model) where T : Model
        {
            return BehaviorUtils_Il2CppReferenceArray.GetBehaviors<PowerBehaviorModel, T>(model.behaviors)?.ToList();
        }

        public static void AddBehavior<T>(this PowerModel model, T behavior) where T : Model
        {
            BehaviorUtils_Il2CppReferenceArray.AddBehavior(model.behaviors, behavior, out Il2CppReferenceArray<PowerBehaviorModel> moddedArray);
            model.behaviors = moddedArray;
        }

        public static void RemoveBehavior<T>(this PowerModel model) where T : Model
        {
            BehaviorUtils_Il2CppReferenceArray.RemoveBehavior<PowerBehaviorModel, T>(model.behaviors, out Il2CppReferenceArray<PowerBehaviorModel> moddedArray);
            model.behaviors = moddedArray;
        }

        public static void RemoveBehavior<T>(this PowerModel model, T behavior) where T : Model
        {
            BehaviorUtils_Il2CppReferenceArray.RemoveBehavior<PowerBehaviorModel, T>(model.behaviors, behavior, out Il2CppReferenceArray<PowerBehaviorModel> moddedArray);
            model.behaviors = moddedArray;
        }

        public static void RemoveBehaviors<T>(this PowerModel model) where T : Model
        {
            BehaviorUtils_Il2CppReferenceArray.RemoveBehaviors<PowerBehaviorModel, T>(model.behaviors, out Il2CppReferenceArray<PowerBehaviorModel> moddedArray);
            model.behaviors = moddedArray;
        }
    }
}
