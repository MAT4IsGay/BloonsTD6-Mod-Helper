﻿using Assets.Scripts.Simulation.Bloons;
using Harmony;

namespace BloonsTD6_Mod_Helper.Patches.Bloons
{
    [HarmonyPatch(typeof(Bloon), nameof(Bloon.Leaked))]
    internal class Blooon_Leaked
    {
        [HarmonyPrefix]
        internal static bool Prefix(Bloon __instance)
        {
            bool result = true;
            MelonMain.DoPatchMethods(mod => result &= mod.PreBloonLeaked(__instance));
            return result;
        }

        [HarmonyPostfix]
        internal static void Postfix(Bloon __instance)
        {
            MelonMain.DoPatchMethods(mod => mod.PostBloonLeaked(__instance));
        }
    }
}