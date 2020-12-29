using Assets.Scripts.Models.Bloons;
using Assets.Scripts.Unity;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class BloonModelExt
    {
        public static int? GetIndex(this BloonModel bloonModel)
        {
            var allBloons = Game.instance.GetAllBloonModels();
            for (int i = 0; i < allBloons.Count; i++)
            {
                if (allBloons[i].name.ToLower() == bloonModel.name.ToLower())
                    return i;
            }
            return null;
        }
    }
}