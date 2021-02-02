using Assets.Scripts.Models.PowerSets;
using Assets.Scripts.Models.Profile;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.TowerSets;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.Localization;
using Assets.Scripts.Unity.Menu;
using Assets.Scripts.Unity.Player;
using Assets.Scripts.Unity.UI_New;
using Assets.Scripts.Unity.UI_New.InGame.RightMenu;
using Assets.Scripts.Unity.UI_New.Popups;
using Assets.Scripts.Utils;
using BloonsTD6_Mod_Helper.Api;
using NinjaKiwi.LiNK;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnhollowerBaseLib;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class GameExt
    {
        public static Assets.Scripts.Unity.Display.Factory GetDisplayFactory(this Game game)
        {
            return game.scene?.factory;
        }

        public static SpriteRegister GetSpriteRegister(this Game game)
        {
            return SpriteRegister.Instance;
        }

        public static JsonSerializer GetJsonSerializer(this Game game)
        {
            return new JsonSerializer();
        }

        public static PopupScreen GetPopupScreen(this Game game)
        {
            return PopupScreen.instance;
        }

        public static ShopMenu GetShopMenu(this Game game)
        {
            return ShopMenu.instance;
        }

        public static CommonForegroundScreen GetCommonForegroundScreen(this Game game)
        {
            return CommonForegroundScreen.instance;
        }

        public static CommonBackgroundScreen GetCommonBackgroundScreen(this Game game)
        {
            return CommonBackgroundScreen.instance;
        }

        public static LocalizationManager GetLocalizationManager(this Game game)
        {
            return LocalizationManager.instance;
        }

        public static MenuManager GetMenuManager(this Game game)
        {
            return MenuManager.instance;
        }

        /// <summary>
        /// Not tested
        /// </summary>
        public static List<TowerModel> GetTowerListForTowerType(this Game game, string towerSet)
        {
            return Helpers.GetTowerListForTowerType(towerSet).ToSystemList();
        }

        public static UI GetUI(this Game game)
        {
            return UI.instance;
        }

        public static ProfileModel GetPlayerProfile(this Game game)
        {
            return game.playerService?.Player?.Data;
        }

        public static Btd6Player GetBtd6Player(this Game game)
        {
            return game.playerService?.Player;
        }

        public static LiNKAccount GetPlayerLiNKAccount(this Game game)
        {
            return game.playerService?.Player?.LiNKAccount;
        }

        public static Il2CppReferenceArray<TowerDetailsModel> GetTowerDetailModels(this Game game)
        {
            return game.model?.towerSet;
        }

        public static Il2CppReferenceArray<TowerDetailsModel> GetHeroDetailModels(this Game game)
        {
            return game.model?.heroSet;
        }

        public static Il2CppReferenceArray<PowerDetailsModel> GetPowerDetailModels(this Game game)
        {
            return game.model?.powerSet;
        }


        // moved
        /*public static BloonModel GetBloonModel(this Game game, string bloonName)
        {
            return game.model?.bloons?.FirstOrDefault(bloon => bloon.name == bloonName);
        }*/


        // being removed
        //public static List<BloonModel> GetAllBloonModels(this Game game) => game.model?.bloons?.ToList();


        public static double GetMonkeyMoney(this Game game)
        {
            return game.GetPlayerProfile().monkeyMoney.Value;
        }

        public static void SetMonkeyMoney(this Game game, double amount)
        {
            KonFuze monkeyMoney = game.GetPlayerProfile()?.monkeyMoney;
            if (monkeyMoney != null)
                monkeyMoney.Value = amount;
        }


        // being removed
        //public static UpgradeModel GetUpgradeModel(this Game game, string upgradeName) => game.model?.GetUpgrade(upgradeName);


        // being removed
        //public static List<TowerModel> GetTowerModels(this Game game) => game.model?.towers?.ToList();


        // moved
        /*public static List<TowerModel> GetTowerModels(this Game game, string towerBaseId)
        {
            var allTowerModels = game.model?.towers;
            if (allTowerModels is null)
                return null;

            var desieredTowerModels = allTowerModels.Where(t => t.baseId == towerBaseId).ToList();
            return desieredTowerModels;
        }*/



        // being removed
        /*public static TowerModel GetTowerModel(this Game game, string towerName, [Optional] int pathOneUpgrade,
           [Optional] int pathTwoUpgrade, [Optional] int pathThreeUpgrade)
        {
            return game.model?.GetTower(towerName, pathOneUpgrade, pathTwoUpgrade, pathThreeUpgrade);
        }*/


        public static void ShowMessage(this Game game, string message, [Optional] string title)
        {
            game.ShowMessage(message, 2f, title);
        }

        public static void ShowMessage(this Game game, string message, float displayTime, [Optional] string title)
        {
            NkhMsg msg = new NkhMsg
            {
                MsgShowTime = displayTime,
                NkhText = new NkhText
                {
                    Body = message,
                    Title = title
                }
            };

            NotificationMgr.AddNotification(msg);
        }
    }
}