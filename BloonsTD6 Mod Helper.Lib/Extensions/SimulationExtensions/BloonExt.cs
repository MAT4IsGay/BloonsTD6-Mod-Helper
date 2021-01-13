using Assets.Scripts.Models.Bloons;
using Assets.Scripts.Simulation.Bloons;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.Bridge;
using Assets.Scripts.Unity.UI_New.InGame;
using System.Runtime.InteropServices;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class BloonExt
    {
        public static void SetCamo(this Bloon bloon, bool isCamo)
        {
            var bloonModel = bloon.bloonModel;
            bloon.SetBloonStatus(isCamo, bloonModel.isFortified, bloonModel.isGrow);
        }

        public static void SetFortified(this Bloon bloon, bool isFortified)
        {
            var bloonModel = bloon.bloonModel;
            bloon.SetBloonStatus(bloonModel.isCamo, isFortified, bloonModel.isGrow);
        }

        public static void SetRegrow(this Bloon bloon, bool isRegrow)
        {
            var bloonModel = bloon.bloonModel;
            bloon.SetBloonStatus(bloonModel.isCamo, bloonModel.isFortified, isRegrow);
        }

        public static void RemoveBloonStatus(this Bloon bloon, bool removeCamo, bool removeFortify, bool removeRegrow)
        {
            string bloonId = bloon.bloonModel.id;

            if (bloonId.Contains("Camo") && removeCamo)
                bloonId = bloonId.Replace("Camo", "");
            if (bloonId.Contains("Fortified") && removeFortify)
                bloonId = bloonId.Replace("Fortified", "");
            if (bloonId.Contains("Regrow") && removeRegrow)
                bloonId = bloonId.Replace("Regrow", "");

            var newBloonModel = Game.instance.model.GetBloonModel(bloonId);
            bloon.bloonModel = newBloonModel;
            bloon.UpdateDisplay();
        }

        public static void SetBloonStatus(this Bloon bloon, [Optional] bool setCamo, [Optional] bool setFortified, [Optional] bool setRegrow)
        {
            var model = Game.instance.model;
            var bloonModel = bloon.bloonModel;

            string camoText = (setCamo && model.GetBloonModel(bloonModel.baseId + "Camo") != null) ? "Camo" : "";
            string fortifiedText = (setFortified && model.GetBloonModel(bloonModel.baseId + "Fortified") != null) ? "Fortified" : "";
            string regrowText = (setRegrow && model.GetBloonModel(bloonModel.baseId + "Regrow") != null) ? "Regrow" : "";

            string newBloonID = bloonModel.baseId + regrowText + fortifiedText + camoText;
            bloon.bloonModel = Game.instance.model.GetBloonModel(newBloonID);
            bloon.UpdateDisplay();
        }

        public static BloonToSimulation GetBloonToSim(this Bloon bloon)
        {
            return InGame.Bridge.GetAllBloons().FirstOrDefault(b => b.id == bloon.Id);
        }
    }
}