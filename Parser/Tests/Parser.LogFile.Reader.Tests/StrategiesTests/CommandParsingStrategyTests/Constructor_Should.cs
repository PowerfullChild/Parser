﻿using System;

using Moq;
using NUnit.Framework;

using Parser.Common.Factories;
using Parser.LogFile.Reader.Contracts;
using Parser.LogFile.Reader.Strategies;

namespace Parser.LogFile.Reader.Tests.StrategiesTests.CommandParsingStrategyTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenICommandFactoryParameterIsNull()
        {
            // Arrange
            ICommandFactory commandFactory = null;

            // Act & Assert
            Assert.That(
                () => new CommandParsingStrategy(commandFactory),
                Throws.InstanceOf<ArgumentNullException>().With.Message.Contains(nameof(ICommandFactory)));
        }

        [Test]
        public void CreateCorrectInstance_WhenConstructorParametersAreValid()
        {
            // Arrange 
            var commandFactory = new Mock<ICommandFactory>();

            // Act
            var actualInstance = new CommandParsingStrategy(commandFactory.Object);

            // Assert
            Assert.That(actualInstance, Is.Not.Null.And.InstanceOf<ICommandParsingStrategy>());
        }
    }
}
