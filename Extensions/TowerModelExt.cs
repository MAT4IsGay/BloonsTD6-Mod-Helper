using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Upgrades;
using Assets.Scripts.Models.TowerSets;
using Assets.Scripts.Simulation.Towers.Behaviors.Attack;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.InGame;
using Assets.Scripts.Unity.UI_New.InGame.RightMenu;
using Assets.Scripts.Unity.UI_New.InGame.StoreMenu;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class TowerModelExt
    {
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

        public static Attack GetAttack(this TowerModel towerModel)
        {
            Attack attack = null;
            var behaviors = towerModel.behaviors;
            for (int i = 0; i < behaviors.Count; i++)
            {
                var behavior = behaviors[i];
                var behaviorName = behavior.name;

                if (!behaviorName.ToLower().Contains("attack"))
                    continue;

                attack = behavior.TryCast<Attack>();
            }

            return attack;
        }

        public static int? GetIndex(this TowerModel towerModel)
        {
            var allTowers = Game.instance.model.towerSet.ToList();
            var detail = allTowers.FirstOrDefault(towerDetail => towerDetail.towerId == towerModel.baseId);
            return allTowers.IndexOf(detail);
        }

        public static int GetUpgradeLevel(this TowerModel towerModel, int path) => towerModel.tiers[path - 1];

        public static string GetUpgradeName(this TowerModel towerModel, int path, int tier)
        {
            var upgradeModel = towerModel.GetUpgrade(path, tier);
            if (upgradeModel is null)
                return null;

            return upgradeModel.name;
        }

        public static List<UpgradeModel> GetAppliedUpgrades(this TowerModel towerModel)
        {
            List<UpgradeModel> appliedUpgrades = new List<UpgradeModel>();
            var upgradeNames = towerModel.appliedUpgrades;

            foreach (var upgrade in upgradeNames)
            {
                appliedUpgrades.Add(Game.instance.model.upgradesByName[upgrade]);
            }

            return appliedUpgrades;
        }

        public static UpgradeModel GetUpgrade (this TowerModel towerModel, int path, int tier)
        {
            if (path <= 0 && tier <= 0)
                return null;

            int tier1 = (path == 1) ? tier : 0;
            int tier2 = (path == 2) ? tier : 0;
            int tier3 = (path == 3) ? tier : 0;

            var tempTower = Game.instance.model.GetTower(towerModel.baseId, tier1, tier2, tier3);
            if (tempTower is null)
                return null;

            UpgradeModel upgradeModel = null;
            foreach (var upgrade in tempTower.GetAppliedUpgrades())
            {
                const int offset = 1;
                bool isCorrectPath = (upgrade.path == path - offset);
                bool isCorrectTier = (upgrade.tier == tier - offset);
                if (!isCorrectPath || !isCorrectTier)
                    continue;

                upgradeModel = upgrade;
                break;
            }

            return upgradeModel;
        }


        /*public static bool? IsUpgradeBlocked(this TowerModel towerModel, int path, int tier)
        {
            if (towerModel.IsHero())
                return null;

            

            int tier1 = towerModel.GetUpgradeLevel(1);
            int tier2 = towerModel.GetUpgradeLevel(1);
            int tier3 = towerModel.GetUpgradeLevel(1);

            
        }*/
    }
}