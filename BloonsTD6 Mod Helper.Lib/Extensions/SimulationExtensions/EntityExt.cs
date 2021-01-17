using Assets.Scripts.Simulation.Display;
using Assets.Scripts.Simulation.Objects;
using Assets.Scripts.Unity.Display;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class EntityExt
    {
        public static DisplayNode GetDisplayNode(this Entity entity) => entity.displayBehaviorCache.node;
        public static UnityDisplayNode GetUnityDisplayNode(this Entity entity) => entity.displayBehaviorCache.node.graphic;

    }
}
