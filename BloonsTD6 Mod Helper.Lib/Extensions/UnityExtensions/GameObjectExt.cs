using UnityEngine;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class GameObjectExt
    {
        public static T GetComponent<T>(this GameObject gameObject, string componentPath)
        {
            return gameObject.transform.Find(componentPath).GetComponent<T>();
        }
    }
}
