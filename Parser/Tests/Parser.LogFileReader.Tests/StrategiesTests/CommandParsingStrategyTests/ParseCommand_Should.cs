﻿using System;

using Moq;
using NUnit.Framework;

using Parser.LogFileReader.Contracts;
using Parser.LogFileReader.Factories;
using Parser.LogFileReader.Models;
using Parser.LogFileReader.Strategies;

namespace Parser.LogFileReader.Tests.StrategiesTests.CommandParsingStrategyTests
{
    [TestFixture]
    public class ParseCommand_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenInputParameterIsNull()
        {
            // Arrange
            var command = new Mock<ICommand>();
            var commandFactory = new Mock<ICommandFactory>();
            commandFactory.Setup(f => f.CreateCommand()).Returns(command.Object);

            var commandParsingStrategy = new CommandParsingStrategy(commandFactory.Object);

            string input = null;

            // Act & Assert
            Assert.That(
                () => commandParsingStrategy.ParseCommand(input),
                Throws.InstanceOf<ArgumentNullException>().With.Message.Contains(nameof(input)));
        }

        [Test]
        public void ThrowArgumentException_WhenInputParameterIsStringEmpty()
        {
            // Arrange
            var command = new Mock<ICommand>();
            var commandFactory = new Mock<ICommandFactory>();
            commandFactory.Setup(f => f.CreateCommand()).Returns(command.Object);

            var commandParsingStrategy = new CommandParsingStrategy(commandFactory.Object);

            var input = string.Empty;

            // Act & Assert
            Assert.That(
                () => commandParsingStrategy.ParseCommand(input),
                Throws.InstanceOf<ArgumentException>().With.Message.Contains(nameof(input)));
        }

        [Test]
        public void ReturnCorrectCommand_WhenApplyingDamage()
        {
            // Arrange
            var commandFactory = new Mock<ICommandFactory>();
            commandFactory.Setup(f => f.CreateCommand()).Returns(new Command());

            var commandParsingStrategy = new CommandParsingStrategy(commandFactory.Object);

            var input = "[22:34:05.112] [@Morninn'wood] [Operations Training Dummy {2857785339412480}:165053332701] [Orbital Strike {2145301804613632}] [ApplyEffect {836045448945477}: Damage {836045448945501}] (3300 elemental {836045448940875}) <3300>";

            var expectedCommand = new Command();
            expectedCommand.TimeStamp = DateTime.Parse("22:34:05.112");
            expectedCommand.AbilityActivatorName = "@Morninn'wood";
            expectedCommand.AbilityTargetName = "Operations Training Dummy {2857785339412480}:165053332701";
            expectedCommand.AbilityName = "Orbital Strike";
            expectedCommand.AbilityGameId = "2145301804613632";
            expectedCommand.EventType = "ApplyEffect";
            expectedCommand.EventTypeGameId = "836045448945477";
            expectedCommand.EventName = "Damage";
            expectedCommand.EventNameGameId = "836045448945501";
            expectedCommand.EffectType = "elemental";
            expectedCommand.EffectTypeGameId = "836045448940875";
            expectedCommand.EffectAmount = 3300;
            expectedCommand.EffectEffectiveAmount = 3300;

            // Act
            var actualCommand = commandParsingStrategy.ParseCommand(input);

            // Assert
            Assert.That(actualCommand.TimeStamp, Is.EqualTo(expectedCommand.TimeStamp));
            Assert.That(actualCommand.AbilityActivatorName, Is.EqualTo(expectedCommand.AbilityActivatorName));
            Assert.That(actualCommand.AbilityTargetName, Is.EqualTo(expectedCommand.AbilityTargetName));
            Assert.That(actualCommand.AbilityName, Is.EqualTo(expectedCommand.AbilityName));
            Assert.That(actualCommand.AbilityGameId, Is.EqualTo(expectedCommand.AbilityGameId));
            Assert.That(actualCommand.EventType, Is.EqualTo(expectedCommand.EventType));
            Assert.That(actualCommand.EventTypeGameId, Is.EqualTo(expectedCommand.EventTypeGameId));
            Assert.That(actualCommand.EventName, Is.EqualTo(expectedCommand.EventName));
            Assert.That(actualCommand.EventNameGameId, Is.EqualTo(expectedCommand.EventNameGameId));
            Assert.That(actualCommand.EffectType, Is.EqualTo(expectedCommand.EffectType));
            Assert.That(actualCommand.EffectTypeGameId, Is.EqualTo(expectedCommand.EffectTypeGameId));
            Assert.That(actualCommand.EffectAmount, Is.EqualTo(expectedCommand.EffectAmount));
            Assert.That(actualCommand.EffectEffectiveAmount, Is.EqualTo(expectedCommand.EffectEffectiveAmount));
        }
    }
}