using Assets.Scripts.Models.Towers.Upgrades;
using Assets.Scripts.Unity;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class UpgradeModelExt
    {
        public static bool? IsUpgradeUnlocked(this UpgradeModel upgradeModel)
        {
            return Game.instance.GetBtd6Player()?.HasUpgrade(upgradeModel.name);
        }
    }
}