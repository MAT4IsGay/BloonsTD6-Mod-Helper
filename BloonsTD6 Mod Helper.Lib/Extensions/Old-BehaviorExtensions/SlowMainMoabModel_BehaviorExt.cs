using Assets.Scripts.Models;
using Assets.Scripts.Models.Bloons;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using BloonsTD6_Mod_Helper.Api.Utils;
using System.Collections.Generic;
using System.Linq;
using UnhollowerBaseLib;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class SlowMainMoabModel_BehaviorExt
    {
        public static bool HasBehavior<T>(this SlowMaimMoabModel model) where T : Model
        {
            return BehaviorUtils_Il2CppReferenceArray.HasBehavior<BloonBehaviorModel, T>(model.behaviors);
        }

        public static T GetBehavior<T>(this SlowMaimMoabModel model) where T : Model
        {
            return BehaviorUtils_Il2CppReferenceArray.GetBehavior<BloonBehaviorModel, T>(model.behaviors);
        }

        public static List<T> GetBehaviors<T>(this SlowMaimMoabModel model) where T : Model
        {
            return BehaviorUtils_Il2CppReferenceArray.GetBehaviors<BloonBehaviorModel, T>(model.behaviors)?.ToList();
        }

        public static void AddBehavior<T>(this SlowMaimMoabModel model, T behavior) where T : Model
        {
            BehaviorUtils_Il2CppReferenceArray.AddBehavior(model.behaviors, behavior, out Il2CppReferenceArray<BloonBehaviorModel> moddedArray);
            model.behaviors = moddedArray;
        }

        public static void RemoveBehavior<T>(this SlowMaimMoabModel model) where T : Model
        {
            
            BehaviorUtils_Il2CppReferenceArray.RemoveBehavior<BloonBehaviorModel, T>(model.behaviors, out Il2CppReferenceArray<BloonBehaviorModel> moddedArray);
            model.behaviors = moddedArray;
        }

        public static void RemoveBehavior<T>(this SlowMaimMoabModel model, T behavior) where T : Model
        {
            BehaviorUtils_Il2CppReferenceArray.RemoveBehavior(model.behaviors, behavior, out Il2CppReferenceArray<BloonBehaviorModel> moddedArray);
            model.behaviors = moddedArray;
        }

        public static void RemoveBehaviors<T>(this SlowMaimMoabModel model) where T : Model
        {
            BehaviorUtils_Il2CppReferenceArray.RemoveBehaviors<BloonBehaviorModel, T>(model.behaviors, out Il2CppReferenceArray<BloonBehaviorModel> moddedArray);
            model.behaviors = moddedArray;
        }
    }
}
