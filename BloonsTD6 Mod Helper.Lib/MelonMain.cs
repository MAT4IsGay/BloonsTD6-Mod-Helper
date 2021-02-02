using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.InGame;
using BloonsTD6_Mod_Helper.Api;
using MelonLoader;
using System;
using System.Reflection;

namespace BloonsTD6_Mod_Helper
{
    internal class MelonMain : MelonMod
    {
        internal static string modDir = $"{Environment.CurrentDirectory}\\Mods\\{Assembly.GetExecutingAssembly().GetName().Name}";
        public static string coopMessageCode = "BTD6_ModHelper";

        public override void OnApplicationStart()
        {
            MelonLogger.Log("Mod has finished loading");
        }

        public override void OnUpdate()
        {
            if (Game.instance is null)
                return;

            if (InGame.instance is null)
                return;

            NotificationMgr.CheckForNotifications();
        }
    }
}