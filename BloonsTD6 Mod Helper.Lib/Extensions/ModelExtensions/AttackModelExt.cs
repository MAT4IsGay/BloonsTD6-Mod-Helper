using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using Assets.Scripts.Models.Towers.Projectiles;
using Assets.Scripts.Models.Towers.Weapons;
using Assets.Scripts.Unity;
using System.Collections.Generic;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class AttackModelExt
    {
        public static List<WeaponModel> GetWeaponModels(this AttackModel attackModel) => attackModel.GetBehaviors<WeaponModel>();

        public static List<ProjectileModel> GetWeaponProjectiles(this AttackModel attackModel)
        {
            List<ProjectileModel> projectileModels = new List<ProjectileModel>();
            var weaponModels = attackModel.GetWeaponModels();
            foreach (var weapon in weaponModels)
                projectileModels.Add(weapon.projectile);

            return projectileModels;
        }

        public static List<TowerModel> GetTowersWithThisAttackModel(this AttackModel attackModel)
        {
            List<TowerModel> towerModels = new List<TowerModel>();
            foreach (var towerModel in Game.instance.model.towers)
            {
                var attackModels = towerModel.GetBehaviors<AttackModel>();
                bool hasAttackModel = attackModels.Contains(attackModel);
                if (hasAttackModel)
                    towerModels.Add(towerModel);
            }

            return towerModels;
        }
    }
}