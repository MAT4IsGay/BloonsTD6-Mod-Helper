using Assets.Scripts.Models;
using Assets.Scripts.Models.SimulationBehaviors;
using BloonsTD6_Mod_Helper.Api.Utils;
using System.Collections.Generic;
using System.Linq;
using UnhollowerBaseLib;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class GameModelBehaviorExt
    {
        public static bool HasBehavior<T>(this GameModel model) where T : Model
        {
            return BehaviorUtils_Il2CppReferenceArray.HasBehavior<SimulationBehaviorModel, T>(model.behaviors);
        }

        public static T GetBehavior<T>(this GameModel model) where T : Model
        {
            return BehaviorUtils_Il2CppReferenceArray.GetBehavior<SimulationBehaviorModel, T>(model.behaviors);
        }

        public static List<T> GetBehaviors<T>(this GameModel model) where T : Model
        {
            return BehaviorUtils_Il2CppReferenceArray.GetBehaviors<SimulationBehaviorModel, T>(model.behaviors)?.ToList();
        }

        public static void AddBehavior<T>(this GameModel model, T behavior) where T : Model
        {
            BehaviorUtils_Il2CppReferenceArray.AddBehavior(model.behaviors, behavior, out Il2CppReferenceArray<SimulationBehaviorModel> moddedArray);
            model.behaviors = moddedArray;
        }

        public static void RemoveBehavior<T>(this GameModel model) where T : Model
        {
            BehaviorUtils_Il2CppReferenceArray.RemoveBehavior<SimulationBehaviorModel, T>(model.behaviors, out Il2CppReferenceArray<SimulationBehaviorModel> moddedArray);
            model.behaviors = moddedArray;
        }

        public static void RemoveBehavior<T>(this GameModel model, T behavior) where T : Model
        {
            BehaviorUtils_Il2CppReferenceArray.RemoveBehavior<SimulationBehaviorModel, T>(model.behaviors, behavior, out Il2CppReferenceArray<SimulationBehaviorModel> moddedArray);
            model.behaviors = moddedArray;
        }

        public static void RemoveBehaviors<T>(this GameModel model) where T : Model
        {
            BehaviorUtils_Il2CppReferenceArray.RemoveBehaviors<SimulationBehaviorModel, T>(model.behaviors, out Il2CppReferenceArray<SimulationBehaviorModel> moddedArray);
            model.behaviors = moddedArray;
        }
    }
}
