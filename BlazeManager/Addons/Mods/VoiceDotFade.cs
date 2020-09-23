using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Addons.Mods
{
    public static class VoiceDotFade
	{
		public static void Toggle_Enable()
		{
			BlazeManager.SetForPlayer("VoiceDotFade", !BlazeManager.GetForPlayer<bool>("VoiceDotFade"));
			RefreshStatus();
		}

		public static void RefreshStatus()
		{
			bool toggle = BlazeManager.GetForPlayer<bool>("VoiceDotFade");
			BlazeManagerMenu.Main.togglerList["VoiceDotFade"].btnOn.SetActive(toggle);
			BlazeManagerMenu.Main.togglerList["VoiceDotFade"].btnOff.SetActive(!toggle);
			if (toggle)
				OnEnable();
			else
				OnDisable();
		}

		public static bool OnDisable()
		{
			var obj = GameObject.Find(objName);
			foreach (var a in obj.GetComponents<FadeCycleEffect>())
			{
				if (speed == -1 || minAlpha == -1 || maxAlpha == -1)
				{
					speed = a.speed;
					minAlpha = a.minAlpha;
					maxAlpha = a.maxAlpha;
				}
				a.Destroy();
			}
			return true;
		}

		public static bool OnEnable()
		{
			var obj = GameObject.Find(objName);
			FadeCycleEffect fadeObj = obj.AddComponent<FadeCycleEffect>();
			fadeObj.speed = speed;
			fadeObj.minAlpha = minAlpha;
			fadeObj.maxAlpha = maxAlpha;
			return true;
		}

		private static readonly string objName = "VoiceDotDisabled";

		private static float speed = -1;

		private static float minAlpha = -1;

		private static float maxAlpha = -1;
	}
}
