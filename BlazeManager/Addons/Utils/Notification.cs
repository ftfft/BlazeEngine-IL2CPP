using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Transmtn.DTO.Notifications;

namespace Addons.Utils
{
    public class Notification
    {
        public static void SendMessage(VRC.Player Player, string Message)
        {
            if (Player == null)
                return;

            NotificationDetails notificationDetails = new NotificationDetails();
            notificationDetails["worldId"] = RoomManager.currentRoom.id + ":" + RoomManager.currentRoom.currentInstanceIdWithTags;
            notificationDetails["worldName"] = "\n" + Message;
            notificationDetails["message"] = "\u0001";

            NotificationManager.Instance.SendNotification(Player.apiuser.id, "invite", string.Empty, notificationDetails);
        }
    }
}
