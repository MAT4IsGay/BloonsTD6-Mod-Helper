using Assets.Scripts.Models;
using Assets.Scripts.Models.Rounds;
using Assets.Scripts.Models.TowerSets;
using Assets.Scripts.Simulation;
using Assets.Scripts.Simulation.Input;
using Assets.Scripts.Simulation.SMath;
using Assets.Scripts.Simulation.Towers;
using Assets.Scripts.Simulation.Towers.Projectiles;
using Assets.Scripts.Simulation.Track;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.Bridge;
using Assets.Scripts.Unity.UI_New.InGame;
using BloonsTD6_Mod_Helper.Patches;
using Il2CppSystem.Collections.Generic;
using UnhollowerBaseLib;
using static Assets.Scripts.Simulation.Simulation;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class InGameExt
    {

        public static Simulation GetGameSimulation(this InGame inGame) => inGame.bridge.GameSimulation;
        public static GameModel GetGameModel(this InGame inGame) => inGame.bridge.GameSimulation.model;
        public static Map GetMap(this InGame inGame) => inGame.bridge.simulation.Map;


        public static bool IsInPublic(this InGame inGame) => (inGame.IsInRace() || inGame.IsInPublicCoop() || inGame.IsInOdyssey());
        public static bool IsInRace(this InGame inGame) => MainMenuEventPanel_OpenRaceEventScreen.IsInRace;
        public static bool IsInPublicCoop(this InGame inGame) => CoopQuickMatchScreen_Open.IsInPublicCoop;
        public static bool IsInOdyssey(this InGame inGame) => OdysseyEventScreen_Update.IsInOdyssey;

        
        
        public static CashManager GetCashManager(this InGame inGame) => inGame.bridge.simulation.cashManagers.entries[0].value;
        public static double GetCash(this InGame inGame) => inGame.GetCashManager().cash.Value;
        public static void AddCash(this InGame inGame, double amount) => inGame.GetCashManager().cash.Value += amount;
        public static void SetCash(this InGame inGame, double amount) => inGame.GetCashManager().cash.Value = amount;



        public static double GetHealth(this InGame inGame) => inGame.bridge.simulation.health.Value;
        public static void AddHealth(this InGame inGame, double amount) => inGame.bridge.simulation.health.Value += amount;
        public static void SetHealth(this InGame inGame, double amount) => inGame.bridge.simulation.health.Value = amount;


        public static double GetMaxHealth(this InGame inGame) => inGame.bridge.simulation.maxHealth.Value;
        public static void AddMaxHealth(this InGame inGame, double amount) => inGame.bridge.simulation.maxHealth.Value += amount;
        public static void SetMaxHealth(this InGame inGame, double amount) => inGame.bridge.simulation.maxHealth.Value = amount;


        public static List<TowerToSimulation> GetTowers(this InGame inGame) => inGame.bridge.GetAllTowers();
        public static List<AbilityToSimulation> GetAbilities(this InGame inGame) => inGame.bridge.GetAllAbilities(true);
        public static List<Projectile> GetProjectiles(this InGame inGame) => inGame.bridge.GetAllProjectiles();
        public static TowerInventory GetTowerInventory(this InGame inGame, int index) => inGame.bridge.simulation.GetTowerInventory(index);
        public static TowerManager GetTowerManager(this InGame inGame) => inGame.bridge.simulation.towerManager;


        public static void GetMapDimensions(this InGame inGame)
        {
            Vector2 topLeft = new Vector2(-149.9228f, -115.2562f);
            Vector2 bottomRight = new Vector2(150.0713f, 115.4701f);
        }


        public static List<BloonToSimulation> GetAllBloons(this InGame inGame) => inGame.bridge.GetAllBloons();
        public static int GetRoundNumber(this InGame inGame) => inGame.bridge.GetCurrentRound();
        public static void SetRound(this InGame inGame, int round) => inGame.bridge.simulation.map.spawner.SetRound(round);

        

        public static void SpawnBloons(this InGame inGame, string bloonName, float spacing, int number)
        {
            var bloonEmissionModels = Game.instance.CreateBloonEmissionModel(bloonName, spacing, number).ToIl2CppReferenceArray();
            inGame.SpawnBloons(bloonEmissionModels);
        }

        public static void SpawnBloons(this InGame inGame, System.Collections.Generic.List<BloonEmissionModel> bloonEmissionModels) =>

          inGame.bridge.SpawnBloons(bloonEmissionModels.ToIl2CppReferenceArray(), inGame.GetRoundNumber(), 0);


        public static void SpawnBloons(this InGame inGame, List<BloonEmissionModel> bloonEmissionModels) =>

           inGame.bridge.SpawnBloons(bloonEmissionModels.ToIl2CppReferenceArray(), inGame.GetRoundNumber(), 0);


        public static void SpawnBloons(this InGame inGame, Il2CppReferenceArray<BloonEmissionModel> bloonEmissionModels) =>
            inGame.bridge.SpawnBloons(bloonEmissionModels, inGame.GetRoundNumber(), 0);


        public static void SpawnBloons(this InGame inGame, int round)
        {
            GameModel model = Game.instance.model;
            if (round < 100)
            {
                var rounds = model.GetRoundSet().rounds;
                var emissions = rounds[round - 1].emissions;
                inGame.SpawnBloons(emissions);
            }
            if (round > 100)
            {
                var emissions = model.freeplayGroups[round - 100].bloonEmissions;
                inGame.SpawnBloons(emissions);
            }
        }
    }
}
