﻿using Assets.Scripts.Models.PowerSets;
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
        /// <summary>
        /// Get the Unity Display Factory that manages on screen sprites. This Factory is different from other Factories in the game
        /// </summary>
        public static Assets.Scripts.Unity.Display.Factory GetDisplayFactory(this Game game)
        {
            return game.scene?.factory;
        }

        /// <summary>
        /// Gets the Sprite Register. Can be used to add custom sprites
        /// </summary>
        public static SpriteRegister GetSpriteRegister(this Game game)
        {
            return SpriteRegister.Instance;
        }

        /// <summary>
        /// Gets a Json Serializer. Not necessary but can be useful
        /// </summary>
        public static JsonSerializer GetJsonSerializer(this Game game)
        {
            return new JsonSerializer();
        }

        /// <summary>
        /// Get the instance of PopupScreen
        /// </summary>
        public static PopupScreen GetPopupScreen(this Game game)
        {
            return PopupScreen.instance;
        }

        /// <summary>
        /// Get the instance of ShopMenu
        /// </summary>
        public static ShopMenu GetShopMenu(this Game game)
        {
            return ShopMenu.instance;
        }

        /// <summary>
        /// Get the instance of CommonForegroundScreen
        /// </summary>
        public static CommonForegroundScreen GetCommonForegroundScreen(this Game game)
        {
            return CommonForegroundScreen.instance;
        }

        /// <summary>
        /// Get the instance of CommonBackgroundScreen
        /// </summary>
        public static CommonBackgroundScreen GetCommonBackgroundScreen(this Game game)
        {
            return CommonBackgroundScreen.instance;
        }

        /// <summary>
        /// Get the instance of LocalizationManager
        /// </summary>
        public static LocalizationManager GetLocalizationManager(this Game game)
        {
            return LocalizationManager.instance;
        }

        /// <summary>
        /// Get the instance of MenuManager
        /// </summary>
        public static MenuManager GetMenuManager(this Game game)
        {
            return MenuManager.instance;
        }

        /// <summary>
        /// Get the instance of UI
        /// </summary>
        public static UI GetUI(this Game game)
        {
            return UI.instance;
        }

        /// <summary>
        /// Not tested
        /// </summary>
        public static List<TowerModel> GetTowerListForTowerType(this Game game, string towerSet)
        {
            return Helpers.GetTowerListForTowerType(towerSet).ToSystemList();
        }

        /// <summary>
        /// Get the Profile for the player. Contains different info than Btd6Player data
        /// </summary>
        public static ProfileModel GetPlayerProfile(this Game game)
        {
            return game.playerService?.Player?.Data;
        }

        /// <summary>
        /// Get the Btd6Player data for the player. Contains different info than PlayerProfile
        /// </summary>
        public static Btd6Player GetBtd6Player(this Game game)
        {
            return game.playerService?.Player;
        }

        /// <summary>
        /// Get Player LinkAccount. Contains limited info about player's NinjaKiwi account
        /// </summary>
        public static LiNKAccount GetPlayerLiNKAccount(this Game game)
        {
            return game.playerService?.Player?.LiNKAccount;
        }

        /// <summary>
        /// Get all TowerDetailModels
        /// </summary>
        public static Il2CppReferenceArray<TowerDetailsModel> GetTowerDetailModels(this Game game)
        {
            return game.model?.towerSet;
        }

        /// <summary>
        /// Get all HeroDetailModels
        /// </summary>
        public static Il2CppReferenceArray<TowerDetailsModel> GetHeroDetailModels(this Game game)
        {
            return game.model?.heroSet;
        }

        /// <summary>
        /// Get all PowerDetailModels
        /// </summary>
        public static Il2CppReferenceArray<PowerDetailsModel> GetPowerDetailModels(this Game game)
        {
            return game.model?.powerSet;
        }

        /// <summary>
        /// Get player's current Monkey Money amount
        /// </summary>
        public static double GetMonkeyMoney(this Game game)
        {
            return game.GetPlayerProfile().monkeyMoney.Value;
        }

        /// <summary>
        /// Add Monkey Money to player's total Monkey Money
        /// </summary>
        /// <param name="amount">Amount to add</param>
        public static void AddMonkeyMoney(this Game game, double amount)
        {
            KonFuze monkeyMoney = game.GetPlayerProfile()?.monkeyMoney;
            if (monkeyMoney != null)
                monkeyMoney.Value += amount;
        }

        /// <summary>
        /// Set player's Monkey Money amount
        /// </summary>
        /// <param name="amount">Value to set Monkey Money to</param>
        public static void SetMonkeyMoney(this Game game, double amount)
        {
            KonFuze monkeyMoney = game.GetPlayerProfile()?.monkeyMoney;
            if (monkeyMoney != null)
                monkeyMoney.Value = amount;
        }

        /// <summary>
        /// Uses custom message popup to show a message in game. Currently only works in active game sessions and not on Main Menu
        /// </summary>
        /// <param name="message">Message body</param>
        /// <param name="title">Message title. Will be mod name by default</param>
        public static void ShowMessage(this Game game, string message, [Optional] string title)
        {
            game.ShowMessage(message, 2f, title);
        }

        /// <summary>
        /// Uses custom message popup to show a message in game. Currently only works in active game sessions and not on Main Menu
        /// </summary>
        /// <param name="message">Message body</param>
        /// <param name="displayTime">Time to show message on screen</param>
        /// <param name="title">Message title. Will be mod name by default</param>
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