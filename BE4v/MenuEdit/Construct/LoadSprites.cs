using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BE4v.MenuEdit.Construct
{
    public static class LoadSprites
    {
        private static Sprite be4vLogoSprite = null;
        public static Sprite be4vLogo
        {
            get
            {
                if (be4vLogoSprite == null)
                {
                    be4vLogoSprite = Utils.Sprites.DownloadSprite("http://37.230.228.70:5000/logo.png", 64, 64);
                }
                return be4vLogoSprite;
            }
        }

        private static Sprite onButtonSprite = null;
        public static Sprite onButton
        {
            get
            {
                if (onButtonSprite == null)
                {
                    onButtonSprite = Utils.Sprites.DownloadSprite("http://37.230.228.70:5000/on.png", 64, 64);
                }
                return onButtonSprite;
            }
        }

        private static Sprite offButtonSprite = null;
        public static Sprite offButton
        {
            get
            {
                if (offButtonSprite == null)
                {
                    offButtonSprite = Utils.Sprites.DownloadSprite("http://37.230.228.70:5000/off.png", 64, 64);
                }
                return offButtonSprite;
            }
        }

        private static Sprite trashIcoSprite = null;
        public static Sprite trashIco
        {
            get
            {
                if (trashIcoSprite == null)
                {
                    trashIcoSprite = Utils.Sprites.DownloadSprite("http://37.230.228.70:5000/trash.png", 64, 64);
                }
                return trashIcoSprite;
            }
        }
    }
}
