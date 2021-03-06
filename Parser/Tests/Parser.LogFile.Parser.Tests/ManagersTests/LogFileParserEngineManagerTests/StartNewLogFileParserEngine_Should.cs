﻿using Moq;
using NUnit.Framework;

using Parser.Common.Contracts;
using Parser.LogFile.Parser.Contracts;
using Parser.LogFile.Parser.Factories;
using Parser.LogFile.Parser.Managers;
using Parser.LogFile.Parser.Tests.Mocks;

namespace Parser.LogFile.Parser.Tests.ManagersTests.LogFileParserEngineManagerTests
{
    [TestFixture]
    public class StartNewLogFileParserEngine_Should
    {
        [Test]
        public void InvokeIGuidStringProvider_NewGuidMethodOnce()
        {
            // Arrange
            var guidStringProvider = new Mock<IGuidStringProvider>();
            var logFileParserEngineFactory = new Mock<ILogFileParserEngineFactory>();

            var guidString = "any string";
            guidStringProvider.Setup(p => p.NewGuidString()).Returns(guidString);

            var logFileParserEngine = new Mock<ILogFileParserEngine>();
            logFileParserEngineFactory.Setup(f => f.CreateLogFileParserEngine()).Returns(logFileParserEngine.Object);

            var logFileParserEngineManager = new LogFileParserEngineManager(guidStringProvider.Object, logFileParserEngineFactory.Object);

            var username = "any string";

            // Act
            logFileParserEngineManager.StartLogFileParserEngine(username);

            // Assert
            guidStringProvider.Verify(p => p.NewGuidString(), Times.Once);
        }

        [Test]
        public void InvokeILogFileParserEngineFactory_CreateLogFileParserEngineMethodOnce()
        {
            // Arrange
            var guidStringProvider = new Mock<IGuidStringProvider>();
            var logFileParserEngineFactory = new Mock<ILogFileParserEngineFactory>();

            var guidString = "any string";
            guidStringProvider.Setup(p => p.NewGuidString()).Returns(guidString);

            var logFileParserEngine = new Mock<ILogFileParserEngine>();
            logFileParserEngineFactory.Setup(f => f.CreateLogFileParserEngine()).Returns(logFileParserEngine.Object);

            var logFileParserEngineManager = new LogFileParserEngineManager(guidStringProvider.Object, logFileParserEngineFactory.Object);

            var username = "any string";

            // Act
            logFileParserEngineManager.StartLogFileParserEngine(username);

            // Assert
            logFileParserEngineFactory.Verify(f => f.CreateLogFileParserEngine(), Times.Once);
        }

        [Test]
        public void AddCorrectKeyAndEngine_ToLogFileParserEnginesDictionary()
        {
            // Arrange
            var guidStringProvider = new Mock<IGuidStringProvider>();
            var logFileParserEngineFactory = new Mock<ILogFileParserEngineFactory>();

            var guidString = "any string";
            guidStringProvider.Setup(p => p.NewGuidString()).Returns(guidString);

            var logFileParserEngine = new Mock<ILogFileParserEngine>();
            logFileParserEngineFactory.Setup(f => f.CreateLogFileParserEngine()).Returns(logFileParserEngine.Object);

            var logFileParserEngineManager = new MockLogFileParserEngineManager(guidStringProvider.Object, logFileParserEngineFactory.Object);

            var expectedAddedEngine = logFileParserEngine.Object;

            var username = "any string";

            // Act
            logFileParserEngineManager.StartLogFileParserEngine(username);

            var logFileParserEnginesDictionaryContainsKey = logFileParserEngineManager.LogFileParserEngines.ContainsKey(guidString);
            var actuallogFileParserEnginesDictionaryEngine = logFileParserEngineManager.LogFileParserEngines[guidString];

            // Assert
            Assert.That(logFileParserEnginesDictionaryContainsKey, Is.True);
            Assert.That(actuallogFileParserEnginesDictionaryEngine, Is.SameAs(expectedAddedEngine));
        }

        [Test]
        public void ReturnCorrectResult()
        {
            // Arrange
            var guidStringProvider = new Mock<IGuidStringProvider>();
            var logFileParserEngineFactory = new Mock<ILogFileParserEngineFactory>();

            var guidString = "any string";
            guidStringProvider.Setup(p => p.NewGuidString()).Returns(guidString);

            var logFileParserEngine = new Mock<ILogFileParserEngine>();
            logFileParserEngineFactory.Setup(f => f.CreateLogFileParserEngine()).Returns(logFileParserEngine.Object);

            var logFileParserEngineManager = new LogFileParserEngineManager(guidStringProvider.Object, logFileParserEngineFactory.Object);

            var username = "any string";

            // Act 
            var actualResult = logFileParserEngineManager.StartLogFileParserEngine(username);

            // Assert
            Assert.That(actualResult, Is.EqualTo(guidString));
        }
    }
}
