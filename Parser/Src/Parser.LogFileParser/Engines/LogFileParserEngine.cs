﻿using System.Collections.Generic;

using Bytes2you.Validation;

using Parser.Common.Contracts;
using Parser.Common.Factories;
using Parser.LogFileParser.Contracts;

namespace Parser.LogFileParser.Engines
{
    public class LogFileParserEngine : ILogFileParserEngine
    {
        private readonly ICommandResolutionHandler commandResolutionHandler;
        private readonly ICombatStatisticsContainer combatStatisticsContainer;

        private readonly Queue<ICommand> commandsQueue;

        public LogFileParserEngine(ICommandResolutionHandler commandResolutionHandler, ICombatStatisticsContainerFactory combatStatisticsContainerFactory)
        {
            Guard.WhenArgument(commandResolutionHandler, nameof(ICommandResolutionHandler)).IsNull().Throw();
            Guard.WhenArgument(combatStatisticsContainerFactory, nameof(ICombatStatisticsContainerFactory)).IsNull().Throw();

            this.commandResolutionHandler = commandResolutionHandler;
            this.combatStatisticsContainer = combatStatisticsContainerFactory.CreateCombatStatisticsContainer();

            this.commandsQueue = new Queue<ICommand>();

            // TODO: Async parsing
        }

        public void EnqueueCommand(ICommand command)
        {
            Guard.WhenArgument(command, nameof(ICommand)).IsNull().Throw();

            this.commandsQueue.Enqueue(command);
        }

        public ICombatStatisticsContainer GetComabtStatistics()
        {
            // TODO: 
            return this.combatStatisticsContainer;
        }
    }
}
