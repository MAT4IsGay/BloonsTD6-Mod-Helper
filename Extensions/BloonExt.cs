using Assets.Scripts.Models.Bloons;
using Assets.Scripts.Simulation.Bloons;
using Assets.Scripts.Unity;
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

            var newBloonModel = Game.instance.GetBloonModel(bloonId);
            bloon.bloonModel = newBloonModel;
        }

        public static void SetBloonStatus(this Bloon bloon, [Optional] bool setCamo, [Optional] bool setFortified, [Optional] bool setRegrow)
        {
            var bloonModel = bloon.bloonModel;
            string camoText = "";
            string fortifiedText = "";
            string regrowText = "";

            if (setCamo)
            {
                bool doesCamoExist = Game.instance.GetBloonModel(bloonModel.baseId + "Camo") != null;
                if (doesCamoExist)
                    camoText = "Camo";
            }

            if (setFortified)
            {
                bool doesFortifiedExist = Game.instance.GetBloonModel(bloonModel.baseId + "Fortified") != null;
                if (doesFortifiedExist)
                    fortifiedText = "Fortified";
            }

            if (setRegrow)
            {
                bool doesHaveRegrow = Game.instance.GetBloonModel(bloonModel.baseId + "Regrow") != null;
                if (doesHaveRegrow)
                    regrowText = "Regrow";
            }

            string newBloonID = bloonModel.baseId + regrowText + fortifiedText + camoText;
            bloon.bloonModel = Game.instance.GetBloonModel(newBloonID);
        }
    }
}