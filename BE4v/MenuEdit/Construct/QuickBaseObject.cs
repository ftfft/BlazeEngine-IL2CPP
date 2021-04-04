using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace BE4v.MenuEdit.Construct
{
    public class QuickBaseObject
    {
        public GameObject gameObject;

        public string @tag;

        public string @location;

        public float x;

        public float y;

        public bool isCustom = true;

        // public static readonly Vector2 offsetButton = QuickMenu_Utils.BaseButton().transform.MonoCast<RectTransform>().anchoredPosition;
    }
}
