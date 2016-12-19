using IdeaTinder.Models;
using Microsoft.AspNet.SignalR;

namespace IdeaTinder.Hubs
{
    public class ChatHub : Hub
    {
        public void Send(string name, string message)
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage(name, message);
        }

        public void Read()
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage(Ideas.Get());
        }
    }
}