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
            NotificationDetails notificationDetails = new NotificationDetails();
            notificationDetails["worldId"] = "";
            notificationDetails["worldName"] = "\n" + Message;
            Console.WriteLine(notificationDetails["worldName"]);

            //NotificationManager.Instance.SendNotification(Player.apiuser.id, "invite", string.Empty, notificationDetails);
        }
    }
}
