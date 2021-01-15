using Assets.Scripts.Models.Rounds;
using Assets.Scripts.Unity.Bridge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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