using Assets.Scripts.Models;
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
        // Thanks to doombubbles for creating this
        public static List<ProjectileModel> GetAllProjectiles(this AttackModel attackModel)
        {
            List<ProjectileModel> allProjectiles = new List<ProjectileModel>();
            foreach (var weaponModel in attackModel.weapons)
            {
                if (weaponModel.projectile != null)
                {
                    allProjectiles.Add(weaponModel.projectile);
                    allProjectiles.AddRange(GetSubProjectiles(weaponModel.projectile.behaviors));
                }
                allProjectiles.AddRange(GetSubProjectiles(weaponModel.behaviors));
            }
            allProjectiles.AddRange(GetSubProjectiles(attackModel.behaviors)); //this is new
            return allProjectiles;
        }
        private static List<ProjectileModel> GetSubProjectiles(IEnumerable<Model> behaviors)
        {
            List<ProjectileModel> allProjectiles = new List<ProjectileModel>();
            foreach (var behavior in behaviors)
            {
                var projectileField = behavior.TypeInfo.GetField("projectile");
                if (projectileField == null) // this is new
                {
                    projectileField = behavior.TypeInfo.GetField("projectileModel");
                }
                if (projectileField != null)
                {
                    var projectileModel = projectileField.GetValue(behavior).Cast<ProjectileModel>();
                    if (projectileModel != null)
                    {
                        allProjectiles.Add(projectileModel);
                        allProjectiles.AddRange(GetSubProjectiles(projectileModel.behaviors));
                    }
                }
            }
            return allProjectiles;
        }

        public static void AddWeapon(this AttackModel attackModel, WeaponModel weaponToAdd) => 
            attackModel.weapons = attackModel.weapons.AddTo(weaponToAdd);
    }
}