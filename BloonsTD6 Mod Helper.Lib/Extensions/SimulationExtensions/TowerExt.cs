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
            
            foreach (var towerSim in towerSims)
            {
                var simTower = towerSim.GetSimTower();
                if (simTower == tower)
                    return towerSim;
            }

            return null;
        }

        public static Attack GetAttack(this Tower tower)
        {
            return tower.GetTowerBehavior<Attack>();
        }

        public static T GetTowerBehavior<T>(this Tower tower) where T : TowerBehavior
        {
            var behaviors = tower.towerBehaviors;
            for (int i = 0; i < behaviors.count; i++)
            {
                var behavior = behaviors[i];
                if (behavior.model.name.Contains(typeof(T).Name))
                    return behavior.TryCast<T>();
            }

            return null;
        }
    }
}
