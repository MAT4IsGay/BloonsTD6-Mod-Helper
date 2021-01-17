using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using Assets.Scripts.Models.Towers.Projectiles;
using Assets.Scripts.Models.Towers.Weapons;
using Assets.Scripts.Unity;
using System.Collections.Generic;
using System.Linq;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class AttackModelExt
    {
        /// <summary>
        /// Not tested
        /// </summary>
        public static List<ProjectileModel> GetWeaponProjectiles(this AttackModel attackModel)
        {
            var weaponModels = attackModel.weapons;
            if (weaponModels is null)
                return null;

            var projectileModels = new List<ProjectileModel>();
            foreach (var weapon in weaponModels)
            {
                var projectile = weapon.projectile;
                if (projectile != null)
                    projectileModels.Add(weapon.projectile);
            }

            return projectileModels;
        }

        public static void AddWeapon(this AttackModel attackModel, WeaponModel weaponToAdd) => attackModel.weapons.Add(weaponToAdd);
    }
}