using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
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
            ImageConversion.LoadImage(texture, File.ReadAllBytes(filePath));
            return texture;
        }

        public static Texture2D CreateFromProjResource(this Texture2D texture2D, ResourceManager manager, string resourceName)
        {
            var resource = manager.GetObject(resourceName);
            var resourceBytes = new ImageConverter().ConvertTo(resource, typeof(byte[]));
            ImageConversion.LoadImage(texture2D, (byte[])resourceBytes);
            return texture2D;
        }

        public static Texture2D CreateFromBitmap(this Texture2D texture2D, Bitmap image)
        {
            var resourceBytes = new ImageConverter().ConvertTo(image, typeof(byte[]));
            ImageConversion.LoadImage(texture2D, (byte[])resourceBytes);
            return texture2D;
        }

        public static Sprite CreateSpriteFromTexture(this Texture2D texture2D, float pixelsPerUnit)
        {
            return Sprite.Create(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height), new Vector2() , pixelsPerUnit);
        }
    }
}