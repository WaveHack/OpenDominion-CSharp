using System.Collections.Generic;
using NUnit.Framework;
using OpenDominion.Engine.Calculators;
using OpenDominion.Engine.Models;
using OpenDominion.Engine.Types;

namespace OpenDominion.Engine.Tests.Calculators
{
    [TestFixture]
    public class BuildingCalculatorTests
    {
        private BuildingCalculator _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new BuildingCalculator();
        }

        [TestCaseSource(nameof(GetTotalBuildings_Returns_TotalBuildings_TestCases))]
        public int GetTotalBuildings_Returns_TotalBuildings(Dominion dominion)
        {
            return _sut.GetTotalBuildings(dominion);
        }

        private static IEnumerable<TestCaseData> GetTotalBuildings_Returns_TotalBuildings_TestCases
        {
            // ReSharper disable once UnusedMember.Local
            get
            {
                yield return new TestCaseData(new Dominion()).Returns(0);

                yield return new TestCaseData(new Dominion
                {
                    Buildings =
                    {
                        [BuildingType.Home] = 10
                    }
                }).Returns(10);

                yield return new TestCaseData(new Dominion
                {
                    Buildings =
                    {
                        [BuildingType.Home] = 10,
                        [BuildingType.Alchemy] = 30,
                        [BuildingType.Farm] = 30,
                        [BuildingType.Lumberyard] = 20
                    }
                }).Returns(90);
            }
        }
    }
}
