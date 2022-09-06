
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using praca_magisterska.DAL.DbModels;
using praca_magisterska_API.Interfaces;
using praca_magisterska_API.Models;
using praca_magisterska_API.Models.UserController;

namespace praca_magisterska_API.Hubs
{
    public class UserConnection
    {
        public string ConnectionID { get; set; }
        public string Username { get; set; }
        public string Surname { get; set; }
        public string ClassID { get; set; }
        public string StudentID { get; set; }

    }
    public static class UserHandler
    {
        public static HashSet<UserConnection> ConnectedIds = new HashSet<UserConnection>();
    }

    public class MessageHub : Hub<IClient>
    {
        public async Task SendMessage(string connectionID, Message message)
        {

            await Clients.Client(connectionID).ReceiveMessage(message);
        }

        public override Task OnConnectedAsync()
        {
           UserConnection user = new UserConnection();
            var dataString = (Context.GetHttpContext().Request.Query["value"]).ToString();
            var data = dataString.Split("?");
            user.ConnectionID = Context.ConnectionId;
            user.Username = data[0];
            user.Surname = data[1];
            user.ClassID = data[2];
            user.StudentID = data[3];

            UserHandler.ConnectedIds.Add(user);
            Debug.WriteLine(Context.ConnectionId + "connected");

            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception exception)
        {
            UserHandler.ConnectedIds.RemoveWhere(c => c.ConnectionID == Context.ConnectionId);
            Debug.WriteLine(Context.ConnectionId + " disconnected");
            return base.OnDisconnectedAsync(exception);
        }
    }

}
