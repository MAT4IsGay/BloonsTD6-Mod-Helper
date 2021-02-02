using Assets.Scripts.Models.Bloons;
using Assets.Scripts.Models.Rounds;
using Assets.Scripts.Simulation.Bloons;
using Assets.Scripts.Simulation.Objects;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.Bridge;
using Assets.Scripts.Unity.UI_New.InGame;
using System.Collections.Generic;
using UnhollowerBaseLib;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class BloonModelExt
    {
        public static int? GetIndex(this BloonModel bloonModel)
        {
            Il2CppReferenceArray<BloonModel> allBloons = Game.instance?.model?.bloons;
            return allBloons.FindIndex(bloon => bloon.name == bloonModel.name);
        }

        public static void SpawnBloonModel(this BloonModel bloonModel)
        {
            Assets.Scripts.Simulation.Track.Spawner spawner = InGame.instance?.GetMap()?.spawner;
            if (spawner is null)
                return;

            Il2CppSystem.Collections.Generic.List<Bloon.ChargedMutator> chargedMutators = new Il2CppSystem.Collections.Generic.List<Bloon.ChargedMutator>();
            Il2CppSystem.Collections.Generic.List<BehaviorMutator> nonChargedMutators = new Il2CppSystem.Collections.Generic.List<BehaviorMutator>();
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
            return Game.instance?.model?.CreateBloonEmissions(bloonModel, count, spacing);
        }


        public static List<BloonToSimulation> GetBloonSims(this BloonModel bloonModel)
        {
            Il2CppSystem.Collections.Generic.List<BloonToSimulation> bloonSims = InGame.instance?.bridge?.GetAllBloons();
            if (bloonSims is null || !bloonSims.Any())
                return null;

            List<BloonToSimulation> results = bloonSims.Where(b => b.GetBaseModel().IsEqual(bloonModel)).ToSystemList();
            return results;
        }
    }
}