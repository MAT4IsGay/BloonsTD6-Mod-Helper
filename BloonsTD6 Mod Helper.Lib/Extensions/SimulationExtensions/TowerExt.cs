using Assets.Scripts.Models.Towers;
using Assets.Scripts.Simulation.Towers;
using Assets.Scripts.Simulation.Towers.Behaviors.Attack;
using Assets.Scripts.Unity.Bridge;
using Assets.Scripts.Unity.UI_New.InGame;
using System.Linq;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class TowerExt
    {
        public static void SetTowerModel(this Tower tower, TowerModel towerModel) => tower.UpdateRootModel(towerModel);
        public static void SellTower(this Tower tower) => InGame.instance.SellTower(tower.GetTowerSim());

        public static TowerToSimulation GetTowerSim(this Tower tower)
        {
            var towerSims = InGame.instance?.bridge?.GetAllTowers();
            return towerSims.FirstOrDefault(sim => sim.tower == tower);
        }
    }
}