﻿namespace Parser.SignalR.Contracts
{
    public interface ILogFileParserHub
    {
        void SendCommand(string engineId, string serializedCommand);

        void EndParsingSession(string engineId);

        void GetParsingSessionId();
    }
}
