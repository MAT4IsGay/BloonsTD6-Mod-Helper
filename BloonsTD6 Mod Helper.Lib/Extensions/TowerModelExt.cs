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
        public static void SetMaxAmount(this TowerModel towerModel, int max)
        {
            towerModel.GetTowerDetailsModel().towerCount = max;
            var details = Game.instance?.GetTowerDetailsModels().TryCast<Il2CppSystem.Collections.Generic.List<TowerDetailsModel>>();
            InGame.instance?.GetTowerInventory().SetTowerMaxes(details);
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






        public static void AddBehavior<T>(this TowerModel towerModel, T behavior) where T : Model
        {
            var behaviors = towerModel.behaviors;
            Il2CppUtils.Add(ref behaviors, behavior);
            towerModel.behaviors = behaviors;
        }

        public static bool HasBehavior<T>(this TowerModel towerModel) where T : Model
        {
            if (towerModel.behaviors == null || towerModel.behaviors.Count == 0)
                return false;

            try { var result = towerModel.behaviors.First(item => item.name.Contains(typeof(T).Name)); }
            catch (Exception) { return false; }

            return true;
        }


        public static T GetBehavior<T>(this TowerModel towerModel) where T : Model
        {
            var behaviors = towerModel.behaviors;
            var result = behaviors.FirstOrDefault(behavior => behavior.name.Contains(typeof(T).Name));
            return result.TryCast<T>();
        }

        public static List<T> GetBehaviors<T>(this TowerModel towerModel) where T : Model
        {
            var behaviors = towerModel.behaviors;
            if (towerModel.behaviors is null || towerModel.behaviors.Count == 0)
                return null;

            var results = new Il2CppReferenceArray<T>(0);
            foreach (var behavior in behaviors)
            {
                if (behavior.name.Contains(typeof(T).Name))
                    Il2CppUtils.Add(ref results, behavior.TryCast<T>());
            }

            return results.ToList();
        }


        /// <summary>
        /// This is probably not done. Make sure you can remove a SINGLE behavior
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="towerModel"></param>
        public static void RemoveBehavior<T>(this TowerModel towerModel) where T : Model
        {
            if (!towerModel.HasBehavior<T>())
                return;

            var behaviors = towerModel.GetBehaviors<T>();
            foreach (var item in behaviors)
                towerModel.RemoveBehavior(item);
        }

        /// <summary>
        /// This is probably not done. Make sure it removes a SINGLE behavior
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="towerModel"></param>
        /// <param name="behavior"></param>
        public static void RemoveBehavior<T>(this TowerModel towerModel, T behavior) where T : Model
        {
            if (!towerModel.HasBehavior<T>())
                return;

            int itemsRemoved = 0;
            var behaviors = towerModel.behaviors;
            towerModel.behaviors = new Il2CppReferenceArray<Model>(behaviors.Length - 1);

            for (int i = 0; i < behaviors.Length; i++)
            {
                var item = behaviors[i];
                if (item.name == behavior.name)
                {
                    itemsRemoved++;
                    continue;
                }

                towerModel.behaviors[i - itemsRemoved] = item;
            }
        }

        // removed to use list insted
        /*public static AttackModel GetAttackModel(this TowerModel towerModel)
        {
            if (!towerModel.HasBehavior<AttackModel>())
                return null;

            return towerModel.GetBehavior<AttackModel>();
        }*/

        

        /*public static void RemoveBehavior<T>(this TowerModel towerModel) where T : TowerBehaviorModel
        {
            while (towerModel.HasBehavior<T>())
                towerModel.RemoveBehavior(towerModel.GetBehavior<T>());
        }*/

        /*public static void RemoveBehavior<T>(this TowerModel towerModel, T behavior) where T : TowerBehaviorModel
        {
            if (!towerModel.HasBehavior<T>())
                return;

            bool foundItem = false;
            var behaviors = towerModel.behaviors;
            towerModel.behaviors = new Il2CppReferenceArray<Model>(behaviors.Length - 1);

            for (int i = 0; i < behaviors.Length; i++)
            {
                var item = behaviors[i];
                if (item.name == behavior.name)
                {
                    foundItem = true;
                    continue;
                }

                int index = (foundItem) ? i - 1 : i;
                towerModel.behaviors[index] = item;
            }
        }*/
    }
}