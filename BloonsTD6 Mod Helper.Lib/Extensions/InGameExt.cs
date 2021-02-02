using Assets.Scripts.Models;
using Assets.Scripts.Models.Rounds;
using Assets.Scripts.Simulation;
using Assets.Scripts.Simulation.Factory;
using Assets.Scripts.Simulation.Input;
using Assets.Scripts.Simulation.Objects;
using Assets.Scripts.Simulation.Towers;
using Assets.Scripts.Simulation.Track;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.InGame;
using Assets.Scripts.Utils;
using BloonsTD6_Mod_Helper.Api;
using BloonsTD6_Mod_Helper.Patches;
using Il2CppSystem.Collections.Generic;
using UnhollowerBaseLib;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Assets.Scripts.Simulation.Simulation;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class InGameExt
    {
        public static GameObject GetInGameUI(this InGame inGame)
        {
            Scene scene = SceneManager.GetSceneByName("InGameUi");
            Il2CppReferenceArray<GameObject> rootGameObjects = scene.GetRootGameObjects();

            const int uiIndex = 1;
            GameObject ui = rootGameObjects[uiIndex];
            return ui;
        }


        public static FactoryFactory GetMainFactory(this InGame inGame)
        {
            return inGame.bridge.simulation.factory;
        }

        public static GameModel GetGameModel(this InGame inGame)
        {
            return inGame.bridge.GameSimulation.model;
        }

        public static string GetSavePath(this InGame inGame)
        {
            return InGame.savePath;
        }

        public static Simulation GetSimulation(this InGame inGame)
        {
            return inGame.bridge.simulation;
        }

        public static Map GetMap(this InGame inGame)
        {
            return inGame.bridge.simulation.Map;
        }

        public static bool CanGetFlagged(this InGame inGame)
        {
            return (inGame.IsInRace() || inGame.IsInPublicCoop() || inGame.IsInOdyssey());
        }

        public static bool IsInRace(this InGame inGame)
        {
            return SessionData.IsInRace;
        }

        public static bool IsInPublicCoop(this InGame inGame)
        {
            return SessionData.IsInPublicCoop;
        }

        public static bool IsInOdyssey(this InGame inGame)
        {
            return SessionData.IsInOdyssey;
        }

        public static CashManager GetCashManager(this InGame inGame)
        {
            return inGame.bridge.simulation.cashManagers.entries[0].value;
        }

        public static double GetCash(this InGame inGame)
        {
            return inGame.GetCashManager().cash.Value;
        }

        public static void AddCash(this InGame inGame, double amount)
        {
            inGame.GetCashManager().cash.Value += amount;
        }

        public static void SetCash(this InGame inGame, double amount)
        {
            inGame.GetCashManager().cash.Value = amount;
        }

        public static double GetHealth(this InGame inGame)
        {
            return inGame.bridge.simulation.health.Value;
        }

        public static void AddHealth(this InGame inGame, double amount)
        {
            inGame.bridge.simulation.health.Value += amount;
        }

        public static void SetHealth(this InGame inGame, double amount)
        {
            inGame.bridge.simulation.health.Value = amount;
        }

        public static double GetMaxHealth(this InGame inGame)
        {
            return inGame.bridge.simulation.maxHealth.Value;
        }

        public static void AddMaxHealth(this InGame inGame, double amount)
        {
            inGame.bridge.simulation.maxHealth.Value += amount;
        }

        public static void SetMaxHealth(this InGame inGame, double amount)
        {
            inGame.bridge.simulation.maxHealth.Value = amount;
        }

        public static System.Collections.Generic.Dictionary<string, int> GetPoppedBloons(this InGame inGame)
        {
            return SessionData.PoppedBloons;
        }

        public static TowerManager GetTowerManager(this InGame inGame)
        {
            return inGame.bridge.simulation.towerManager;
        }

        //not using this one because it doesn't seem to work
        //public static TowerInventory GetTowerInventory(this InGame inGame, int index) => inGame.bridge.simulation.GetTowerInventory(index);
        public static TowerInventory GetTowerInventory(this InGame inGame)
        {
            return TowerInventory_Init.towerInventory;
        }



        /*public static void GetMapDimensions(this InGame inGame, out Vector2 topLeft, out Vector2 bottomRight)
        {
            topLeft = new Vector2(-149.9228f, -115.2562f);
            bottomRight = new Vector2(150.0713f, 115.4701f);
        }*/

        public static void SetRound(this InGame inGame, int round)
        {
            inGame.bridge.simulation.map.spawner.SetRound(round);
        }

        public static SizedList<T> GetAllObjectsOfType<T>(this InGame inGame) where T : RootObject, new()
        {
            Factory<T> factory = inGame.bridge.simulation.factory.GetFactory<T>();
            return factory.all;
        }

        public static void SpawnBloons(this InGame inGame, string bloonName, int number, float spacing)
        {
            Il2CppReferenceArray<BloonEmissionModel> bloonEmissionModels = Game.instance.model.CreateBloonEmissions(bloonName, number, spacing).ToIl2CppReferenceArray();
            inGame.SpawnBloons(bloonEmissionModels);
        }

        public static void SpawnBloons(this InGame inGame, System.Collections.Generic.List<BloonEmissionModel> bloonEmissionModels)
        {
            inGame.bridge.SpawnBloons(bloonEmissionModels.ToIl2CppReferenceArray(), inGame.bridge.GetCurrentRound(), 0);
        }

        public static void SpawnBloons(this InGame inGame, List<BloonEmissionModel> bloonEmissionModels)
        {
            inGame.bridge.SpawnBloons(bloonEmissionModels.ToIl2CppReferenceArray(), inGame.bridge.GetCurrentRound(), 0);
        }

        public static void SpawnBloons(this InGame inGame, Il2CppReferenceArray<BloonEmissionModel> bloonEmissionModels)
        {
            inGame.bridge.SpawnBloons(bloonEmissionModels, inGame.bridge.GetCurrentRound(), 0);
        }

        public static void SpawnBloons(this InGame inGame, int round)
        {
            GameModel model = inGame.GetGameModel();

            int index = (round < 100) ? round - 1 : round - 100;
            Il2CppReferenceArray<BloonEmissionModel> emissions = (round < 100) ? model.GetRoundSet().rounds[index].emissions : model.freeplayGroups[index].bloonEmissions;
            InGame.instance.SpawnBloons(emissions);
        }
    }
}