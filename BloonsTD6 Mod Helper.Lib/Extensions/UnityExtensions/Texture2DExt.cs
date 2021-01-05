using System.IO;
using System.Linq;
using UnityEngine;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class Texture2DExt
    {
        public static void SaveToPNG(this Texture2D texture, string filePath)
        {
            var bytes = ImageConversion.EncodeToPNG(texture).ToArray();
            File.Create(filePath).Write(bytes, 0, bytes.Length);
        }

        public static Texture2D LoadFromFile(this Texture2D texture, string filePath)
        {
            Texture2D loadedTexture = new Texture2D(2, 2);
            ImageConversion.LoadImage(loadedTexture, File.ReadAllBytes(filePath));
            return loadedTexture;
        }
    }
}