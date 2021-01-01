using Assets.Scripts.Models;
using Assets.Scripts.Simulation.Map.Gizmos;
using Assets.Scripts.Simulation.Objects;
using Assets.Scripts.Utils;
using BloonsTD6_Mod_Helper.Api.Utils;
using System.Collections.Generic;
using System.Linq;
using UnhollowerBaseLib;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class MapGizmoBehaviorExt
    {
        // Currently broken. Might need a new BehaviorUtils class for handling SizedLists
        public static bool HasBehavior<T>(this MapGizmo model) where T : MapGizmoBehavior
        {
            return BehaviorUtils_SizedList.HasBehavior<MapGizmoBehavior, T>(model.behaviors);
        }

        public static T GetBehavior<T>(this MapGizmo model) where T : MapGizmoBehavior
        {
            return BehaviorUtils_SizedList.GetBehavior<MapGizmoBehavior, T>(model.behaviors);
        }

        public static List<T> GetBehaviors<T>(this MapGizmo model) where T : MapGizmoBehavior
        {
            return BehaviorUtils_SizedList.GetBehaviors<MapGizmoBehavior, T>(model.behaviors)?.ToList();
        }

        public static void AddBehavior<T>(this MapGizmo model, T behavior) where T : MapGizmoBehavior
        {
            BehaviorUtils_SizedList.AddBehavior(model.behaviors, behavior, out SizedList<MapGizmoBehavior> moddedArray);
            model.behaviors = moddedArray;
        }

        public static void RemoveBehavior<T>(this MapGizmo model) where T : MapGizmoBehavior
        {
            BehaviorUtils_SizedList.RemoveBehavior<MapGizmoBehavior, T>(model.behaviors, out SizedList<MapGizmoBehavior> moddedArray);
            model.behaviors = moddedArray;
        }

        public static void RemoveBehavior<T>(this MapGizmo model, T behavior) where T : MapGizmoBehavior
        {
            BehaviorUtils_SizedList.RemoveBehavior<MapGizmoBehavior, T>(model.behaviors, behavior, out SizedList<MapGizmoBehavior> moddedArray);
            model.behaviors = moddedArray;
        }

        public static void RemoveBehaviors<T>(this MapGizmo model) where T : MapGizmoBehavior
        {
            BehaviorUtils_SizedList.RemoveBehaviors<MapGizmoBehavior, T>(model.behaviors, out SizedList<MapGizmoBehavior> moddedArray);
            model.behaviors = moddedArray;
        }
    }
}
