using Assets.Scripts.Utils;
using BloonsTD6_Mod_Helper.Api;
using Harmony;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace BloonsTD6_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(ResourceLoader), nameof(ResourceLoader.LoadSpriteFromSpriteReferenceAsync))]
    internal class ResourceLoader_LoadSpriteFromSpriteReferenceAsync
    {
        [HarmonyPostfix]
        internal static void Postfix(ref SpriteReference reference, ref Image image)
        {
            /*MelonLogger.Log(reference.GUID);
            MelonLogger.Log(reference.guidRef);
            MelonLogger.Log(image.name);
            MelonLogger.Log(image.sprite.name);*/
            if (reference == null || image == null || !SpriteRegister.register.Any())
                return;

            foreach (KeyValuePair<string, Sprite> entry in SpriteRegister.register)
            {
                if (entry.Key != reference.GUID)
                    continue;

                Sprite val = entry.Value;
                if (entry.Value == null)
                {
                    Texture2D pngTexture = SpriteRegister.Instance.TextureFromPNG(entry.Key);
                    val = Sprite.Create(pngTexture, new Rect(0.0f, 0.0f, pngTexture.width, pngTexture.height), default);
                }

                image.canvasRenderer.SetTexture(val.texture);
                image.sprite = val;
            }
        }
    }
}
