﻿using Assets.Scripts.Simulation.Bloons;
using Assets.Scripts.Unity.Bridge;
using Assets.Scripts.Unity.UI_New.InGame;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class BloonToSimulationExt
    {
        public static Bloon GetSimBloon(this BloonToSimulation bloonToSim)
        {
            return InGame.Bridge.simulation.bloonManager.GetBloonByID(bloonToSim.id);
        }
    }
}