using UnityEngine;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class CanvasExt
    {
        public static T GetComponent<T>(this Canvas canvas, string componentPath)
        {
            return canvas.transform.Find(componentPath).GetComponent<T>();
        }
    }
}
