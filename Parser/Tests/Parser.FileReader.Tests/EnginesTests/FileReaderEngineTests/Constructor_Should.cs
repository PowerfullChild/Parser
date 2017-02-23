﻿using System;

using Moq;
using NUnit.Framework;

using Parser.FileReader.Contracts;
using Parser.FileReader.Engines;
using Parser.FileReader.Factories;

namespace Parser.FileReader.Tests.EnginesTests.FileReaderEngineTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenICommandParsingStrategyIsNull()
        {
            // Arrange
            ICommandParsingStrategy commandParsingStrategy = null;
            var commandUtilizationStrategy = new Mock<ICommandUtilizationStrategy>();
            var fileReaderAutoResetEventFactory = new Mock<IFileReaderAutoResetEventFactory>();
            var fileReaderFileSystemWatcherFactory = new Mock<IFileReaderFileSystemWatcherFactory>();
            var fileReaderInputProviderFactory = new Mock<IFileReaderInputProviderFactory>();

            // Act & Assert
            Assert.That(
                () => new FileReaderEngine(commandParsingStrategy, commandUtilizationStrategy.Object, fileReaderAutoResetEventFactory.Object, fileReaderFileSystemWatcherFactory.Object, fileReaderInputProviderFactory.Object),
                Throws.InstanceOf<ArgumentNullException>().With.Message.Contains(nameof(ICommandParsingStrategy)));
        }

        [Test]
        public void ThrowArgumentNullException_WhenICommandUtilizationStrategyIsNull()
        {
            // Arrange
            var commandParsingStrategy = new Mock<ICommandParsingStrategy>();
            ICommandUtilizationStrategy commandUtilizationStrategy = null;
            var fileReaderAutoResetEventFactory = new Mock<IFileReaderAutoResetEventFactory>();
            var fileReaderFileSystemWatcherFactory = new Mock<IFileReaderFileSystemWatcherFactory>();
            var fileReaderInputProviderFactory = new Mock<IFileReaderInputProviderFactory>();

            // Act & Assert
            Assert.That(
                () => new FileReaderEngine(commandParsingStrategy.Object, commandUtilizationStrategy, fileReaderAutoResetEventFactory.Object, fileReaderFileSystemWatcherFactory.Object, fileReaderInputProviderFactory.Object),
                Throws.InstanceOf<ArgumentNullException>().With.Message.Contains(nameof(ICommandUtilizationStrategy)));
        }

        [Test]
        public void ThrowArgumentNullException_WhenIFileReaderAutoResetEventFactoryIsNull()
        {
            // Arrange
            var commandParsingStrategy = new Mock<ICommandParsingStrategy>();
            var commandUtilizationStrategy = new Mock<ICommandUtilizationStrategy>();
            IFileReaderAutoResetEventFactory fileReaderAutoResetEventFactory = null;
            var fileReaderFileSystemWatcherFactory = new Mock<IFileReaderFileSystemWatcherFactory>();
            var fileReaderInputProviderFactory = new Mock<IFileReaderInputProviderFactory>();

            // Act & Assert
            Assert.That(
                () => new FileReaderEngine(commandParsingStrategy.Object, commandUtilizationStrategy.Object, fileReaderAutoResetEventFactory, fileReaderFileSystemWatcherFactory.Object, fileReaderInputProviderFactory.Object),
                Throws.InstanceOf<ArgumentNullException>().With.Message.Contains(nameof(IFileReaderAutoResetEventFactory)));
        }

        [Test]
        public void ThrowArgumentNullException_WhenIFileReaderFileSystemWatcherFactoryIsNull()
        {
            // Arrange
            var commandParsingStrategy = new Mock<ICommandParsingStrategy>();
            var commandUtilizationStrategy = new Mock<ICommandUtilizationStrategy>();
            var fileReaderAutoResetEventFactory = new Mock<IFileReaderAutoResetEventFactory>();
            IFileReaderFileSystemWatcherFactory fileReaderFileSystemWatcherFactory = null;
            var fileReaderInputProviderFactory = new Mock<IFileReaderInputProviderFactory>();

            // Act & Assert
            Assert.That(
                () => new FileReaderEngine(commandParsingStrategy.Object, commandUtilizationStrategy.Object, fileReaderAutoResetEventFactory.Object, fileReaderFileSystemWatcherFactory, fileReaderInputProviderFactory.Object),
                Throws.InstanceOf<ArgumentNullException>().With.Message.Contains(nameof(IFileReaderFileSystemWatcherFactory)));
        }

        [Test]
        public void ThrowArgumentNullException_WhenIFileReaderInputProviderFactoryIsNull()
        {
            // Arrange
            var commandParsingStrategy = new Mock<ICommandParsingStrategy>();
            var commandUtilizationStrategy = new Mock<ICommandUtilizationStrategy>();
            var fileReaderAutoResetEventFactory = new Mock<IFileReaderAutoResetEventFactory>();
            var fileReaderFileSystemWatcherFactory = new Mock<IFileReaderFileSystemWatcherFactory>();
            IFileReaderInputProviderFactory fileReaderInputProviderFactory = null;

            // Act & Assert
            Assert.That(
                () => new FileReaderEngine(commandParsingStrategy.Object, commandUtilizationStrategy.Object, fileReaderAutoResetEventFactory.Object, fileReaderFileSystemWatcherFactory.Object, fileReaderInputProviderFactory),
                Throws.InstanceOf<ArgumentNullException>().With.Message.Contains(nameof(IFileReaderInputProviderFactory)));
        }
    }
}
