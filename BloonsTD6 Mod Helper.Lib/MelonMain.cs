﻿using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.InGame;
using BloonsTD6_Mod_Helper.Api;
using BloonsTD6_Mod_Helper.Api.InGame_Mod_Options;
using MelonLoader;
using System;
using System.Reflection;
using UnityEngine;
using BloonsTD6_Mod_Helper.Extensions;

namespace BloonsTD6_Mod_Helper
{
    internal class MelonMain : MelonMod
    {
        internal static string modDir = $"{Environment.CurrentDirectory}\\Mods\\{Assembly.GetExecutingAssembly().GetName().Name}";
        public static string coopMessageCode = "BTD6_ModHelper";

        private bool useModOptionsDEBUG = false;
        private ModOptionsMenu modOptionsUI;

        public override void OnApplicationStart()
        {
            MelonLogger.Log("Mod has finished loading");
        }

        public void Test()
        {
            MelonLogger.Log("AAAA");
        }

        public override void OnUpdate()
        {
            if (Game.instance is null)
                return;

            var scene = BTD6_UI.MainMenuUI.GetScene();
            if (scene != null)
            {
                var playButton = BTD6_UI.MainMenuUI.GetXpBarText();
                //var text = playButton.GetComponentInChildren<NK_TextMeshProUGUI>();
                if (playButton != null)
                    playButton.SetText(playButton.localizeKey, "aaa");
            }
            

            /*if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                var playButton = BTD6_UI.MainMenuUI.GetPlayButton();
                var text = playButton.GetComponentInChildren<NK_TextMeshProUGUI>();
                text.SetText(text.localizeKey, "aaa");
            }*/

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

            
            if (useModOptionsDEBUG && modOptionsUI is null)
                modOptionsUI = new ModOptionsMenu();

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