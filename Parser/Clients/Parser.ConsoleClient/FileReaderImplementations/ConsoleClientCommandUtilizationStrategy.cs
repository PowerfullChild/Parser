﻿using System;

using Parser.Common.Contracts;
using Parser.LogFile.Reader.Contracts;

namespace Parser.ConsoleClient.FileReaderImplementations
{
    internal class ConsoleClientCommandUtilizationStrategy : ICommandUtilizationStrategy
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void UtilizeCommand(ICommand command)
        {
        }
    }
}
