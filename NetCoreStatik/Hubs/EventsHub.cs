using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using NetCoreStatik.Classes;
using NetCoreStatik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreStatik.Hubs
{
    public class EventsHub : Hub
    {
        private Events events;
        public EventsHub()
        {
            events = new Events();

        }

        public override Task OnConnectedAsync()
        {
            string connedId = Context.ConnectionId;
            return base.OnConnectedAsync();
        }
        public void EnterTime(string pageName, string myIp)
        {

            events.pageName = string.IsNullOrEmpty(pageName) ? "index.html" : pageName;
            events.userIp = myIp.Replace("\\n", "").Replace(" ", "");
            events.enterDate = DateTime.Now;
            events.connectionId = this.Context.ConnectionId;
            UsersContext usersContext = Connection.NewConnection();
            
                usersContext.Events.Add(events);
                usersContext.SaveChanges();
         
            
        }
        public override Task OnDisconnectedAsync(Exception exception)
        {
            ExitSaveDb();
            return base.OnDisconnectedAsync(exception);
        }

        public void ExitSaveDb()
        {


                UsersContext usersContext = Connection.NewConnection();
                events = usersContext.Events.Where(a => a.connectionId == this.Context.ConnectionId).SingleOrDefault();
                events.exitDate = DateTime.Now;
                usersContext.SaveChanges();
            
        }
    }
}
