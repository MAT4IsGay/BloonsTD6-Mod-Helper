using Assets.Scripts.Models.Towers.Behaviors.Abilities;
using Assets.Scripts.Unity.Bridge;
using Assets.Scripts.Unity.UI_New.InGame;
using System.Collections.Generic;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class AbilityModelExt
    {
        public static List<AbilityToSimulation> GetAbilitySims(this AbilityModel abiltyModel)
        {
            Il2CppSystem.Collections.Generic.List<AbilityToSimulation> abilitySims = InGame.instance?.bridge?.GetAllAbilities(true);
            if (abilitySims is null || !abilitySims.Any())
                return null;

            List<AbilityToSimulation> results = abilitySims.Where(ability => ability.ability.abilityModel.IsEqual(abiltyModel)).ToSystemList();
            return results;
        }
    }
}
