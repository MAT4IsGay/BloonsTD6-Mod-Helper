using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using System.Collections.Generic;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class AttackModelBehaviorExt
    {
        public static bool HasBehavior<T>(this AttackModel model) where T : Model
        {
            if (model.behaviors is null)
                return false;

            return model.behaviors.HasItemsOfType<Model, T>();
        }

        public static T GetBehavior<T>(this AttackModel model) where T : Model
        {
            if (model.behaviors is null)
                return default;

            return model.behaviors.GetItemOfType<Model, T>();
        }

        public static List<T> GetBehaviors<T>(this AttackModel model) where T : Model
        {
            if (model.behaviors is null)
                return null;

            return model.behaviors.GetItemsOfType<Model, T>();
        }

        public static void AddBehavior<T>(this AttackModel model, T behavior) where T : Model
        {
            if (model.behaviors is null)
                return;

            model.behaviors = model.behaviors.Add(behavior);
        }

        public static void RemoveBehavior<T>(this AttackModel model) where T : Model
        {
            if (model.behaviors is null)
                return;

            model.behaviors = model.behaviors.RemoveItemOfType<Model, T>();
        }

        public static void RemoveBehavior<T>(this AttackModel model, T behavior) where T : Model
        {
            if (model.behaviors is null)
                return;

            model.behaviors = model.behaviors.Remove(behavior);
        }

        public static void RemoveBehaviors<T>(this AttackModel model) where T : Model
        {
            if (model.behaviors is null)
                return;

            model.behaviors = model.behaviors.RemoveItemsOfType<Model, T>();
        }
    }
}
