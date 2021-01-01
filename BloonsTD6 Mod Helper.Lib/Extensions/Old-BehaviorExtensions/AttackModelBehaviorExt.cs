using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using BloonsTD6_Mod_Helper.Api.Utils;
using System.Collections.Generic;
using System.Linq;
using UnhollowerBaseLib;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class AttackModelBehaviorExt
    {
        public static bool HasBehavior<T>(this AttackModel model) where T : Model
        {
            return BehaviorUtils_Il2CppReferenceArray.HasBehavior<Model, T>(model.behaviors);
        }

        public static T GetBehavior<T>(this AttackModel model) where T : Model
        {
            return BehaviorUtils_Il2CppReferenceArray.GetBehavior<Model, T>(model.behaviors);
        }

        public static List<T> GetBehaviors<T>(this AttackModel model) where T : Model
        {
            return BehaviorUtils_Il2CppReferenceArray.GetBehaviors<Model, T>(model.behaviors)?.ToList();
        }

        public static void AddBehavior<T>(this AttackModel model, T behavior) where T : Model
        {
            BehaviorUtils_Il2CppReferenceArray.AddBehavior(model.behaviors, behavior, out Il2CppReferenceArray<Model> moddedArray);
            model.behaviors = moddedArray;
        }

        public static void RemoveBehavior<T>(this AttackModel model) where T : Model
        {
            
            BehaviorUtils_Il2CppReferenceArray.RemoveBehavior<Model, T>(model.behaviors, out Il2CppReferenceArray<Model> moddedArray);
            model.behaviors = moddedArray;
        }

        public static void RemoveBehavior<T>(this AttackModel model, T behavior) where T : Model
        {
            BehaviorUtils_Il2CppReferenceArray.RemoveBehavior(model.behaviors, behavior, out Il2CppReferenceArray<Model> moddedArray);
            model.behaviors = moddedArray;
        }

        public static void RemoveBehaviors<T>(this AttackModel model) where T : Model
        {
            BehaviorUtils_Il2CppReferenceArray.RemoveBehaviors<Model, T>(model.behaviors, out Il2CppReferenceArray<Model> moddedArray);
            model.behaviors = moddedArray;
        }
    }
}
