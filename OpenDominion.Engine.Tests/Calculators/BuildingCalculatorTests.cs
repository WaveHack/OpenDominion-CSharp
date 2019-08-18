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

        [TestCase]
        public void GetTotalBuildings_Returns_TotalBuildings()
        {
            // Arrange
            var dominion = new Dominion
            {
                Buildings =
                {
                    [BuildingType.Home] = 10,
                    [BuildingType.Alchemy] = 30,
                    [BuildingType.Farm] = 30,
                    [BuildingType.Lumberyard] = 20
                }
            };

            // Act
            var totalBuildings = _sut.GetTotalBuildings(dominion);

            // Assert
            Assert.AreEqual(90, totalBuildings);
        }
    }
}
