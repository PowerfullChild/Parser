﻿using System;

using Moq;
using NUnit.Framework;

using Parser.Common.Contracts;
using Parser.LogFile.Parser.Contracts;
using Parser.LogFile.SignalR.Contracts;
using Parser.LogFile.SignalR.Services;

namespace Parser.LogFile.SignalR.Tests.ServicesTests.LogFileParserHubServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void CreateCorrectILogFileParserHubServiceInstance_WhenParametersAreValid()
        {
            // Arrange
            var logFileParserEngineManager = new Mock<ILogFileParserEngineManager>();
            var commandJsonConvertProvider = new Mock<ICommandEnumerationJsonConvertProvider>();

            // Act
            var actualInstance = new LogFileParserHubService(logFileParserEngineManager.Object, commandJsonConvertProvider.Object);

            // Assert
            Assert.That(actualInstance, Is.Not.Null.And.InstanceOf<ILogFileParserHubService>());
        }

        [Test]
        public void ThrowArgumentNullException_WhenILogFileParserEngineManagerParameterIsNull()
        {
            // Arrange
            ILogFileParserEngineManager logFileParserEngineManager = null;
            var commandJsonConvertProvider = new Mock<ICommandEnumerationJsonConvertProvider>();

            // Act & Assert
            Assert.That(
                () => new LogFileParserHubService(logFileParserEngineManager, commandJsonConvertProvider.Object),
                Throws.InstanceOf<ArgumentNullException>().With.Message.Contains(nameof(ILogFileParserEngineManager)));
        }

        [Test]
        public void ThrowArgumentNullException_WhenIJsonConvertProviderParameterIsNull()
        {
            // Arrange
            var logFileParserEngineManager = new Mock<ILogFileParserEngineManager>();
            ICommandEnumerationJsonConvertProvider commandJsonConvertProvider = null;

            // Act & Assert
            Assert.That(
                () => new LogFileParserHubService(logFileParserEngineManager.Object, commandJsonConvertProvider),
                Throws.InstanceOf<ArgumentNullException>().With.Message.Contains(nameof(ICommandEnumerationJsonConvertProvider)));
        }
    }
}
