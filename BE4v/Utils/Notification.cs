using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Transmtn.DTO.Notifications;

namespace BE4v.Utils
{
    public class Notification
    {
        public static void SendInvite(VRC.Player Player, string worldId)
        {
            if (Player == null)
                return;

            NotificationDetails notificationDetails = new NotificationDetails();
            notificationDetails["worldId"] = worldId;
            NotificationManager.Instance.SendNotification(Player.user.id, "requestInvite", string.Empty, notificationDetails);
        }
    }
}
