﻿using Assets.Scripts.Models.TowerSets;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.InGame;
using Assets.Scripts.Unity.UI_New.InGame.RightMenu;
using Assets.Scripts.Unity.UI_New.InGame.StoreMenu;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class TowerDetailsModelExt
    {
        public static bool IsHero(this TowerDetailsModel towerDetailsModel)
        {
            var heroDetailsModel = towerDetailsModel.TryCast<HeroDetailsModel>();
            var isHero = (heroDetailsModel != null);
            return isHero;
        }

        public static TowerPurchaseButton GetTowerPurchaseButton(this TowerDetailsModel towerDetailsModel)
        {
            var towerModel = Game.instance.model.GetTower(towerDetailsModel.towerId);
            return towerModel.GetTowerPurchaseButton();
        }

        public static ShopTowerDetailsModel GetShopTowerDetails(this TowerDetailsModel towerDetailsModel)
        {
            return towerDetailsModel.TryCast<ShopTowerDetailsModel>();
        }


        //needs more work
        /*public static bool HasPlayerUnlocked(this TowerDetailsModel towerDetailsModel)
        {
            var towerModel = Game.instance.model.GetTower(towerDetailsModel.towerId);
            return towerModel.IsTowerUnlocked().Value;
        }*/



        // this would be helpful but might not use it because it requires user in game
        /*public static void SetCount(this TowerDetailsModel towerDetailsModel, int count)
        {
            towerDetailsModel.towerCount = count;
            var details = Game.instance?.model.towerSet.ToIl2CppList();
            //var details = Game.instance?.GetTowerDetailModels().TryCast<Il2CppSystem.Collections.Generic.List<TowerDetailsModel>>();
            InGame.instance?.GetTowerInventory(1).SetTowerMaxes(details);
        }*/
    }
}