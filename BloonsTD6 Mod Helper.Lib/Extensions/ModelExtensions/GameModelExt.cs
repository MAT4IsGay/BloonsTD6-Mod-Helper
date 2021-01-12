using Assets.Scripts.Models;
using Assets.Scripts.Models.Bloons;
using Assets.Scripts.Models.Rounds;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.TowerSets;
using BloonsTD6_Mod_Helper.Patches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnhollowerBaseLib;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class GameModelExt
    {
        public static Il2CppSystem.Collections.Generic.List<TowerDetailsModel> GetAllTowerDetails(this GameModel model)
        {
            return TowerInventory_Init.allTowers;
        }

        public static Il2CppSystem.Collections.Generic.List<ShopTowerDetailsModel> GetAllShopTowerDetails(this GameModel model)
        {
            var towerDetails = model.GetAllTowerDetails();
            var results = towerDetails.Where(detail => detail.GetShopTowerDetails() != null);
            return results.CloneAs<TowerDetailsModel, ShopTowerDetailsModel>();
        }

        public static BloonModel GetBloonModel(this GameModel model, string bloonName)
        {
            return model.bloons?.FirstOrDefault(bloon => bloon.name == bloonName);
        }

        public static List<TowerModel> GetTowerModels(this GameModel model, string towerBaseId)
        {
            return model.towers?.Where(t => t.baseId == towerBaseId).ToList();
        }


        public static Il2CppReferenceArray<BloonEmissionModel> CreateBloonEmissionModel(this GameModel model, BloonModel bloonModel, int number, float spacing)
        {
            return model.CreateBloonEmissionModel(bloonModel.name, number, spacing);
        }

        public static Il2CppReferenceArray<BloonEmissionModel> CreateBloonEmissionModel(this GameModel model, string bloonName, int number, float spacing)
        {
            var bloonEmissionModels = new List<BloonEmissionModel>();

            for (int i = 0; i < number; i++)
                bloonEmissionModels.Add(new BloonEmissionModel(bloonName, (spacing * i), bloonName));

            return bloonEmissionModels.ToIl2CppReferenceArray();
        }
    }
}
