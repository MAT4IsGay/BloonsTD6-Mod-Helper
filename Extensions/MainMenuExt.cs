using Assets.Scripts.Unity.UI_New.Main;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class MainMenuExt
    {
        public static GameObject GetUI(this MainMenu mainMenu)
        {
            try
            {
                var scene = SceneManager.GetSceneByName("MainMenuUi");
                var rootGameObjects = scene.GetRootGameObjects();
                var ui = rootGameObjects[0];
                return ui;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}