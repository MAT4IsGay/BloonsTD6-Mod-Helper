using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers.Behaviors.Emissions;
using BloonsTD6_Mod_Helper.Api.Utils;
using System.Collections.Generic;
using System.Linq;
using UnhollowerBaseLib;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class EmissionModelBehaviorExt
    {
        public static bool HasBehavior<T>(this EmissionModel model) where T : Model
        {
            return BehaviorUtils_Il2CppReferenceArray.HasBehavior<EmissionBehaviorModel, T>(model.behaviors);
        }

        public static T GetBehavior<T>(this EmissionModel model) where T : Model
        {
            return BehaviorUtils_Il2CppReferenceArray.GetBehavior<EmissionBehaviorModel, T>(model.behaviors);
        }

        public static List<T> GetBehaviors<T>(this EmissionModel model) where T : Model
        {
            return BehaviorUtils_Il2CppReferenceArray.GetBehaviors<EmissionBehaviorModel, T>(model.behaviors)?.ToList();
        }

        public static void AddBehavior<T>(this EmissionModel model, T behavior) where T : Model
        {
            BehaviorUtils_Il2CppReferenceArray.AddBehavior(model.behaviors, behavior, out Il2CppReferenceArray<EmissionBehaviorModel> moddedArray);
            model.behaviors = moddedArray;
        }

        public static void RemoveBehavior<T>(this EmissionModel model) where T : Model
        {
            
            BehaviorUtils_Il2CppReferenceArray.RemoveBehavior<EmissionBehaviorModel, T>(model.behaviors, out Il2CppReferenceArray<EmissionBehaviorModel> moddedArray);
            model.behaviors = moddedArray;
        }

        public static void RemoveBehavior<T>(this EmissionModel model, T behavior) where T : Model
        {
            BehaviorUtils_Il2CppReferenceArray.RemoveBehavior(model.behaviors, behavior, out Il2CppReferenceArray<EmissionBehaviorModel> moddedArray);
            model.behaviors = moddedArray;
        }

        public static void RemoveBehaviors<T>(this EmissionModel model) where T : Model
        {
            BehaviorUtils_Il2CppReferenceArray.RemoveBehaviors<EmissionBehaviorModel, T>(model.behaviors, out Il2CppReferenceArray<EmissionBehaviorModel> moddedArray);
            model.behaviors = moddedArray;
        }
    }
}
