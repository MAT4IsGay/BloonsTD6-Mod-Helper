using Assets.Scripts.Models.GenericBehaviors;
using Assets.Scripts.Simulation.Behaviors;
using Assets.Scripts.Unity.UI_New.InGame;
using System.Collections.Generic;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class DisplayModelExt
    {
        /// <summary>
        /// Get all currently existing Display Behaviors with this Display Model
        /// </summary>
        public static List<DisplayBehavior> GetDisplayBehaviors_WithThisModel(this DisplayModel displayModel)
        {
            if (displayModel is null)
                return null;

            Assets.Scripts.Utils.SizedList<DisplayBehavior> displayBehaviors = InGame.instance?.bridge?.simulation?.factory?.GetFactory<DisplayBehavior>()?.all;
            if (displayBehaviors is null)
                return null;

            List<DisplayBehavior> results = displayBehaviors.Where(behavior => behavior.displayModel.IsEqual(displayModel));
            return results;
        }
    }
}
