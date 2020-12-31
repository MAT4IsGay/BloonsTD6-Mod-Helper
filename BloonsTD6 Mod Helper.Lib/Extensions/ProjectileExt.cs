using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers.Projectiles;
using System;
using System.Linq;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class ProjectileExt
    {
        public static T GetBehavior<T>(this ProjectileModel projectileBehaviors) where T : Model
        {
            var behaviors = projectileBehaviors.behaviors;
            if (projectileBehaviors.behaviors is null || projectileBehaviors.behaviors.Count == 0)
                return null;

            var result = behaviors.FirstOrDefault(behavior => behavior.name.Contains(typeof(T).Name));

            return result.TryCast<T>();
        }

        public static bool HasBehavior<T>(this ProjectileModel projectileBehaviors) where T : Model
        {
            if (projectileBehaviors.behaviors == null || projectileBehaviors.behaviors.Count == 0)
                return false;

            try { var result = projectileBehaviors.behaviors.First(item => item.name.Contains(typeof(T).Name)); }
            catch (Exception) { return false; }

            return true;
        }
    }
}
