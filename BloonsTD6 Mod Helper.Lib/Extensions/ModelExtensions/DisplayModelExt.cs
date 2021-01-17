using Assets.Scripts.Models.GenericBehaviors;
using Assets.Scripts.Simulation.Behaviors;
using Assets.Scripts.Unity.UI_New.InGame;
using System.Collections.Generic;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class DisplayModelExt
    {
        public static List<DisplayBehavior> GetDisplayBehaviors_WithThisModel(this DisplayModel displayModel)
        {
            var displayBehaviors = InGame.instance.bridge.simulation.factory.GetFactory<DisplayBehavior>().all;
            var results = displayBehaviors.Where(behavior => behavior.displayModel.IsEqual(displayModel));
            return results;
        }
    }
}
