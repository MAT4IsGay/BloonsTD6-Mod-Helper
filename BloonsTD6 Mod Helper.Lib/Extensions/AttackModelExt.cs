using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using System.Linq;
using UnhollowerBaseLib;
using BloonsTD6_Mod_Helper.Api.Utils;
using MelonLoader;
using System;
using Assets.Scripts.Models.GenericBehaviors;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class AttackModelExt
    {
        public static bool HasBehavior<T>(this AttackModel attackModel) where T : Model
        {
            if (attackModel.behaviors == null || attackModel.behaviors.Count == 0)
                return false;

            try { var result = attackModel.behaviors.First(item => item.name.Contains(typeof(T).Name)); }
            catch (Exception) { return false; }

            return true;
        }

        public static T GetBehavior<T>(this AttackModel attackModel) where T : Model
        {
            var behaviors = attackModel.behaviors;
            if (attackModel.behaviors is null || attackModel.behaviors.Count == 0)
                return null;

            var result = behaviors.FirstOrDefault(behavior => behavior.name.Contains(typeof(T).Name));

            return result.TryCast<T>();
        }

        public static void AddBehavior<T>(this AttackModel attackModel, T behavior) where T : Model
        {
            var behaviors = attackModel.behaviors;
            Il2CppUtils.Add(ref behaviors, behavior);
            attackModel.behaviors = behaviors;
        }

        public static void RemoveBehavior<T>(this AttackModel attackModel) where T : Model
        {
            while (attackModel.HasBehavior<T>())
                attackModel.RemoveBehavior(attackModel.GetBehavior<T>());
        }

        public static void RemoveBehavior<T>(this AttackModel attackModel, T behavior) where T : Model
        {
            if (!attackModel.HasBehavior<T>())
                return;

            bool foundItem = false;
            var behaviors = attackModel.behaviors;
            attackModel.behaviors = new Il2CppReferenceArray<Model>(behaviors.Length - 1);

            for (int i = 0; i < behaviors.Length; i++)
            {
                var item = behaviors[i];
                if (item.name == behavior.name)
                {
                    foundItem = true;
                    continue;
                }

                int index = (foundItem) ? i - 1 : i;
                attackModel.behaviors[index] = item;
            }
        }
    }
}