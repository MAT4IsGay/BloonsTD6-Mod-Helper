using Assets.Scripts.Models.Towers;
using Assets.Scripts.Simulation.Towers;
using Assets.Scripts.Unity.Bridge;
using Assets.Scripts.Unity.UI_New.InGame;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class TowerExt
    {
        public static void SetTowerModel(this Tower tower, TowerModel towerModel)
        {
            tower.UpdateRootModel(towerModel);
        }

        public static void SellTower(this Tower tower)
        {
            InGame.instance.SellTower(tower.GetTowerSim());
        }

        public static TowerToSimulation GetTowerSim(this Tower tower)
        {
            Il2CppSystem.Collections.Generic.List<TowerToSimulation> towerSims = InGame.instance?.bridge?.GetAllTowers();
            return towerSims.FirstOrDefault(sim => sim.tower == tower);
        }
    }
}