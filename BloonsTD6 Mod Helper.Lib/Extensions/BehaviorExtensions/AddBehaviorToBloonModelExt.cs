using Assets.Scripts.Models;
using Assets.Scripts.Models.Bloons;
using Assets.Scripts.Models.Towers.Behaviors.Abilities;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using System.Collections.Generic;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class AddBehaviorToBloonModelExt
    {
        public static bool HasBehavior<T>(this AddBehaviorToBloonModel model) where T : Model
        {
            return model.behaviors.HasItemsOfType<BloonBehaviorModel, T>();
        }

        public static T GetBehavior<T>(this AddBehaviorToBloonModel model) where T : Model
        {
            return model.behaviors.GetItemOfType<BloonBehaviorModel, T>();
        }

        public static List<T> GetBehaviors<T>(this AddBehaviorToBloonModel model) where T : Model
        {
            return model.behaviors.GetItemsOfType<BloonBehaviorModel, T>();
        }

        public static void AddBehavior<T>(this AddBehaviorToBloonModel model, T behavior) where T : BloonBehaviorModel
        {
            model.behaviors = model.behaviors.Add(behavior);
        }

        public static void RemoveBehavior<T>(this AddBehaviorToBloonModel model) where T : Model
        {
            model.behaviors = model.behaviors.RemoveItemOfType<BloonBehaviorModel, T>();
        }

        public static void RemoveBehavior<T>(this AddBehaviorToBloonModel model, T behavior) where T : Model
        {
            model.behaviors = model.behaviors.Remove(behavior);
        }

        public static void RemoveBehaviors<T>(this AddBehaviorToBloonModel model) where T : Model
        {
            model.behaviors = model.behaviors.RemoveItemsOfType<BloonBehaviorModel, T>();
        }
    }
}
