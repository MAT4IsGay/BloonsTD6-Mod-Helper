using Assets.Scripts.Models.Bloons;
using Assets.Scripts.Simulation.Bloons;
using Assets.Scripts.Simulation.Objects;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.InGame;
using System.Collections.Generic;
using System.Linq;
namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class BloonModelExt
    {
        public static int? GetIndex(this BloonModel bloonModel)
        {
            var allBloons = Game.instance?.GetAllBloonModels();
            return allBloons.FindIndex(bloon => bloon.name == bloonModel.name);
        }

        public static void SpawnBloonModel(this BloonModel bloonModel)
        {
            var spawner = InGame.instance?.GetMap()?.spawner;
            if (spawner is null)
                return;

            var chargedMutators = new List<Bloon.ChargedMutator>().ToIl2CppList();
            var nonChargedMutators = new List<BehaviorMutator>().ToIl2CppList();
            spawner.Emit(bloonModel, 0, 0, chargedMutators, nonChargedMutators);
        }

        /*public static void Spawn(this BloonModel bloonModel)
        {
            var spawner = InGame.instance.GetMap().spawner;
            spawner.Emit(bloonModel, 0, 0, new Il2CppSystem.Collections.Generic.List<Bloon.ChargedMutator>(),
                new Il2CppSystem.Collections.Generic.List<BehaviorMutator>());
        }*/
    }
}