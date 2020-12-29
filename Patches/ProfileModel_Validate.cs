using Assets.Scripts.Models.Profile;
using Harmony;
using MelonLoader;

namespace BloonsTD6_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(ProfileModel), nameof(ProfileModel.Validate))]
    internal class ProfileModel_Validate
    {
        internal static ProfileModel profileModel;

        [HarmonyPostfix]
        internal static void Postfix(ProfileModel __instance)
        {
            profileModel = __instance;
            MelonLogger.Log("Profile model has been set================");
        }
    }
}
