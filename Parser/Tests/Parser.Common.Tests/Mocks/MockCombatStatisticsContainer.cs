﻿using Parser.Common.Contracts;
using Parser.Common.Factories;
using Parser.Common.Models;

namespace Parser.Common.Tests.Mocks
{
    internal class MockCombatStatisticsContainer : CombatStatisticsContainer
    {
        public MockCombatStatisticsContainer(ICurrentCombatStatisticsChangedEventArgsFactory currentCombatStatisticsChangedEventArgsFactory)
            : base(currentCombatStatisticsChangedEventArgsFactory)
        {
        }

        internal new ICombatStatistics MockingCurrentCombatStatistics { get { return base.MockingCurrentCombatStatistics; } set { base.MockingCurrentCombatStatistics = value; } }

        internal bool CurrentCombatStatisticsChangedMethodIsCalled { get; private set; }

        internal ICombatStatistics CurrentCombatStatisticsChangedMethodICombatStatisticsParameter { get; private set; }
    }
}
