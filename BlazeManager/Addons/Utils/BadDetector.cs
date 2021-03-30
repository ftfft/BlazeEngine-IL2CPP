using System;
using UnityEngine;
using VRC;
using VRC.UI;
using VRC.Core;

public static class BadDetector
{
    public static bool IsBad(this Vector3 value)
    {
        if (IsBad(value.x)) return true;
        if (IsBad(value.y)) return true;
        if (IsBad(value.z)) return true;
        return false;
    }

    public static bool IsBad(this float value)
    {
        if (float.IsNaN(value)) return true;
        if (float.IsInfinity(value)) return true;
        return false;
    }
}