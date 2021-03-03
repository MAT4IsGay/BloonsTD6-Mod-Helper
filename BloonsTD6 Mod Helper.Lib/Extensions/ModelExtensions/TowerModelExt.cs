using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors;
using Assets.Scripts.Models.Towers.Behaviors.Abilities;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using Assets.Scripts.Models.Towers.Projectiles;
using Assets.Scripts.Models.Towers.Upgrades;
using Assets.Scripts.Models.Towers.Weapons;
using Assets.Scripts.Models.TowerSets;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.Bridge;
using Assets.Scripts.Unity.UI_New.InGame;
using Assets.Scripts.Unity.UI_New.InGame.RightMenu;
using Assets.Scripts.Unity.UI_New.InGame.StoreMenu;
using System.Collections.Generic;
using System.Linq;
using UnhollowerBaseLib;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class TowerModelExt
    {
        /// <summary>
        /// Not Tested. Use to set the maximum allowed number of this tower
        /// </summary>
        public static void SetMaxAmount(this TowerModel towerModel, int max)
        {
            towerModel.GetTowerDetailsModel().towerCount = max;
            Il2CppSystem.Collections.Generic.List<TowerDetailsModel> details = Game.instance?.model.GetAllTowerDetails();
            InGame.instance.GetTowerInventory().SetTowerMaxes(details);
        }

        /// <summary>
        /// Get all TowerDetailModels that share a base id with this towerModel
        /// </summary>
        public static TowerDetailsModel GetTowerDetailsModel(this TowerModel towerModel)
        {
            return Game.instance?.model?.GetAllTowerDetails()?.FirstOrDefault(tower => tower.towerId == towerModel.baseId);
        }

        /// <summary>
        /// Get the TowerPurchaseButton for this TowerModel.
        /// </summary>
        public static TowerPurchaseButton GetTowerPurchaseButton(this TowerModel towerModel)
        {
            return ShopMenu.instance.GetTowerButtonFromBaseId(towerModel.baseId);
        }

        /// <summary>
        /// Get the number position of this TowerModel in the list of all tower models
        /// </summary>
        public static int? GetIndex(this TowerModel towerModel)
        {
            List<TowerDetailsModel> allTowers = Game.instance.model.towerSet.ToList();
            TowerDetailsModel detail = allTowers.FirstOrDefault(towerDetail => towerDetail.towerId == towerModel.baseId);
            return allTowers.IndexOf(detail);
        }

        /// <summary>
        /// Get the current upgrade level of a specific path
        /// </summary>
        /// <param name="path">What tier of upgrade is currently applied to tower</param>
        public static int GetUpgradeLevel(this TowerModel towerModel, int path)
        {
            return towerModel.tiers[path];
        }

        /// <summary>
        /// Has player already unlocked this TowerModel
        /// </summary>
        public static bool? IsTowerUnlocked(this TowerModel towerModel)
        {
            return Game.instance?.GetBtd6Player()?.HasUnlockedTower(towerModel.baseId);
        }

        /// <summary>
        /// If this TowerModel is for a Hero, is this Hero unlocked?
        /// </summary>
        public static bool? IsHeroUnlocked(this TowerModel towerModel)
        {
            return Game.instance?.GetBtd6Player()?.HasUnlockedHero(towerModel.baseId);
        }

        /// <summary>
        /// Has a specific upgrade for this TowerModel been unlocked already?
        /// </summary>
        /// <param name="path">Upgrade path</param>
        /// <param name="tier">Tier of upgrade</param>
        public static bool? IsUpgradeUnlocked(this TowerModel towerModel, int path, int tier)
        {
            UpgradeModel upgradeModel = towerModel.GetUpgrade(path, tier);
            return Game.instance?.GetBtd6Player()?.HasUpgrade(upgradeModel?.name);
        }

        /// <summary>
        /// Check if a specific upgrade path is being used/ has any upgrades applied to it
        /// </summary>
        /// <param name="path">Upgrade path to check</param>
        public static bool IsUpgradePathUsed(this TowerModel towerModel, int path)
        {
            UpgradeModel result = towerModel.GetAppliedUpgrades().FirstOrDefault(upgrade => upgrade.path == path);
            return result != null;
        }

        /// <summary>
        /// Check if an upgrade has been applied
        /// </summary>
        /// <param name="path"></param>
        /// <param name="tier"></param>
        public static bool HasUpgrade(this TowerModel towerModel, int path, int tier)
        {
            return HasUpgrade(towerModel, towerModel.GetUpgrade(path, tier));
        }

        /// <summary>
        /// Check if an upgrade has been applied
        /// </summary>
        /// <param name="upgradeModel"></param>
        /// <returns></returns>
        public static bool HasUpgrade(this TowerModel towerModel, UpgradeModel upgradeModel)
        {
            return towerModel.GetAppliedUpgrades().Contains(upgradeModel);
        }

        /// <summary>
        /// Get all UpgradeModels that are currently applied to this TowerModel
        /// </summary>
        public static List<UpgradeModel> GetAppliedUpgrades(this TowerModel towerModel)
        {
            List<UpgradeModel> appliedUpgrades = new List<UpgradeModel>();

            foreach (string upgrade in towerModel.appliedUpgrades)
                appliedUpgrades.Add(Game.instance?.model?.upgradesByName[upgrade]);

            return appliedUpgrades;
        }

        /// <summary>
        /// Get the UpgradeModel for a specific upgrade path/tier
        /// </summary>
        /// <param name="path"></param>
        /// <param name="tier"></param>
        public static UpgradeModel GetUpgrade(this TowerModel towerModel, int path, int tier)
        {
            if (path < 0 || tier < 0)
                return null;

            int tier1 = (path == 0) ? tier : 0;
            int tier2 = (path == 1) ? tier : 0;
            int tier3 = (path == 2) ? tier : 0;

            TowerModel tempTower = Game.instance?.model?.GetTower(towerModel.baseId, tier1, tier2, tier3);
            if (tempTower is null)
                return null;

            const int offset = 1;
            List<UpgradeModel> appliedUpgrades = tempTower.GetAppliedUpgrades();
            UpgradeModel results = appliedUpgrades.FirstOrDefault(model => model.path == path && model.tier == (tier - offset));

            return null;
        }

        /// <summary>
        /// Get all TowerToSimulations with this TowerModel
        /// </summary>
        public static List<TowerToSimulation> GetTowerSims(this TowerModel towerModel)
        {
            Il2CppSystem.Collections.Generic.List<TowerToSimulation> towers = InGame.instance?.bridge?.GetAllTowers();
            if (towers is null || !towers.Any())
                return null;

            List<TowerToSimulation> desiredTowers = towers.Where(towerSim => towerSim.tower.towerModel.name == towerModel.name).ToSystemList();
            return desiredTowers;
        }

        /// <summary>
        /// If this TowerModel is a Hero, get the HeroModel behavior
        /// </summary>
        /// <param name="towerModel"></param>
        /// <returns></returns>
        public static HeroModel GetHeroModel(this TowerModel towerModel)
        {
            return towerModel.GetBehavior<HeroModel>();
        }

        /// <summary>
        /// Get all AbilityModel behaviors from this tower, if it has any
        /// </summary>
        public static List<AbilityModel> GetAbilites(this TowerModel towerModel)
        {
            return towerModel.GetBehaviors<AbilityModel>();
        }
        
        /// <summary>
        /// Get a specific Ability of the tower. By default will get the first ability
        /// </summary>
        /// <param name="index">Index of the ability you want. Default is first ability</param>
        public static AbilityModel GetAbility(this TowerModel towerModel, int index = 0)
        {
            return towerModel.GetAbilites()[index];
        }

        /// <summary>
        /// Get all AttackModel behaviors for this TowerModel
        /// </summary>
        public static List<AttackModel> GetAttackModels(this TowerModel towerModel)
        {
            return towerModel.GetBehaviors<AttackModel>();
        }

        /// <summary>
        /// Get one of the AttackModels from this TowerModel. By default will give the first AttackModel
        /// </summary>
        /// <param name="index">Index of the AttackModel you want</param>
        public static AttackModel GetAttackModel(this TowerModel towerModel, int index = 0)
        {
            return towerModel.GetAttackModels()[index];
        }

        /// <summary>
        /// Recursively get every WeaponModels this TowerModel has
        /// </summary>
        public static List<WeaponModel> GetWeapons(this TowerModel towerModel)
        {
            List<AttackModel> attackModels = towerModel.GetAttackModels();
            if (attackModels is null)
                return null;

            if (!attackModels.Any())
                return new List<WeaponModel>();

            List<WeaponModel> weaponModels = new List<WeaponModel>();
            foreach (AttackModel attackModel in attackModels)
            {
                Il2CppReferenceArray<WeaponModel> weapons = attackModel.weapons;
                if (weapons != null)
                    weaponModels.AddRange(weapons);
            }

            return weaponModels;
        }

        /// <summary>
        /// Get one of the WeaponModels this TowerModel has. By default will return the first one
        /// </summary>
        /// <param name="index">Index of WeaponModel that you want</param>
        public static WeaponModel GetWeapon(this TowerModel towerModel, int index = 0)
        {
            return towerModel.GetWeapons()[index];
        }

        // Thanks to doombubbles for creating this
        /// <summary>
        /// Get every ProjectileModels this TowerModel has
        /// </summary>
        public static List<ProjectileModel> GetAllProjectiles(this TowerModel towerModel)
        {
            List<ProjectileModel> allProjectiles = new List<ProjectileModel>();
            foreach (AttackModel attackModel in towerModel.GetAttackModels())
            {
                allProjectiles.AddRange(attackModel.GetAllProjectiles());
            }

            return allProjectiles;
        }
    }
}