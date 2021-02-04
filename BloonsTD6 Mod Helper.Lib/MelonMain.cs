using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.InGame;
using BloonsTD6_Mod_Helper.Api;
using MelonLoader;
using System;
using System.Reflection;
using UnityEngine;

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

            foreach (KeyCode key in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(key))
                {
                    DoPatchMethods(mod =>
                    {
                        mod.OnKeyDown(key);
                    });
                }

                if (Input.GetKeyUp(key))
                {
                    DoPatchMethods(mod =>
                    {
                        mod.OnKeyUp(key);
                    });
                }

                if (Input.GetKey(key))
                {
                    DoPatchMethods(mod =>
                    {
                        mod.OnKeyHeld(key);
                    });
                }
            }

            if (InGame.instance is null)
                return;

            NotificationMgr.CheckForNotifications();
        }
        
        
        public static void DoPatchMethods(Action<BloonsTD6Mod> action)
        {
            foreach (var melonMod in MelonHandler.Mods)
            {
                if (melonMod is BloonsTD6Mod mod)
                {
                    action.Invoke(mod);
                }
            }
        }
        
    }
}