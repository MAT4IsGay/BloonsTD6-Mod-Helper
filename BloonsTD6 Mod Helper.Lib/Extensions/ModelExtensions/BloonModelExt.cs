using Assets.Scripts.Models.Bloons;
using Assets.Scripts.Models.Rounds;
using Assets.Scripts.Simulation.Bloons;
using Assets.Scripts.Simulation.Objects;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.Bridge;
using Assets.Scripts.Unity.UI_New.InGame;
using System.Collections.Generic;
using System.Linq;
using UnhollowerBaseLib;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class BloonModelExt
    {
        public static int? GetIndex(this BloonModel bloonModel)
        {
            var allBloons = Game.instance?.model?.bloons;
            return allBloons.FindIndex(bloon => bloon.name == bloonModel.name);
        }

        public static void SpawnBloonModel(this BloonModel bloonModel)
        {
            var spawner = InGame.instance?.GetMap()?.spawner;
            if (spawner is null)
                return;

            var chargedMutators = new Il2CppSystem.Collections.Generic.List<Bloon.ChargedMutator>();
            var nonChargedMutators = new Il2CppSystem.Collections.Generic.List<BehaviorMutator>();
            spawner.Emit(bloonModel, InGame.Bridge.GetCurrentRound(), 0, chargedMutators, nonChargedMutators);
        }

        //possibly bugged. Will come back to later
        /*public static void Spawn(this BloonModel bloonModel)
        {
            var spawner = InGame.instance.GetMap().spawner;
            spawner.Emit(bloonModel, 0, 0, new Il2CppSystem.Collections.Generic.List<Bloon.ChargedMutator>(),
                new Il2CppSystem.Collections.Generic.List<BehaviorMutator>());
        }*/


        public static Il2CppReferenceArray<BloonEmissionModel> CreateBloonEmissionModel(this BloonModel bloonModel, int count, int spacing)
        {
            return Game.instance?.model?.CreateBloonEmissionModel(bloonModel, count, spacing);
        }


        public static List<BloonToSimulation> GetBloonSims(this BloonModel bloonModel)
        {
            var bloonSims = InGame.instance?.bridge?.GetAllBloons();
            if (bloonSims is null || bloonSims.Count == 0)
                return null;

            var results = bloonSims.Where(b => b.GetBaseModel().IsEqual(bloonModel)).ToSystemList();
            return results;
        }
    }
}