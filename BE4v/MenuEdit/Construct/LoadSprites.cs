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
                    be4vLogoSprite = Utils.Sprites.DownloadSprite("http://icefrag.ru/public/logo.png", 64, 64);
                }
                return be4vLogoSprite;
            }
        }
    }
}
