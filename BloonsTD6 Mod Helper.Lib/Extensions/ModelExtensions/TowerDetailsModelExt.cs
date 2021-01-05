using Assets.Scripts.Models.TowerSets;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class TowerDetailsModelExt
    {
        public static bool IsHero(this TowerDetailsModel towerDetailsModel)
        {
            var heroDetailsModel = towerDetailsModel.TryCast<HeroDetailsModel>();
            var isHero = (heroDetailsModel != null);
            return isHero;
        }
    }
}