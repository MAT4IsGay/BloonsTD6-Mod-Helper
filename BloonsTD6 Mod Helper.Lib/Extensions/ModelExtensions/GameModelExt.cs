using Assets.Scripts.Models;
using Assets.Scripts.Models.Bloons;
using Assets.Scripts.Models.Rounds;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors.Abilities;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using Assets.Scripts.Models.Towers.Projectiles;
using Assets.Scripts.Models.Towers.Weapons;
using Assets.Scripts.Models.TowerSets;
using BloonsTD6_Mod_Helper.Api.Builders;
using BloonsTD6_Mod_Helper.Patches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnhollowerBaseLib;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class GameModelExt
    {
        public static BloonModelBuilder GetBloonModelBuilder(this GameModel model) => BloonModelBuilder.Instance;
     
        public static Il2CppSystem.Collections.Generic.List<TowerDetailsModel> GetAllTowerDetails(this GameModel model)
        {
            return TowerInventory_Init.allTowers;
        }

        public static Il2CppSystem.Collections.Generic.List<ShopTowerDetailsModel> GetAllShopTowerDetails(this GameModel model)
        {
            var towerDetails = model.GetAllTowerDetails();
            var results = towerDetails.Where(detail => detail.GetShopTowerDetails() != null);
            return results.CloneAs<TowerDetailsModel, ShopTowerDetailsModel>();
        }

        public static BloonModel GetBloonModel(this GameModel model, string bloonName)
        {
            return model.bloons?.FirstOrDefault(bloon => bloon.name == bloonName);
        }

        public static List<TowerModel> GetTowerModels(this GameModel model, string towerBaseId)
        {
            return model.towers?.Where(t => t.baseId == towerBaseId).ToList();
        }


        public static Il2CppReferenceArray<BloonEmissionModel> CreateBloonEmissionModel(this GameModel model, BloonModel bloonModel, int number, float spacing)
        {
            return model.CreateBloonEmissionModel(bloonModel.name, number, spacing);
        }

        public static Il2CppReferenceArray<BloonEmissionModel> CreateBloonEmissionModel(this GameModel model, string bloonName, int number, float spacing)
        {
            var bloonEmissionModels = new List<BloonEmissionModel>();

            for (int i = 0; i < number; i++)
                bloonEmissionModels.Add(new BloonEmissionModel(bloonName, (spacing * i), bloonName));

            return bloonEmissionModels.ToIl2CppReferenceArray();
        }

        public static List<AttackModel> GetAllAttackModels(this GameModel model)
        {
            var attackModels = new List<AttackModel>();
            var towers = model.towers;

            foreach (var tower in towers)
            {
                var attacks = tower.GetAttackModels();
                if (attacks != null && attacks.Count > 0)
                    attackModels.AddRange(attacks);
            }

            return attackModels;
        }

        public static List<WeaponModel> GetAllWeaponModels(this GameModel model)
        {
            var weaponModels = new List<WeaponModel>();
            var attackModels = model.GetAllAttackModels();

            foreach (var attackModel in attackModels)
            {
                var weapons = attackModel.weapons;
                if (weapons != null && weapons.Count > 0)
                    weaponModels.AddRange(weapons);
            }

            return weaponModels;
        }

        public static List<ProjectileModel> GetAllProjectileModels(this GameModel model)
        {
            var projectileModels = new List<ProjectileModel>();
            var weaponModels = model.GetAllWeaponModels();

            foreach (var weaponModel in weaponModels)
            {
                if (weaponModel.projectile != null)
                    projectileModels.Add(weaponModel.projectile);
            }

            return projectileModels;
        }

        public static List<AbilityModel> GetAllAbilityModels(this GameModel model)
        {
            var abilityModels = new List<AbilityModel>();
            var towers = model.towers;

            foreach (var tower in towers)
            {
                var abilities = tower.GetAbilites();
                if (abilities != null && abilities.Count >0)
                    abilityModels.AddRange(abilities);
            }

            return abilityModels;
        }

        public static List<TowerModel> GetTowerModelsWithAbilities(this GameModel model)
        {
            return model.towers.Where(t => t.GetAbilites() != null).ToList();
        }
    }
}