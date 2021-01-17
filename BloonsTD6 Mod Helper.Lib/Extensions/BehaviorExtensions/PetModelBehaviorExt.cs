using Assets.Scripts.Models;
using Assets.Scripts.Models.Pets;
using System.Collections.Generic;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class PetModelBehaviorExt
    {
        public static bool HasBehavior<T>(this PetModel model) where T : Model
        {
            if (model.behaviors is null)
                return false;

            return model.behaviors.HasItemsOfType<PetBehaviorModel, T>();
        }

        public static T GetBehavior<T>(this PetModel model) where T : Model
        {
            if (model.behaviors is null)
                return default;

            return model.behaviors.GetItemOfType<PetBehaviorModel, T>();
        }

        public static List<T> GetBehaviors<T>(this PetModel model) where T : Model
        {
            if (model.behaviors is null)
                return null;

            return model.behaviors.GetItemsOfType<PetBehaviorModel, T>();
        }

        public static void AddBehavior<T>(this PetModel model, T behavior) where T : PetBehaviorModel
        {
            if (model.behaviors is null)
                return;

            model.behaviors = model.behaviors.Add(behavior);
        }

        public static void RemoveBehavior<T>(this PetModel model) where T : Model
        {
            if (model.behaviors is null)
                return;

            model.behaviors = model.behaviors.RemoveItemOfType<PetBehaviorModel, T>();
        }

        public static void RemoveBehavior<T>(this PetModel model, T behavior) where T : Model
        {
            if (model.behaviors is null)
                return;

            model.behaviors = model.behaviors.Remove(behavior);
        }

        public static void RemoveBehaviors<T>(this PetModel model) where T : Model
        {
            if (model.behaviors is null)
                return;

            model.behaviors = model.behaviors.RemoveItemsOfType<PetBehaviorModel, T>();
        }
    }
}