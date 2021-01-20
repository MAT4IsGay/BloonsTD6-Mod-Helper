using Assets.Scripts.Models.Towers.Projectiles;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using Assets.Scripts.Simulation.Towers.Projectiles;
using Assets.Scripts.Unity.UI_New.InGame;
using System.Collections.Generic;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class ProjectileModelExt
    {
        public static DamageModel GetDamageModel(this ProjectileModel projectileModel) => projectileModel.GetBehavior<DamageModel>();

        public static List<Projectile> GetProjectileSims(this ProjectileModel projectileModel)
        {
            var projectileSims = InGame.instance?.bridge?.GetAllProjectiles();
            if (projectileSims is null || !projectileSims.Any())
                return null;

            var results = projectileSims.Where(projectile => projectile.projectileModel.name == projectileModel.name).ToSystemList();
            return results;
        }
    }
}
