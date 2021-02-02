using Assets.Scripts.Models;
using Assets.Scripts.Models.Bloons;
using Assets.Scripts.Models.Rounds;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors.Abilities;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using Assets.Scripts.Models.Towers.Projectiles;
using Assets.Scripts.Models.Towers.Weapons;
using Assets.Scripts.Models.TowerSets;
using Assets.Scripts.Simulation.Bloons;
using Assets.Scripts.Simulation.Objects;
using BloonsTD6_Mod_Helper.Api.Builders;
using BloonsTD6_Mod_Helper.Patches;
using System.Collections.Generic;
using System.Linq;
using UnhollowerBaseLib;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class GameModelExt
    {
        public static BloonModelBuilder GetBloonModelBuilder(this GameModel model)
        {
            return BloonModelBuilder.Instance;
        }

        public static Il2CppSystem.Collections.Generic.List<TowerDetailsModel> GetAllTowerDetails(this GameModel model)
        {
            return TowerInventory_Init.allTowers;
        }

        public static Il2CppSystem.Collections.Generic.List<ShopTowerDetailsModel> GetAllShopTowerDetails(this GameModel model)
        {
            Il2CppSystem.Collections.Generic.List<TowerDetailsModel> towerDetails = model.GetAllTowerDetails();
            Il2CppSystem.Collections.Generic.List<TowerDetailsModel> results = towerDetails.Where(detail => detail.GetShopTowerDetails() != null);
            return results.DuplicateAs<TowerDetailsModel, ShopTowerDetailsModel>();
        }

        public static BloonModel GetBloonModel(this GameModel model, string bloonName)
        {
            return model.bloons?.FirstOrDefault(bloon => bloon.name == bloonName);
        }

        public static List<TowerModel> GetTowerModels(this GameModel model, string towerBaseId)
        {
            return model.towers?.Where(t => t.baseId == towerBaseId).ToList();
        }

        public static TowerModel GetTowerModel(this GameModel model, TowerType towerType, int path1 = 0, int path2 = 0, int path3 = 0)
        {
            return model.GetTower(towerType.ToString(), path1, path2, path3);
        }

        public static Il2CppReferenceArray<BloonEmissionModel> CreateBloonEmissions(this GameModel model, BloonModel bloonModel, int number, float spacing)
        {
            return model.CreateBloonEmissions(bloonModel.name, number, spacing);
        }

        public static Il2CppReferenceArray<BloonEmissionModel> CreateBloonEmissions(this GameModel model, string bloonName, int number, float spacing)
        {
            List<BloonEmissionModel> bloonEmissionModels = new List<BloonEmissionModel>();

            for (int i = 0; i < number; i++)
                bloonEmissionModels.Add(model.CreateBloonEmission(bloonName, time: spacing * i));

            return bloonEmissionModels.ToIl2CppReferenceArray();
        }

        public static BloonEmissionModel CreateBloonEmission(this GameModel model, string bloonName, float time)
        {
            return new BloonEmissionModel("", time, bloonName);
        }

        public static BloonEmissionModel CreateBloonEmission(this GameModel model, string bloonName, float time,
           Il2CppSystem.Collections.Generic.List<Bloon.ChargedMutator> chargedMutators, Il2CppSystem.Collections.Generic.List<BehaviorMutator> behaviorMutators)
        {
            return new BloonEmissionModel("", time, bloonName, chargedMutators, behaviorMutators);
        }

        public static BloonGroupModel CreateBloonGroup(this GameModel model, string bloonName, float startTime, float spacing, int count)
        {
            float endTime = startTime + (spacing * count);
            return new BloonGroupModel("", bloonName, startTime, endTime, count);
        }


        public static List<AttackModel> GetAllAttackModels(this GameModel model)
        {
            List<AttackModel> attackModels = new List<AttackModel>();
            Il2CppReferenceArray<TowerModel> towers = model.towers;

            foreach (TowerModel tower in towers)
            {
                List<AttackModel> attacks = tower.GetAttackModels();
                if (attacks != null && attacks.Any())
                    attackModels.AddRange(attacks);
            }

            return attackModels;
        }

        public static List<WeaponModel> GetAllWeaponModels(this GameModel model)
        {
            List<WeaponModel> weaponModels = new List<WeaponModel>();
            List<AttackModel> attackModels = model.GetAllAttackModels();

            foreach (AttackModel attackModel in attackModels)
            {
                Il2CppReferenceArray<WeaponModel> weapons = attackModel.weapons;
                if (weapons != null && weapons.Any())
                    weaponModels.AddRange(weapons);
            }

            return weaponModels;
        }

        public static List<ProjectileModel> GetAllProjectileModels(this GameModel model)
        {
            List<ProjectileModel> projectileModels = new List<ProjectileModel>();
            Il2CppReferenceArray<TowerModel> towerModels = model.towers;

            foreach (TowerModel towerModel in towerModels)
                projectileModels.AddRange(towerModel.GetAllProjectiles());

            return projectileModels;
        }

        public static List<AbilityModel> GetAllAbilityModels(this GameModel model)
        {
            List<AbilityModel> abilityModels = new List<AbilityModel>();
            Il2CppReferenceArray<TowerModel> towers = model.towers;

            foreach (TowerModel tower in towers)
            {
                List<AbilityModel> abilities = tower.GetAbilites();
                if (abilities != null && abilities.Any())
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