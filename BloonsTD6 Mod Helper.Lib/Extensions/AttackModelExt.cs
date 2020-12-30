using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using System.Linq;
using UnhollowerBaseLib;
using BloonsTD6_Mod_Helper.Api.Utils;
using MelonLoader;
using System;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class AttackModelExt
    {
        public static bool HasBehavior<T>(this AttackModel attackModel) where T : AttackBehaviorModel
        {
            try { var result = attackModel.behaviors.First(item => item.name.Contains(typeof(T).Name)); }
            catch (InvalidOperationException) { return false; }

            return true;
        }

        public static T GetBehavior<T>(this AttackModel attackModel) where T : AttackBehaviorModel
        {
            var behaviors = attackModel.behaviors;
            if (attackModel.behaviors is null || attackModel.behaviors.Count == 0)
                return null;

            var result = behaviors.FirstOrDefault(behavior => behavior.name.Contains(typeof(T).Name));

            return result.TryCast<T>();
        }

        public static void AddBehavior<T>(this AttackModel attackModel, T behavior) where T : AttackBehaviorModel
        {
            attackModel.behaviors = Il2CppUtils.Add(attackModel.behaviors, behavior);
        }

        public static void RemoveBehavior<T>(this AttackModel attackModel) where T : AttackBehaviorModel
        {
            if (!attackModel.HasBehavior<T>())
                return;

            attackModel.RemoveBehavior(attackModel.GetBehavior<T>());
        }

        public static void RemoveBehavior<T>(this AttackModel attackModel, T behavior) where T : AttackBehaviorModel
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