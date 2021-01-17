using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers.Weapons;
using System.Collections.Generic;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class WeaponModelBehaviorExt
    {
        public static bool HasBehavior<T>(this WeaponModel model) where T : Model
        {
            if (model.behaviors is null)
                return false;

            return model.behaviors.HasItemsOfType<WeaponBehaviorModel, T>();
        }

        public static T GetBehavior<T>(this WeaponModel model) where T : Model
        {
            if (model.behaviors is null)
                return default;

            return model.behaviors.GetItemOfType<WeaponBehaviorModel, T>();
        }

        public static List<T> GetBehaviors<T>(this WeaponModel model) where T : Model
        {
            if (model.behaviors is null)
                return null;

            return model.behaviors.GetItemsOfType<WeaponBehaviorModel, T>();
        }

        public static void AddBehavior<T>(this WeaponModel model, T behavior) where T : WeaponBehaviorModel
        {
            if (model.behaviors is null)
                return;

            model.behaviors = model.behaviors.Add(behavior);
        }

        public static void RemoveBehavior<T>(this WeaponModel model) where T : Model
        {
            if (model.behaviors is null)
                return;

            model.behaviors = model.behaviors.RemoveItemOfType<WeaponBehaviorModel, T>();
        }

        public static void RemoveBehavior<T>(this WeaponModel model, T behavior) where T : Model
        {
            if (model.behaviors is null)
                return;

            model.behaviors = model.behaviors.Remove(behavior);
        }

        public static void RemoveBehaviors<T>(this WeaponModel model) where T : Model
        {
            if (model.behaviors is null)
                return;

            model.behaviors = model.behaviors.RemoveItemsOfType<WeaponBehaviorModel, T>();
        }
    }
}
