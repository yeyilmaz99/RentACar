using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace WebAPI.Hubs
{
	public class PayHub:Hub
	{
		public static readonly IDictionary<string, string> TransactionConnections = new Dictionary<string, string>();

		public void RegisterTransaction(string token)
		{
			var connectionId = Context.ConnectionId;
			TransactionConnections[token] = connectionId;

        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            var connectionId = Context.ConnectionId;
            var item = TransactionConnections.FirstOrDefault(p => p.Value == connectionId);
            TransactionConnections.Remove(connectionId);
            return base.OnDisconnectedAsync(exception);
        }

    }
}

