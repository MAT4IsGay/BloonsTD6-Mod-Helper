﻿using Assets.Scripts.Utils;
using Harmony;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

namespace BloonsTD6_Mod_Helper.Api
{
    public class SpriteRegister
    {
        public static Dictionary<string, Sprite> register = new Dictionary<string, Sprite>();

        public Texture2D TextureFromPNG(string path)
        {
            Texture2D text = new Texture2D(2, 2);

            if (!ImageConversion.LoadImage(text, File.ReadAllBytes(path)))
            {
                throw new Exception("Could not acquire texture from file " + Path.GetFileName(path) + ".");
            }

            return text;
        }

        private Texture2D TextureFromLink(string path, string url)
        {
            using (WebClient client = new WebClient())
            {
                if (!File.Exists(path))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(path));
                    client.DownloadFile(url, path);
                }
            }
            Texture2D text = new Texture2D(2, 2);

            if (!ImageConversion.LoadImage(text, File.ReadAllBytes(path)))
            {
                throw new Exception("Could not acquire texture from file " + Path.GetFileName(path) + ".");
            }

            return text;
        }

        /// <summary>
        /// Create a Sprite object and add it to the register. 
        /// See <a href="https://gist.github.com/BowDown097/21e4940f72fde5d7c4480b24c4a21a53">this GitHub gist</a> for an example implementation.
        /// </summary>
        /// <param name="path">The location to an image file to be converted.</param>
        /// <param name="pivot">No clue what this does, best bet is using default.</param>
        public void RegisterSpriteFromImage(string path, Vector2 pivot) => RegisterSpriteFromImage(path, pivot, out _);

        /// <summary>
        /// Create a Sprite object and add it to the register. Contains out parameter to obtain the GUID, which is useful when working with SpriteReferences. 
        /// See <a href="https://gist.github.com/BowDown097/0dd7e40b278c4c064b6177d03aad1ee3">this GitHub gist</a> for an example implementation.
        /// </summary>
        /// <param name="path">The location to an image file to be converted.</param>
        /// <param name="pivot">No clue what this does, best bet is using default.</param>
        /// <param name="guid">Obtain the GUID for use in SpriteReferences.</param>
        public void RegisterSpriteFromImage(string path, Vector2 pivot, out string guid)
        {
            Texture2D pngTexture = TextureFromPNG(path);
            guid = path; //Path.GetFileNameWithoutExtension(path);
            register.Add(guid, Sprite.Create(pngTexture, new Rect(0.0f, 0.0f, pngTexture.width, pngTexture.height), pivot));
        }

        public void RegisterSpriteFromURL(string path, string url, Vector2 pivot, out string guid)
        {
            Texture2D pngTexture = TextureFromLink(path, url);
            guid = path;//Path.GetFileNameWithoutExtension(path);
            register.Add(guid, Sprite.Create(pngTexture, new Rect(0.0f, 0.0f, pngTexture.width, pngTexture.height), pivot));
        }
    }
}
