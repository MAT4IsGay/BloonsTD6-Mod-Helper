using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace BloonsTD6_Mod_Helper.BTD6_UI
{
    public class TitleScreenUI
    {
        public static Canvas GetCanvas()
        {
            var scene = SceneManager.GetSceneByName("TitleScreenUI");
            return scene.GetRootGameObjects()[3].GetComponent<Canvas>();
        }

        public static Button GetStartButton()
        {
            return GetCanvas().transform.Find("ScreenBoxer/TitleScreen/Start").GetComponent<Button>();
        }
    }
}
