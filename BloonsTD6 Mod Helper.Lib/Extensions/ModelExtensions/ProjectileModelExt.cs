using Assets.Scripts.Models.Towers.Projectiles;
using Assets.Scripts.Simulation.Towers.Projectiles;
using Assets.Scripts.Unity.UI_New.InGame;
using System.Collections.Generic;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class ProjectileModelExt
    {
        public static List<Projectile> GetAbilitySims(this ProjectileModel projectileModel)
        {
            var projectileSims = InGame.instance?.bridge?.GetAllProjectiles();
            if (projectileSims is null || projectileSims.Count == 0)
                return null;

            var results = projectileSims.Where(projectile => projectile.projectileModel.name == projectileModel.name).ToSystemList();
            return results;
        }
    }
}
