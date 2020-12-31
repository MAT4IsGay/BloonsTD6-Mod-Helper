﻿using Assets.Scripts.Models.Bloons;
using Assets.Scripts.Models.Profile;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Upgrades;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.Player;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Assets.Scripts.Models.TowerSets;
using UnhollowerBaseLib;
using Assets.Scripts.Models.PowerSets;
using BloonsTD6_Mod_Helper.Lib;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class GameExt
    {
        public static ProfileModel GetPlayerProfile(this Game game) => game.playerService?.Player?.Data;
        public static Btd6Player GetBtd6Player(this Game game) => game.playerService?.Player;


        public static Il2CppReferenceArray<TowerDetailsModel> GetTowerDetailsModels(this Game game) => game.model?.towerSet;
        public static Il2CppReferenceArray<TowerDetailsModel> GetHeroDetailsModels(this Game game) => game.model?.heroSet;
        public static Il2CppReferenceArray<PowerDetailsModel> GetPowerDetailsModels(this Game game) => game.model?.powerSet;


        public static BloonModel GetBloonModel(this Game game, string bloonName) => game.model?.GetBloon(bloonName);
        public static List<BloonModel> GetAllBloonModels(this Game game) => game.model?.bloons?.ToList();
        

        public static double GetMonkeyMoney(this Game game) => game.GetPlayerProfile().monkeyMoney.Value;
        public static void SetMonkeyMoney(this Game game, double amount)
        {
            var monkeyMoney = game.GetPlayerProfile().monkeyMoney;
            if (monkeyMoney != null)
                monkeyMoney.Value = amount;
        }


        public static UpgradeModel GetUpgradeModel(this Game game, string upgradeName) => game.model?.GetUpgrade(upgradeName);


        public static List<TowerModel> GetTowerModels(this Game game) => game.model?.towers?.ToList();
        public static List<TowerModel> GetTowerModels(this Game game, string towerBaseId)
        {
            var allTowerModels = game.model?.towers;
            if (allTowerModels is null)
                return null;

            var desieredTowerModels = allTowerModels.Where(t => t.baseId == towerBaseId).ToList();
            return desieredTowerModels;
        }

        public static TowerModel GetTowerModel(this Game game, string towerName, [Optional] int pathOneUpgrade,
           [Optional] int pathTwoUpgrade, [Optional] int pathThreeUpgrade)
        {
            return game.model?.GetTower(towerName, pathOneUpgrade, pathTwoUpgrade, pathThreeUpgrade);
        }


        public static void ShowMessage(this Game game, string message, [Optional] string title)
        {
            game.ShowMessage(message, 2f, title);
        }

        public static void ShowMessage(this Game game, string message, float displayTime, [Optional] string title)
        {
            var msg = new NkhMsg();
            msg.MsgShowTime = displayTime;
            msg.NkhText = new NkhText();
            msg.NkhText.Body = message;
            msg.NkhText.Title = title;

            NotificationMgr.AddNotification(msg);
        }
    }
}