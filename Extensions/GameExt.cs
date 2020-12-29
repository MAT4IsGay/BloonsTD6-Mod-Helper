using Assets.Scripts.Models.Bloons;
using Assets.Scripts.Models.Profile;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Upgrades;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.Player;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using BloonsTD6_Mod_Helper.Patches;
using Assets.Scripts.Models.TowerSets;
using UnhollowerBaseLib;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class GameExt
    {
        public static Il2CppReferenceArray<TowerDetailsModel> GetTowerDetailsModels(this Game game) => game.model.towerSet;


        public static ProfileModel GetProfileModel(this Game game) => ProfileModel_Validate.profileModel;
        public static Btd6Player GetBtd6Player(this Game game) => Btd6Player_GetAnalyticsInfo.playerModel;


        public static double GetMonkeyMoney(this Game game) => game.playerService.Player.Data.monkeyMoney.Value;
        public static void SetMonkeyMoney(this Game game, double amount) => game.playerService.Player.Data.monkeyMoney.Value = amount;



        public static BloonModel GetBloonModel(this Game game, string bloonName) => game.model.GetBloon(bloonName);
        public static List<BloonModel> GetAllBloonModels(this Game game) => game.model.bloons.ToList<BloonModel>();

        public static UpgradeModel GetUpgradeModel(this Game game, string upgradeName) => game.model.GetUpgrade(upgradeName);
        public static TowerModel GetTowerModel(this Game game, string towerName, [Optional] int pathOneUpgrade,
            [Optional] int pathTwoUpgrade, [Optional] int pathThreeUpgrade)
        {
            return game.model.GetTower(towerName, pathOneUpgrade, pathTwoUpgrade, pathThreeUpgrade);
        }


        public static List<TowerModel> GetTowerModels(this Game game) => game.model.towers.ToList<TowerModel>();
        public static List<TowerModel> GetTowerModels(this Game game, string towerBaseId, bool caseSensitive = false)
        {
            var allTowerModels = game.model.towers;
            var desieredTowerModels = new List<TowerModel>();

            if (!caseSensitive)
                towerBaseId = towerBaseId.ToLower();

            foreach (var towerModel in allTowerModels)
            {
                if (towerModel.baseId == towerBaseId)
                    desieredTowerModels.Add(towerModel);
            }

            return desieredTowerModels;
        }
    }
}