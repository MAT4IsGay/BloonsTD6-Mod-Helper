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
        /// Not Tested
        /// </summary>
        public static void SetMaxAmount(this TowerModel towerModel, int max)
        {
            towerModel.GetTowerDetailsModel().towerCount = max;
            Il2CppSystem.Collections.Generic.List<TowerDetailsModel> details = Game.instance?.model.GetAllTowerDetails();
            InGame.instance.GetTowerInventory().SetTowerMaxes(details);
        }

        public static TowerDetailsModel GetTowerDetailsModel(this TowerModel towerModel)
        {
            return Game.instance?.model?.GetAllTowerDetails()?.FirstOrDefault(tower => tower.towerId == towerModel.baseId);
        }

        public static TowerPurchaseButton GetTowerPurchaseButton(this TowerModel towerModel)
        {
            return ShopMenu.instance.GetTowerButtonFromBaseId(towerModel.baseId);
        }

        public static int? GetIndex(this TowerModel towerModel)
        {
            List<TowerDetailsModel> allTowers = Game.instance.model.towerSet.ToList();
            TowerDetailsModel detail = allTowers.FirstOrDefault(towerDetail => towerDetail.towerId == towerModel.baseId);
            return allTowers.IndexOf(detail);
        }

        public static int GetUpgradeLevel(this TowerModel towerModel, int path)
        {
            return towerModel.tiers[path];
        }

        public static bool? IsTowerUnlocked(this TowerModel towerModel)
        {
            return Game.instance?.GetBtd6Player()?.HasUnlockedTower(towerModel.baseId);
        }

        public static bool? IsHeroUnlocked(this TowerModel towerModel)
        {
            return Game.instance?.GetBtd6Player()?.HasUnlockedHero(towerModel.baseId);
        }

        public static bool? IsUpgradeUnlocked(this TowerModel towerModel, int path, int tier)
        {
            UpgradeModel upgradeModel = towerModel.GetUpgrade(path, tier);
            return Game.instance?.GetBtd6Player()?.HasUpgrade(upgradeModel?.name);
        }

        public static bool IsUpgradePathUsed(this TowerModel towerModel, int path)
        {
            UpgradeModel result = towerModel.GetAppliedUpgrades().FirstOrDefault(upgrade => upgrade.path == path);
            return result != null;
        }

        public static bool HasUpgrade(this TowerModel towerModel, int path, int tier)
        {
            return HasUpgrade(towerModel, towerModel.GetUpgrade(path, tier));
        }

        public static bool HasUpgrade(this TowerModel towerModel, UpgradeModel upgradeModel)
        {
            return towerModel.GetAppliedUpgrades().Contains(upgradeModel);
        }

        public static List<UpgradeModel> GetAppliedUpgrades(this TowerModel towerModel)
        {
            List<UpgradeModel> appliedUpgrades = new List<UpgradeModel>();

            foreach (string upgrade in towerModel.appliedUpgrades)
                appliedUpgrades.Add(Game.instance?.model?.upgradesByName[upgrade]);

            return appliedUpgrades;
        }

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

        public static List<TowerToSimulation> GetTowerSims(this TowerModel towerModel)
        {
            Il2CppSystem.Collections.Generic.List<TowerToSimulation> towers = InGame.instance?.bridge?.GetAllTowers();
            if (towers is null || !towers.Any())
                return null;

            List<TowerToSimulation> desiredTowers = towers.Where(towerSim => towerSim.tower.towerModel.name == towerModel.name).ToSystemList();
            return desiredTowers;
        }

        public static HeroModel GetHeroModel(this TowerModel towerModel)
        {
            return towerModel.GetBehavior<HeroModel>();
        }

        public static List<AbilityModel> GetAbilites(this TowerModel towerModel)
        {
            return towerModel.GetBehaviors<AbilityModel>();
        }

        public static List<AttackModel> GetAttackModels(this TowerModel towerModel)
        {
            return towerModel.GetBehaviors<AttackModel>();
        }

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

        // Thanks to doombubbles for creating this
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