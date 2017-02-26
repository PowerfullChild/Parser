﻿using System.Threading.Tasks;

using Microsoft.AspNet.SignalR.Client;

using Bytes2you.Validation;

using Parser.SignalRUtilizationStrategy.Contracts;

namespace Parser.SignalRUtilizationStrategy.Providers
{
    public class HubConnectionProvider : IHubConnectionProvider
    {
        // IHubConnect and IConnection do NOT contain a .Start() method.
        private readonly HubConnection hubConnection;

        public HubConnectionProvider(string url)
        {
            Guard.WhenArgument(url, nameof(url)).IsNullOrEmpty().Throw();

            this.hubConnection = new HubConnection(url);
        }

        public Task Start()
        {
            return this.hubConnection.Start();
        }

        public IHubProxy CreateHubProxy(string hubName)
        {
            Guard.WhenArgument(hubName, nameof(hubName)).IsNullOrEmpty().Throw();

            return this.hubConnection.CreateHubProxy(hubName);
        }
    }
}
