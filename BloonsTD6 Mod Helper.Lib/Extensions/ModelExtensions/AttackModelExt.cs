using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using Assets.Scripts.Models.Towers.Projectiles;
using Assets.Scripts.Models.Towers.Weapons;
using System.Collections.Generic;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class AttackModelExt
    {
        // Thanks to doombubbles for creating this
        public static List<ProjectileModel> GetAllProjectiles(this AttackModel attackModel)
        {
            List<ProjectileModel> allProjectiles = new List<ProjectileModel>();
            foreach (WeaponModel weaponModel in attackModel.weapons)
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

            if (behaviors is null)
                return allProjectiles;

            foreach (Model behavior in behaviors)
            {
                Il2CppSystem.Reflection.FieldInfo projectileField = behavior.TypeInfo.GetField("projectile");
                if (projectileField == null) // this is new
                {
                    projectileField = behavior.TypeInfo.GetField("projectileModel");
                }
                if (projectileField != null)
                {
                    ProjectileModel projectileModel = projectileField.GetValue(behavior).Cast<ProjectileModel>();
                    if (projectileModel != null)
                    {
                        allProjectiles.Add(projectileModel);
                        allProjectiles.AddRange(GetSubProjectiles(projectileModel.behaviors));
                    }
                }
            }
            return allProjectiles;
        }

        public static void AddWeapon(this AttackModel attackModel, WeaponModel weaponToAdd)
        {
            attackModel.weapons = attackModel.weapons.AddTo(weaponToAdd);
        }
    }
}