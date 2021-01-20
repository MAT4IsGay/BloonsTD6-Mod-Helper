using Assets.Scripts.Simulation.Behaviors;
using Assets.Scripts.Simulation.Display;
using Assets.Scripts.Unity.UI_New.InGame;
using MelonLoader;
using System.Collections.Generic;
using System.Linq;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class DisplayNodeExt
    {
        public static List<DisplayBehavior> GetDisplayBehaviors_WithThisNode(this DisplayNode displayNode)
        {
            var displayNodes = InGame.instance?.bridge?.simulation?.factory?.GetFactory<DisplayBehavior>()?.all;
            if (displayNode is null)
                return null;

            var results = displayNodes.Where(behavior => behavior.node.Equals(displayNode));
            if (results is null)
                return null;

            return results;
        }
    }
}