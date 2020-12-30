using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using Assets.Scripts.Models.Towers.Mods;
using Assets.Scripts.Models.Towers.Upgrades;
using Assets.Scripts.Models.TowerSets;
using Assets.Scripts.Simulation.Towers.Behaviors.Attack;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.InGame;
using Assets.Scripts.Unity.UI_New.InGame.RightMenu;
using Assets.Scripts.Unity.UI_New.InGame.StoreMenu;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class TowerModelExt
    {
        public static T GetBehavior<T>(this TowerModel towerModel) where T : TowerBehaviorModel
        {
            var behaviors = towerModel.behaviors;
            var result = behaviors.FirstOrDefault(behavior => behavior.name.Contains(typeof(T).Name));
            return result.TryCast<T>();
        }

        public static AttackModel GetAttackModel(this TowerModel towerModel)
        {
            return towerModel.GetBehavior<AttackModel>();
        }

        public static void SetMaxAmount(this TowerModel towerModel, int max)
        {
            towerModel.GetTowerDetailsModel().towerCount = max;
            var details = Game.instance.GetTowerDetailsModels().TryCast<Il2CppSystem.Collections.Generic.List<TowerDetailsModel>>();
            InGame.instance.GetTowerInventory().SetTowerMaxes(details);
        }

        public static TowerDetailsModel GetTowerDetailsModel(this TowerModel towerModel)
        {
            return Game.instance.model.towerSet.FirstOrDefault(tower => tower.towerId == towerModel.baseId);
        }

        public static TowerPurchaseButton GetTowerPurchaseButton(this TowerModel towerModel)
        {
            var allButtons = ShopMenu.instance.towerPurchaseButtons;
            for (int i = 0; i < allButtons.Count; i++)
            {
                var button = allButtons[i].TryCast<TowerPurchaseButton>();
                if (button != null && button.baseTowerModel == towerModel)
                    return button;
            }

            return null;
        }

        public static int? GetIndex(this TowerModel towerModel)
        {
            var allTowers = Game.instance.model.towerSet.ToList();
            var detail = allTowers.FirstOrDefault(towerDetail => towerDetail.towerId == towerModel.baseId);
            return allTowers.IndexOf(detail);
        }

        public static int GetUpgradeLevel(this TowerModel towerModel, int path) => towerModel.tiers[path];

        public static List<UpgradeModel> GetAppliedUpgrades(this TowerModel towerModel)
        {
            List<UpgradeModel> appliedUpgrades = new List<UpgradeModel>();
            var upgradeNames = towerModel.appliedUpgrades;

            foreach (var upgrade in upgradeNames)
            {
                appliedUpgrades.Add(Game.instance?.model?.upgradesByName[upgrade]);
            }

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
                bool isCorrectPath = (upgradeModel.path == path);
                bool isCorrectTier = (upgradeModel.tier == tier - offset);
                if (!isCorrectPath || !isCorrectTier)
                    continue;

                return upgradeModel;
            }

            return null;
        }

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

        public static bool ReachedMaxUpgradePaths(this TowerModel towerModel)
        {
            int pathCount = towerModel.GetUsedUpgradePaths().Count;
            const int maxPaths = 2;
            return pathCount >= maxPaths;
        }

        public static bool ReachedMaxUpgrades(this TowerModel towerModel)
        {
            var upgrades = towerModel.GetAppliedUpgrades();
            bool isUpgradeTier5 = false;
            bool isUpgradeTier2 = false;
            foreach (var upgrade in upgrades)
            {
                if (upgrade.tier == 5)
                    isUpgradeTier5 = true;

                if (upgrade.tier == 2)
                    isUpgradeTier2 = true;
            }

            return isUpgradeTier5 && isUpgradeTier2;
        }

        public static List<int> GetUsedUpgradePaths(this TowerModel towerModel)
        {
            List<int> usedPaths = new List<int>();
            const int totalPaths = 3;

            for (int i = 1; i < totalPaths; i++)
            {
                if (towerModel.IsUpgradePathUsed(i))
                    usedPaths.Add(i);
            }

            return usedPaths;
        }
    }
}