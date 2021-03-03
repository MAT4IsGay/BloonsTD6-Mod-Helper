using Assets.Scripts.Models;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class ModelExt
    {
        /// <summary>
        /// Create a new and seperate copy of this object. Same as using:  .Clone().Cast();
        /// </summary>
        /// <typeparam name="T">Type of object you want to cast to when duplicating. Done automatically</typeparam>
        public static T Duplicate<T>(this T model) where T : Model
        {
            return model.Clone().Cast<T>();
        }

        /*public static List<T> GetItemsFromAll<T> (this T model, string collectionName) where T : Model
        {

        }*/
    }
}