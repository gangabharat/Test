using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Arduino.Hubs
{
    [HubName("mynotificationHub")]
    public class MyNotificationHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }

        public static void Send()
        {
            try
            {
                IHubContext context = GlobalHost.ConnectionManager.GetHubContext<MyNotificationHub>();
                context.Clients.All.displayStatus();
                //context.Clients.All.dis
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}