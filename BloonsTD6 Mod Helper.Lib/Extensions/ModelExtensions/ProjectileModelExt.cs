using Assets.Scripts.Models.Towers.Projectiles;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using Assets.Scripts.Simulation.Towers.Projectiles;
using Assets.Scripts.Unity.UI_New.InGame;
using System.Collections.Generic;
using Assets.Scripts.Models.Towers.Filters;
using UnhollowerBaseLib;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class ProjectileModelExt
    {
        /// <summary>
        /// Get the DamageModel behavior from the list of behaviors
        /// </summary>
        public static DamageModel GetDamageModel(this ProjectileModel projectileModel)
        {
            return projectileModel.GetBehavior<DamageModel>();
        }

        /// <summary>
        /// Get all Projectile Simulations that have this ProjectileModel
        /// </summary>
        public static List<Projectile> GetProjectileSims(this ProjectileModel projectileModel)
        {
            Il2CppSystem.Collections.Generic.List<Projectile> projectileSims =
                InGame.instance?.bridge?.GetAllProjectiles();
            if (projectileSims is null || !projectileSims.Any())
                return null;

            List<Projectile> results = projectileSims
                .Where(projectile => projectile.projectileModel.name == projectileModel.name).ToSystemList();
            return results;
        }

        public static bool CanHitCamo(this ProjectileModel projectileModel)
        {
            var projectileFilterModel = projectileModel.GetBehavior<ProjectileFilterModel>();
            var filterInvisibleModel =
                projectileFilterModel?.filters.GetItemOfType<FilterModel, FilterInvisibleModel>();
            if (filterInvisibleModel != null)
            {
                return !filterInvisibleModel.isActive;
            }

            return true;
        }

        public static void SetHitCamo(this ProjectileModel projectileModel, bool canHitCamo)
        {
            var projectileFilterModel = projectileModel.GetBehavior<ProjectileFilterModel>();
            if (projectileFilterModel == null)
            {
                projectileModel.AddBehavior(new ProjectileFilterModel("ProjectileFilterModel_" + projectileModel.name,
                    new Il2CppReferenceArray<FilterModel>(new FilterModel[]
                        {new FilterInvisibleModel("FilterInvisibleModel_", !canHitCamo, false)})));
            }
            else
            {
                var filterInvisibleModel =
                    projectileFilterModel.filters.GetItemOfType<FilterModel, FilterInvisibleModel>();
                if (filterInvisibleModel == null)
                {
                    projectileFilterModel.filters =
                        projectileFilterModel.filters.AddTo(new FilterInvisibleModel("FilterInvisibleModel_",
                            !canHitCamo, false));
                }
                else
                {
                    filterInvisibleModel.isActive = !canHitCamo;
                }
            }
        }
    }
}