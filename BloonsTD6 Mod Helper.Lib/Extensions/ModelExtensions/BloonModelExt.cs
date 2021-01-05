using Assets.Scripts.Models.Bloons;
using Assets.Scripts.Simulation.Bloons;
using Assets.Scripts.Simulation.Objects;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.InGame;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class BloonModelExt
    {
        public static int? GetIndex(this BloonModel bloonModel)
        {
            var allBloons = Game.instance.GetAllBloonModels();
            for (int i = 0; i < allBloons.Count; i++)
            {
                if (allBloons[i].name.ToLower() == bloonModel.name.ToLower())
                    return i;
            }
            return null;
        }

        public static void Spawn(this BloonModel bloonModel)
        {
            var spawner = InGame.instance.GetMap().spawner;
            spawner.Emit(bloonModel, 0, 0, new Il2CppSystem.Collections.Generic.List<Bloon.ChargedMutator>(), 
                new Il2CppSystem.Collections.Generic.List<BehaviorMutator>());
        }

        /*public static void Spawn(this BloonModel bloonModel)
        {
            var spawner = InGame.instance.GetMap().spawner;
            spawner.Emit(bloonModel, 0, 0, new Il2CppSystem.Collections.Generic.List<Bloon.ChargedMutator>(),
                new Il2CppSystem.Collections.Generic.List<BehaviorMutator>());
        }*/
    }
}