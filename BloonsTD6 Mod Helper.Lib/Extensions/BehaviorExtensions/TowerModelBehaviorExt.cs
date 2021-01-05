﻿using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers;
using System.Collections.Generic;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class TowerModelBehaviorExt
    {
        public static bool HasBehavior<T>(this TowerModel model) where T : Model
        {
            return model.behaviors.HasItemsOfType<Model, T>();
        }

        public static T GetBehavior<T>(this TowerModel model) where T : Model
        {
            return model.behaviors.GetItemOfType<Model, T>();
        }

        public static List<T> GetBehaviors<T>(this TowerModel model) where T : Model
        {
            return model.behaviors.GetItemsOfType<Model, T>();
        }

        public static void AddBehavior<T>(this TowerModel model, T behavior) where T : Model
        {
            model.behaviors = model.behaviors.Add(behavior);
        }

        public static void RemoveBehavior<T>(this TowerModel model) where T : Model
        {
            model.behaviors = model.behaviors.RemoveItemOfType<Model, T>();
        }

        public static void RemoveBehavior<T>(this TowerModel model, T behavior) where T : Model
        {
            model.behaviors = model.behaviors.Remove(behavior);
        }

        public static void RemoveBehaviors<T>(this TowerModel model) where T : Model
        {
            model.behaviors = model.behaviors.RemoveItemsOfType<Model, T>();
        }
    }
}
