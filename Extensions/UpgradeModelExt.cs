using Assets.Scripts.Models.Towers.Upgrades;
using Assets.Scripts.Unity;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class UpgradeModelExt
    {
        public static bool? IsUpgradeUnlocked(this UpgradeModel upgradeModel)
        {
            var profile = Game.instance.GetProfileModel();
            if (profile is null)
                return null;

            return profile.acquiredUpgrades.Contains(upgradeModel.name);
        }
    }
}
