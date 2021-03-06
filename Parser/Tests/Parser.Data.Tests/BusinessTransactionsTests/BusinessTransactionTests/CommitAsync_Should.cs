﻿using Moq;
using NUnit.Framework;

using Parser.Data.BusinessTransactions;
using Parser.Data.Contracts;

namespace Parser.Data.Tests.BusinessTransactionsTests.BusinessTransactionTests
{
    [TestFixture]
    public class CommitAsync_Should
    {
        [Test]
        public void InvokeIDbContext_SaveChangesAsyncMethodOnce()
        {
            // Arrange
            var dbContext = new Mock<IDbContext>();

            var businessTransaction = new EntityFrameworkTransaction(dbContext.Object);

            // Act
            businessTransaction.SaveChangesAsync();

            // Assert
            dbContext.Verify(c => c.SaveChangesAsync(), Times.Once);
        }
    }
}
