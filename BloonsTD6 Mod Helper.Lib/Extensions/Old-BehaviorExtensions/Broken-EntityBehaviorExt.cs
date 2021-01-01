using Assets.Scripts.Models;
using Assets.Scripts.Models.Bloons;
using Assets.Scripts.Models.Towers.Behaviors.Emissions;
using Assets.Scripts.Simulation.Objects;
using BloonsTD6_Mod_Helper.Api.Utils;
using System.Collections.Generic;
using System.Linq;
using UnhollowerBaseLib;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class EntityBehaviorExt
    {
        // Currently broken. Might need a new BehaviorUtils class for handling LockedLists
        /*public static bool HasBehavior<T>(this Entity model) where T : Model
        {
            return BehaviorUtils.HasBehavior<RootBehavior, T>(model.behaviors);
        }

        public static T GetBehavior<T>(this Entity model) where T : Model
        {
            return BehaviorUtils.GetBehavior<RootBehavior, T>(model.behaviors);
        }

        public static List<T> GetBehaviors<T>(this Entity model) where T : Model
        {
            return BehaviorUtils.GetBehaviors<RootBehavior, T>(model.behaviors)?.ToList();
        }

        public static void AddBehavior<T>(this Entity model, T behavior) where T : Model
        {
            BehaviorUtils.AddBehavior(model.behaviors, behavior, out Il2CppReferenceArray<RootBehavior> moddedArray);
            model.behaviors = moddedArray;
        }

        public static void RemoveBehavior<T>(this Entity model) where T : Model
        {
            
            BehaviorUtils.RemoveBehavior<RootBehavior, T>(model.behaviors, out Il2CppReferenceArray<RootBehavior> moddedArray);
            model.behaviors = moddedArray;
        }

        public static void RemoveBehavior<T>(this Entity model, T behavior) where T : Model
        {
            BehaviorUtils.RemoveBehavior(model.behaviors, behavior, out Il2CppReferenceArray<RootBehavior> moddedArray);
            model.behaviors = moddedArray;
        }

        public static void RemoveBehaviors<T>(this Entity model) where T : Model
        {
            BehaviorUtils.RemoveBehaviors<RootBehavior, T>(model.behaviors, out Il2CppReferenceArray<RootBehavior> moddedArray);
            model.behaviors = moddedArray;
        }*/
    }
}
