using Assets.Scripts.Models;
using Assets.Scripts.Models.Map.Gizmos;
using BloonsTD6_Mod_Helper.Api.Utils;
using System.Collections.Generic;
using System.Linq;
using UnhollowerBaseLib;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class MapGizmoModelBehaviorExt
    {
        public static bool HasBehavior<T>(this MapGizmoModel model) where T : Model
        {
            return BehaviorUtils_Il2CppReferenceArray.HasBehavior<MapGizmoBehaviorModel, T>(model.behaviors);
        }

        public static T GetBehavior<T>(this MapGizmoModel model) where T : Model
        {
            return BehaviorUtils_Il2CppReferenceArray.GetBehavior<MapGizmoBehaviorModel, T>(model.behaviors);
        }

        public static List<T> GetBehaviors<T>(this MapGizmoModel model) where T : Model
        {
            return BehaviorUtils_Il2CppReferenceArray.GetBehaviors<MapGizmoBehaviorModel, T>(model.behaviors)?.ToList();
        }

        public static void AddBehavior<T>(this MapGizmoModel model, T behavior) where T : Model
        {
            BehaviorUtils_Il2CppReferenceArray.AddBehavior(model.behaviors, behavior, out Il2CppReferenceArray<MapGizmoBehaviorModel> moddedArray);
            model.behaviors = moddedArray;
        }

        public static void RemoveBehavior<T>(this MapGizmoModel model) where T : Model
        {
            BehaviorUtils_Il2CppReferenceArray.RemoveBehavior<MapGizmoBehaviorModel, T>(model.behaviors, out Il2CppReferenceArray<MapGizmoBehaviorModel> moddedArray);
            model.behaviors = moddedArray;
        }

        public static void RemoveBehavior<T>(this MapGizmoModel model, T behavior) where T : Model
        {
            BehaviorUtils_Il2CppReferenceArray.RemoveBehavior<MapGizmoBehaviorModel, T>(model.behaviors, behavior, out Il2CppReferenceArray<MapGizmoBehaviorModel> moddedArray);
            model.behaviors = moddedArray;
        }

        public static void RemoveBehaviors<T>(this MapGizmoModel model) where T : Model
        {
            BehaviorUtils_Il2CppReferenceArray.RemoveBehaviors<MapGizmoBehaviorModel, T>(model.behaviors, out Il2CppReferenceArray<MapGizmoBehaviorModel> moddedArray);
            model.behaviors = moddedArray;
        }
    }
}
