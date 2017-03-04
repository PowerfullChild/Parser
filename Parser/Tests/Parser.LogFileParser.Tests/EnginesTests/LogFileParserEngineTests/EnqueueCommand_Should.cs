﻿using System;

using Moq;
using NUnit.Framework;

using Parser.Common.Contracts;
using Parser.Common.Factories;
using Parser.LogFileParser.Contracts;
using Parser.LogFileParser.Engines;
using Parser.LogFileParser.Tests.Mocks;

namespace Parser.LogFileParser.Tests.EnginesTests.LogFileParserEngineTests
{
    [TestFixture]
    public class EnqueueCommand_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenICommandParameterIsNull()
        {
            // Arrange
            var commandResolutionHandler = new Mock<ICommandResolutionHandler>();
            var combatStatisticsContainerFactory = new Mock<ICombatStatisticsContainerFactory>();

            ICommand command = null;

            var logFileParserEngine = new LogFileParserEngine(commandResolutionHandler.Object, combatStatisticsContainerFactory.Object);

            // Act & Assert
            Assert.That(
                () => logFileParserEngine.EnqueueCommand(command),
                Throws.InstanceOf<ArgumentNullException>().With.Message.Contains(nameof(ICommand)));
        }

        [Test]
        public void InvokeICommandResolutionHandler_ResolveCommandOnceWithCorrectParameters()
        {
            // Arrange
            var commandResolutionHandler = new Mock<ICommandResolutionHandler>();
            var combatStatisticsContainerFactory = new Mock<ICombatStatisticsContainerFactory>();

            var combatStatisticsContainer = new Mock<ICombatStatisticsContainer>();

            var command = new Mock<ICommand>();

            var logFileParserEngine = new MockLogFileParserEngine(commandResolutionHandler.Object, combatStatisticsContainerFactory.Object);
            logFileParserEngine.CombatStatisticsContainer = combatStatisticsContainer.Object;

            // Act
            logFileParserEngine.EnqueueCommand(command.Object);

            // Assert
            commandResolutionHandler.Verify(h => h.ResolveCommand(command.Object, combatStatisticsContainer.Object), Times.Once);
        }
    }
}