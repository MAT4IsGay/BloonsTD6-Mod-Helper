using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace BloonsTD6_Mod_Helper.BTD6_UI
{
    public class MainMenuUI
    {
        public static Canvas GetCanvas()
        {
            var scene = SceneManager.GetSceneByName("MainMenuUi");
            return scene.GetRootGameObjects()[0].GetComponent<Canvas>();
        }

        public static Button GetMonkeysButton()
        {
            return GetCanvas().transform.Find("MainMenu/BottomButtonGroup/Monkeys/MonkeysAnim/Button").GetComponent<Button>();
        }

        public static Button GetHeroesButton()
        {
            return GetCanvas().transform.Find("MainMenu/BottomButtonGroup/Heroes/HeroesAnim/Button").GetComponent<Button>();
        }

        public static Button GetPlayButton()
        {
            return GetCanvas().transform.Find("MainMenu/BottomButtonGroup/Play/PlayAnim/Button").GetComponent<Button>();
        }

        public static Button GetCoopButton()
        {
            return GetCanvas().transform.Find("MainMenu/BottomButtonGroup/CoOp/CoopAnim/Button").GetComponent<Button>();
        }

        public static Button GetPowersButton()
        {
            return GetCanvas().transform.Find("MainMenu/BottomButtonGroup/Powers/PowersAnim/Button").GetComponent<Button>();
        }

        public static Button GetKnowledgeButton()
        {
            return GetCanvas().transform.Find("MainMenu/BottomButtonGroup/Knowledge/KnowledgeAnim/Button").GetComponent<Button>();
        }

        public static Button GetSettingsButton()
        {
            return GetCanvas().transform.Find("MainMenu/Settings/Button").GetComponent<Button>();
        }

        public static Button GetAchievementsButton()
        {
            return GetCanvas().transform.Find("MainMenu/Achievements/Button").GetComponent<Button>();
        }

        public static Button GetStoreButton()
        {
            return GetCanvas().transform.Find("MainMenu/Store/Button").GetComponent<Button>();
        }

        public static Button GetTrophyStoreButton()
        {
            return GetCanvas().transform.Find("MainMenu/TrophyStore/Button").GetComponent<Button>(); ;
        }

        public static Button GetExitButton()
        {
            return GetCanvas().transform.Find("MainMenu/TrophyStore/Button").GetComponent<Button>();
        }

        public static NK_TextMeshProUGUI GetXpBarText()
        {
            return GetCanvas().transform.Find("MainMenu/PlayerInfo/XpBar/Text").GetComponent<NK_TextMeshProUGUI>();
        }
    }
}