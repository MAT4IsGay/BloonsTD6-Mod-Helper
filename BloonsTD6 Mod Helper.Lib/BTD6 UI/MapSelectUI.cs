using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace BloonsTD6_Mod_Helper.BTD6_UI
{
    public static class MapSelectUI
    {
        public static Scene? GetScene()
        {
            try
            { return SceneManager.GetSceneByName("MapSelectUI"); }
            catch (ArgumentException)
            { return null; }
        }

        public static Canvas GetCanvas()
        {
            var scene = GetScene();
            if (!scene.HasValue)
                return null;

            var sceneObjects = scene.Value.GetRootGameObjects();
            if (sceneObjects is null || sceneObjects.Count == 0)
                return null;

            const int canvasIndex = 0;
            var canvas = sceneObjects[canvasIndex];
            return canvas.GetComponent<Canvas>();
        }

        public static Toggle GetBeginnerButton()
        {
            return GetCanvas()?.transform.Find("MapSelectScreen/MapDifficulties/BeginnerBtn").GetComponent<Toggle>();
        }
    }
}
