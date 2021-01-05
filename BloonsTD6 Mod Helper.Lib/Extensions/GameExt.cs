using Assets.Scripts.Models.Bloons;
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
using Assets.Scripts.Unity.UI_New;
using Assets.Scripts.Utils;
using Assets.Scripts.Unity.Menu;
using Assets.Scripts.Unity.Localization;
using Assets.Scripts.Unity.UI_New.InGame.RightMenu;
using Assets.Scripts.Unity.UI_New.Popups;
using BloonsTD6_Mod_Helper.Api;
using Assets.Scripts.Models.Rounds;
using NinjaKiwi.LiNK;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class GameExt
    {
        public static JsonSerializer GetJsonSerializer(this Game game) => new JsonSerializer();
        public static PopupScreen GetPopupScreen(this Game game) => PopupScreen.instance;
        public static ShopMenu GetShopMenu(this Game game) => ShopMenu.instance;
        public static CommonForegroundScreen GetCommonForegroundScreen(this Game game) => CommonForegroundScreen.instance;
        public static CommonBackgroundScreen GetCommonBackgroundScreen(this Game game) => CommonBackgroundScreen.instance;
        public static LocalizationManager GetLocalizationManager(this Game game) => LocalizationManager.instance;
        public static MenuManager GetMenuManager(this Game game) => MenuManager.instance;

        /// <summary>
        /// Not tested
        /// </summary>
        public static List<TowerModel> GetTowerListForTowerType (this Game game, string towerSet)
        {
            return Helpers.GetTowerListForTowerType(towerSet).ToSystemList();
        }

        public static UI GetUI(this Game game) => UI.instance;
        public static ProfileModel GetPlayerProfile(this Game game) => game.playerService?.Player?.Data;
        public static Btd6Player GetBtd6Player(this Game game) => game.playerService?.Player;
        public static LiNKAccount GetPlayerLiNKAccount(this Game game) => game.playerService?.Player?.LiNKAccount;

        public static Il2CppReferenceArray<TowerDetailsModel> GetTowerDetailModels(this Game game) => game.model?.towerSet;
        public static Il2CppReferenceArray<TowerDetailsModel> GetHeroDetailModels(this Game game) => game.model?.heroSet;
        public static Il2CppReferenceArray<PowerDetailsModel> GetPowerDetailModels(this Game game) => game.model?.powerSet;


        public static BloonModel GetBloonModel(this Game game, string bloonName)
        {
            return game.model?.bloons?.FirstOrDefault(bloon => bloon.name == bloonName);
        }

        public static List<BloonModel> GetAllBloonModels(this Game game) => game.model?.bloons?.ToList();
        

        public static double GetMonkeyMoney(this Game game) => game.GetPlayerProfile().monkeyMoney.Value;
        public static void SetMonkeyMoney(this Game game, double amount)
        {
            var monkeyMoney = game.GetPlayerProfile()?.monkeyMoney;
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


        public static void ShowMessage(this Game game, string message, [Optional] string title) => game.ShowMessage(message, 2f, title);

        public static void ShowMessage(this Game game, string message, float displayTime, [Optional] string title)
        {
            var msg = new NkhMsg();
            msg.MsgShowTime = displayTime;
            msg.NkhText = new NkhText();
            msg.NkhText.Body = message;
            msg.NkhText.Title = title;

            NotificationMgr.AddNotification(msg);
        }

        public static List<BloonEmissionModel> CreateBloonEmissionModel(this Game game, string bloonName, float spacing, int number)
        {
            List<BloonEmissionModel> bloonEmissionModels = new List<BloonEmissionModel>();

            for (int i = 0; i < number; i++)
                bloonEmissionModels.Add(new BloonEmissionModel(bloonName, (spacing * i), bloonName));

            return bloonEmissionModels;
        }
    }
}