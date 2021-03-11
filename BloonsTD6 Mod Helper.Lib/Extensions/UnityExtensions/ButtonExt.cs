using System;
using UnityEngine.UI;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class ButtonExt
    {
        public delegate void funcDelegate();

        public static void AddOnClick(this Button button, funcDelegate funcToExecute)
        {
            button.onClick.AddListener(new Action(() => { funcToExecute(); }));
        }
    }
}