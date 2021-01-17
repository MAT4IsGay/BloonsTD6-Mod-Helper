﻿using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers.Behaviors.Abilities;
using System.Collections.Generic;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class AbilityModelBehaviorExt
    {
        public static bool HasBehavior<T>(this AbilityModel model) where T : Model
        {
            if (model.behaviors is null)
                return false;

            return model.behaviors.HasItemsOfType<Model, T>();
        }

        public static T GetBehavior<T>(this AbilityModel model) where T : Model
        {
            if (model.behaviors is null)
                return default;

            return model.behaviors.GetItemOfType<Model, T>();
        }

        public static List<T> GetBehaviors<T>(this AbilityModel model) where T : Model
        {
            if (model.behaviors is null)
                return null;

            return model.behaviors.GetItemsOfType<Model, T>();
        }

        public static void AddBehavior<T>(this AbilityModel model, T behavior) where T : Model
        {
            if (model.behaviors is null)
                return;

            model.behaviors = model.behaviors.Add(behavior);
        }

        public static void RemoveBehavior<T>(this AbilityModel model) where T : Model
        {
            if (model.behaviors is null)
                return;

            model.behaviors = model.behaviors.RemoveItemOfType<Model, T>();
        }

        public static void RemoveBehavior<T>(this AbilityModel model, T behavior) where T : Model
        {
            if (model.behaviors is null)
                return;

            model.behaviors = model.behaviors.Remove(behavior);
        }

        public static void RemoveBehaviors<T>(this AbilityModel model) where T : Model
        {
            if (model.behaviors is null)
                return;

            model.behaviors = model.behaviors.RemoveItemsOfType<Model, T>();
        }
    }
}
