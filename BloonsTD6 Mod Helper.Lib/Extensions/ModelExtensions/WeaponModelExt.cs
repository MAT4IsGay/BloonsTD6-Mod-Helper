using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Weapons;
using Assets.Scripts.Unity;
using System.Collections.Generic;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class WeaponModelExt
    {
        public static List<TowerModel> GetTowersWithThisWeapon(this WeaponModel weaponModel)
        {
            List<TowerModel> towerModels = new List<TowerModel>();
            foreach (var towerModel in Game.instance.model.towers)
            {
                var weaponModels = towerModel.GetWeaponModels();
                bool hasWeaponModel = weaponModels.Contains(weaponModel);
                if (hasWeaponModel)
                    towerModels.Add(towerModel);
            }

            return towerModels;
        }

        public static List<TowerModel> GetAttackModelsWithThisWeapon(this WeaponModel weaponModel)
        {
            List<TowerModel> towerModels = new List<TowerModel>();
            foreach (var towerModel in Game.instance.model.towers)
            {
                var weaponModels = towerModel.GetWeaponModels();
                bool hasWeaponModel = weaponModels.Contains(weaponModel);
                if (hasWeaponModel)
                    towerModels.Add(towerModel);
            }

            return towerModels;
        }
    }
}