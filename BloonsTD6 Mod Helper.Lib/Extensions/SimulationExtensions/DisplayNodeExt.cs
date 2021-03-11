using Assets.Scripts.Simulation.Behaviors;
using Assets.Scripts.Simulation.Display;
using Assets.Scripts.Unity.UI_New.InGame;
using System.Collections.Generic;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class DisplayNodeExt
    {
        //removed. Seems very excessive
        /*/// <summary>
        /// Checks all Display Behaviors currently existing and returns all that have this Display Node
        /// </summary>
        public static List<DisplayBehavior> GetDisplayBehaviors_WithThisNode(this DisplayNode displayNode)
        {
            Assets.Scripts.Utils.SizedList<DisplayBehavior> displayNodes = InGame.instance?.bridge?.simulation?.factory?.GetFactory<DisplayBehavior>()?.all;
            if (displayNode is null)
                return null;

            List<DisplayBehavior> results = displayNodes.Where(behavior => behavior.node.Equals(displayNode));
            if (results is null)
                return null;

            return results;
        }*/
    }
}