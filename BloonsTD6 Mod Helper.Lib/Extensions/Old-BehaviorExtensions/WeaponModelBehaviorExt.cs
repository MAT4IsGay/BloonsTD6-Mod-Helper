using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers.Weapons;
using BloonsTD6_Mod_Helper.Api.Utils;
using System.Collections.Generic;
using System.Linq;
using UnhollowerBaseLib;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class WeaponModelBehaviorExt
    {
        public static bool HasBehavior<T>(this WeaponModel model) where T : Model
        {
            return BehaviorUtils_Il2CppReferenceArray.HasBehavior<WeaponBehaviorModel, T>(model.behaviors);
        }

        public static T GetBehavior<T>(this WeaponModel model) where T : Model
        {
            return BehaviorUtils_Il2CppReferenceArray.GetBehavior<WeaponBehaviorModel, T>(model.behaviors);
        }

        public static List<T> GetBehaviors<T>(this WeaponModel model) where T : Model
        {
            return BehaviorUtils_Il2CppReferenceArray.GetBehaviors<WeaponBehaviorModel, T>(model.behaviors)?.ToList();
        }

        public static void AddBehavior<T>(this WeaponModel model, T behavior) where T : Model
        {
            BehaviorUtils_Il2CppReferenceArray.AddBehavior(model.behaviors, behavior, out Il2CppReferenceArray<WeaponBehaviorModel> moddedArray);
            model.behaviors = moddedArray;
        }

        public static void RemoveBehavior<T>(this WeaponModel model) where T : Model
        {
            
            BehaviorUtils_Il2CppReferenceArray.RemoveBehavior<WeaponBehaviorModel, T>(model.behaviors, out Il2CppReferenceArray<WeaponBehaviorModel> moddedArray);
            model.behaviors = moddedArray;
        }

        public static void RemoveBehavior<T>(this WeaponModel model, T behavior) where T : Model
        {
            BehaviorUtils_Il2CppReferenceArray.RemoveBehavior(model.behaviors, behavior, out Il2CppReferenceArray<WeaponBehaviorModel> moddedArray);
            model.behaviors = moddedArray;
        }

        public static void RemoveBehaviors<T>(this WeaponModel model) where T : Model
        {
            BehaviorUtils_Il2CppReferenceArray.RemoveBehaviors<WeaponBehaviorModel, T>(model.behaviors, out Il2CppReferenceArray<WeaponBehaviorModel> moddedArray);
            model.behaviors = moddedArray;
        }
    }
}
