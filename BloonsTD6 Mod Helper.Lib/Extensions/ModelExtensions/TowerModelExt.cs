using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using Assets.Scripts.Models.Towers.Mods;
using Assets.Scripts.Models.Towers.Upgrades;
using Assets.Scripts.Models.TowerSets;
using Assets.Scripts.Simulation.Towers.Behaviors.Attack;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.Bridge;
using Assets.Scripts.Unity.UI_New.InGame;
using Assets.Scripts.Unity.UI_New.InGame.RightMenu;
using Assets.Scripts.Unity.UI_New.InGame.StoreMenu;
using BloonsTD6_Mod_Helper.Api.Utils;
using MelonLoader;
using System;
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
            var details = Game.instance?.GetTowerDetailModels().TryCast<Il2CppSystem.Collections.Generic.List<TowerDetailsModel>>();
            InGame.instance?.GetTowerInventory(0).SetTowerMaxes(details);
        }

        public static TowerDetailsModel GetTowerDetailsModel(this TowerModel towerModel)
        {
            return Game.instance?.model?.towerSet?.FirstOrDefault(tower => tower.towerId == towerModel.baseId);
        }

        public static TowerPurchaseButton GetTowerPurchaseButton(this TowerModel towerModel)
        {
            var allButtons = ShopMenu.instance.towerPurchaseButtons;
            var result = allButtons.ToArray().FirstOrDefault(a => a.TryCast<TowerPurchaseButton>()?.baseTowerModel == towerModel);
            return result.TryCast<TowerPurchaseButton>();
        }

        public static int? GetIndex(this TowerModel towerModel)
        {
            var allTowers = Game.instance.model.towerSet.ToList();
            var detail = allTowers.FirstOrDefault(towerDetail => towerDetail.towerId == towerModel.baseId);
            return allTowers.IndexOf(detail);
        }

        public static int GetUpgradeLevel(this TowerModel towerModel, int path) => towerModel.tiers[path];

        public static bool? IsTowerUnlocked(this TowerModel towerModel)
        {
            return Game.instance?.GetBtd6Player()?.HasUnlockedTower(towerModel.baseId);
        }

        public static bool? IsUpgradeUnlocked(this TowerModel towerModel, int path, int tier)
        {
            var upgradeModel = towerModel.GetUpgrade(path, tier);
            return Game.instance?.GetBtd6Player()?.HasUpgrade(upgradeModel?.name);
        }

        public static bool IsUpgradePathUsed(this TowerModel towerModel, int path)
        {
            var result = towerModel.GetAppliedUpgrades().FirstOrDefault(upgrade => upgrade.path == path);
            return (result != null);
        }

        public static bool HasUpgrade(this TowerModel towerModel, int path, int tier) => 
            HasUpgrade(towerModel, towerModel.GetUpgrade(path, tier));

        public static bool HasUpgrade(this TowerModel towerModel, UpgradeModel upgradeModel)
        {
            return towerModel.GetAppliedUpgrades().Contains(upgradeModel);
        }

        public static List<UpgradeModel> GetAppliedUpgrades(this TowerModel towerModel)
        {
            List<UpgradeModel> appliedUpgrades = new List<UpgradeModel>();

            foreach (var upgrade in towerModel.appliedUpgrades)
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

            var tempTower = Game.instance?.model?.GetTower(towerModel.baseId, tier1, tier2, tier3);
            if (tempTower is null)
                return null;

            const int offset = 1;
            foreach (var upgradeModel in tempTower.GetAppliedUpgrades())
            {
                if (upgradeModel.path != path || upgradeModel.tier != tier - offset)
                    continue;

                return upgradeModel;
            }

            return null;
        }

        public static List<TowerToSimulation> GeTowerToSimulations(this TowerModel towerModel)
        {
            var towers = InGame.instance?.bridge?.GetAllTowers();
            if (towers is null || towers.Count == 0)
                return null;

            List<TowerToSimulation> desiredTowers = new List<TowerToSimulation>();
            foreach (var tower in towers)
            {
                if (tower.Def == towerModel)
                    desiredTowers.Add(tower);
            }

            return desiredTowers;
        }
    }
}