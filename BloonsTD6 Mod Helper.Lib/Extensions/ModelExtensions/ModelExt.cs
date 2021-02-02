using Assets.Scripts.Models;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class ModelExt
    {
        public static T Duplicate<T>(this T model) where T : Model
        {
            return model.Clone().Cast<T>();
        }

        /*public static List<T> GetItemsFromAll<T> (this T model, string collectionName) where T : Model
        {

        }*/
    }
}