﻿using Assets.Scripts.Models.Rounds;
using System.Collections.Generic;

namespace BloonsTD6_Mod_Helper.Api
{
    public class SessionData
    {
        public static bool IsInPublicCoop { get; set; } = false;
        public static bool IsInOdyssey { get; set; } = false;
        public static bool IsInRace { get; set; } = false;

        public static RoundSetModel RoundSet { get; set; }
        public static Dictionary<string, int> PoppedBloons { get; set; } = new Dictionary<string, int>();
    }
}
