﻿using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;

namespace Parser.LogFile.SignalR.Contracts
{
    public interface IHubConnectionProvider
    {
        Task Start();

        void Stop();

        IHubProxy CreateHubProxy(string hubName);
    }
}
