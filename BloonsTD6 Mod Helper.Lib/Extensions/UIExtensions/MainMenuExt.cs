using Assets.Scripts.Unity.UI_New.Main;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class MainMenuExt
    {
        /// <summary>
        /// Get the MainMenu game object
        /// </summary>
        public static GameObject GetUI(this MainMenu mainMenu)
        {
            try
            {
                Scene scene = SceneManager.GetSceneByName("MainMenuUi");
                UnhollowerBaseLib.Il2CppReferenceArray<GameObject> rootGameObjects = scene.GetRootGameObjects();
                GameObject ui = rootGameObjects[0];
                return ui;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}