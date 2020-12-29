using Assets.Scripts.Simulation.Towers;
using Assets.Scripts.Simulation.Towers.Behaviors.Attack;
using Assets.Scripts.Unity.Bridge;
using Assets.Scripts.Unity.UI_New.InGame;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class TowerExt
    {
        public static void SellTower(this Tower tower) => InGame.instance.SellTower(tower.GetTowerToSimulation());

        public static TowerToSimulation GetTowerToSimulation(this Tower tower)
        {
            var towerSims = InGame.instance.bridge.GetAllTowers();

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
            Attack attack = null;
            var behaviors = tower.towerBehaviors;
            for (int i = 0; i < behaviors.Count; i++)
            {
                var behavior = behaviors[i];
                var behaviorName = behavior.model.name;

                if (!behaviorName.ToLower().Contains("attack"))
                    continue;

                attack = behavior.TryCast<Attack>();
            }

            return attack;
        }
    }
}
