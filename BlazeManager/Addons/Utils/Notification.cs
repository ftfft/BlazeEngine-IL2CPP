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
            notificationDetails["message"] = Message;
            Console.WriteLine(notificationDetails.ToString());
            NotificationManager.Instance.SendNotification(Player.user.id, "requestInvite", string.Empty, notificationDetails);
        }
    }
}
