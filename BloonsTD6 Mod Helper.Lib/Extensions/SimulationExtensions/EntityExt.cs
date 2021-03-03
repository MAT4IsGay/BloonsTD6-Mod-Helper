using Assets.Scripts.Simulation.Display;
using Assets.Scripts.Simulation.Objects;
using Assets.Scripts.Unity.Display;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class EntityExt
    {
        /// <summary>
        /// Get the DisplayNode for this Entity
        /// </summary>
        public static DisplayNode GetDisplayNode(this Entity entity)
        {
            return entity.displayBehaviorCache?.node;
        }

        /// <summary>
        /// Get the UnityDisplayNode for this Entity
        /// </summary>
        public static UnityDisplayNode GetUnityDisplayNode(this Entity entity)
        {
            return entity.displayBehaviorCache?.node?.graphic;
        }
    }
}
