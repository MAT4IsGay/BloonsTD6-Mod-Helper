using Assets.Scripts.Models.Rounds;
using Assets.Scripts.Unity.Bridge;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class UnityToSimulationExt
    {
        public static void SetRoundSet(this UnityToSimulation unityToSimulation, RoundSetModel roundSet)
        {
            Api.SessionData.RoundSet = roundSet;
        }
    }
}