using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers.Behaviors.Emissions;
using System.Collections.Generic;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class EmissionModelBehaviorExt
    {
        public static bool HasBehavior<T>(this EmissionModel model) where T : Model
        {
            if (model.behaviors is null)
                return false;

            return model.behaviors.HasItemsOfType<EmissionBehaviorModel, T>();
        }

        public static T GetBehavior<T>(this EmissionModel model) where T : Model
        {
            if (model.behaviors is null)
                return default;

            return model.behaviors.GetItemOfType<EmissionBehaviorModel, T>();
        }

        public static List<T> GetBehaviors<T>(this EmissionModel model) where T : Model
        {
            if (model.behaviors is null)
                return null;

            return model.behaviors.GetItemsOfType<EmissionBehaviorModel, T>();
        }

        public static void AddBehavior<T>(this EmissionModel model, T behavior) where T : EmissionBehaviorModel
        {
            if (model.behaviors is null)
                return;

            model.behaviors = model.behaviors.Add(behavior);
        }

        public static void RemoveBehavior<T>(this EmissionModel model) where T : Model
        {
            if (model.behaviors is null)
                return;

            model.behaviors = model.behaviors.RemoveItemOfType<EmissionBehaviorModel, T>();
        }

        public static void RemoveBehavior<T>(this EmissionModel model, T behavior) where T : Model
        {
            if (model.behaviors is null)
                return;

            model.behaviors = model.behaviors.Remove(behavior);
        }

        public static void RemoveBehaviors<T>(this EmissionModel model) where T : Model
        {
            if (model.behaviors is null)
                return;

            model.behaviors = model.behaviors.RemoveItemsOfType<EmissionBehaviorModel, T>();
        }
    }
}
