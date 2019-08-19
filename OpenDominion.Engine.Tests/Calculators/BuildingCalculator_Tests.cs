using System.Collections.Generic;
using NUnit.Framework;
using OpenDominion.Engine.Calculators;
using OpenDominion.Engine.Models;
using OpenDominion.Engine.Types;

namespace OpenDominion.Engine.Tests.Calculators
{
    [TestFixture]
    public class BuildingCalculator_Tests
    {
        private BuildingCalculator _buildingCalculator;

        [SetUp]
        public void Setup()
        {
            _buildingCalculator = new BuildingCalculator();
        }

        public class GetTotalBuildings_MethodTests : BuildingCalculator_Tests
        {
            [TestCaseSource(nameof(It_Returns_TotalBuildings_TestCases))]
            public int It_Returns_TotalBuildings(Dominion dominion)
            {
                return _buildingCalculator.GetTotalBuildings(dominion);
            }

            private static IEnumerable<TestCaseData> It_Returns_TotalBuildings_TestCases
            {
                // ReSharper disable once UnusedMember.Local
                get
                {
                    yield return new TestCaseData(new Dominion())
                        .SetName("No buildings")
                        .Returns(0);

                    yield return new TestCaseData(new Dominion
                        {
                            Buildings =
                            {
                                [BuildingType.Home] = 10
                            }
                        })
                        .SetName("10 homes")
                        .Returns(10);

                    yield return new TestCaseData(new Dominion
                        {
                            Buildings =
                            {
                                [BuildingType.Home] = 10,
                                [BuildingType.Alchemy] = 30,
                                [BuildingType.Farm] = 30,
                                [BuildingType.Lumberyard] = 20
                            }
                        })
                        .SetName("Starting dominion building layout")
                        .Returns(90);
                }
            }
        }

        public class GetTotalBuildingsForLandType_MethodTests : BuildingCalculator_Tests
        {
            [TestCaseSource(nameof(It_Returns_TotalBuildingsForLandType_TestCases))]
            public int It_Returns_TotalBuildingsForLandType(Dominion dominion, LandType landType)
            {
                return _buildingCalculator.GetTotalBuildingsForLandType(dominion, landType);
            }

            private static IEnumerable<TestCaseData> It_Returns_TotalBuildingsForLandType_TestCases
            {
                // ReSharper disable once UnusedMember.Local
                get
                {
                    yield return new TestCaseData(new Dominion
                        {
                            Race = new Race {HomeLandType = LandType.Plain},
                            Buildings =
                            {
                                [BuildingType.Home] = 10,
                                [BuildingType.Alchemy] = 10
                            }
                        }, LandType.Plain)
                        .SetName("Homes matching home land type")
                        .Returns(20);

                    yield return new TestCaseData(new Dominion
                        {
                            Race = new Race {HomeLandType = LandType.Swamp},
                            Buildings =
                            {
                                [BuildingType.Home] = 10,
                                [BuildingType.Alchemy] = 10
                            }
                        }, LandType.Plain)
                        .SetName("Homes NOT matching home land type")
                        .Returns(10);
                }
            }
        }
    }
}
