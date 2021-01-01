using Assets.Scripts.Models;
using Assets.Scripts.Models.Pets;
using BloonsTD6_Mod_Helper.Api.Utils;
using System.Collections.Generic;
using System.Linq;
using UnhollowerBaseLib;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class PetModelBehaviorExt
    {
        public static bool HasBehavior<T>(this PetModel model) where T : Model
        {
            return BehaviorUtils_Il2CppReferenceArray.HasBehavior<PetBehaviorModel, T>(model.behaviors);
        }

        public static T GetBehavior<T>(this PetModel model) where T : Model
        {
            return BehaviorUtils_Il2CppReferenceArray.GetBehavior<PetBehaviorModel, T>(model.behaviors);
        }

        public static List<T> GetBehaviors<T>(this PetModel model) where T : Model
        {
            return BehaviorUtils_Il2CppReferenceArray.GetBehaviors<PetBehaviorModel, T>(model.behaviors)?.ToList();
        }

        public static void AddBehavior<T>(this PetModel model, T behavior) where T : Model
        {
            BehaviorUtils_Il2CppReferenceArray.AddBehavior(model.behaviors, behavior, out Il2CppReferenceArray<PetBehaviorModel> moddedArray);
            model.behaviors = moddedArray;
        }

        public static void RemoveBehavior<T>(this PetModel model) where T : Model
        {
            BehaviorUtils_Il2CppReferenceArray.RemoveBehavior<PetBehaviorModel, T>(model.behaviors, out Il2CppReferenceArray<PetBehaviorModel> moddedArray);
            model.behaviors = moddedArray;
        }

        public static void RemoveBehavior<T>(this PetModel model, T behavior) where T : Model
        {
            BehaviorUtils_Il2CppReferenceArray.RemoveBehavior<PetBehaviorModel, T>(model.behaviors, behavior, out Il2CppReferenceArray<PetBehaviorModel> moddedArray);
            model.behaviors = moddedArray;
        }

        public static void RemoveBehaviors<T>(this PetModel model) where T : Model
        {
            BehaviorUtils_Il2CppReferenceArray.RemoveBehaviors<PetBehaviorModel, T>(model.behaviors, out Il2CppReferenceArray<PetBehaviorModel> moddedArray);
            model.behaviors = moddedArray;
        }
    }
}
