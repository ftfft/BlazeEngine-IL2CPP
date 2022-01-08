using System;
using System.Net;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BE4v.Utils
{
    public static class Sprites
    {
        public static Sprite DownloadSprite(string url, int width, int height)
        {
            IL2WebClient webClient = new IL2WebClient();
            IntPtr bytes = webClient.DownloadData(url);

            Texture2D texture = new Texture2D(width, height);
            if (texture.LoadImage(bytes))
                texture.Apply();

            Sprite sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, width, height), new Vector2(0.5f, 0.5f), 100.0f, 0, SpriteMeshType.FullRect, false);
            sprite.hideFlags |= HideFlags.DontUnloadUnusedAsset;
            return sprite;
        }

        public static void SaveSpriteImg(Sprite sprite, string name)
        {
            Texture2D texture = sprite.texture;
            Texture2D unblockTexture = FileDebug.createReadabeTexture2D(texture);
            unblockTexture.EncodeToPNG_Save(name);
        }
    }
}
