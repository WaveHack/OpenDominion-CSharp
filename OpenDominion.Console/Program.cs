using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using OpenDominion.Engine.Calculators;
using OpenDominion.Engine.Models;
using OpenDominion.Engine.Types;

namespace OpenDominion.Console
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var race = new Race
            {
                Name = "Human",
                Description = "Humie!",
                Alignment = Alignment.Good,
                HomeLandType = LandType.Plain,
            };

            var units = new List<Unit>(new[]
            {
                new Unit
                {
                    Name = "Peasant",
                    NetworthOverride = 0m,
                    Rank = Unit.UnitRank.Generic,
                    Class = Unit.UnitClass.Other
                },
                new Unit
                {
                    Name = "Draftee",
                    NetworthOverride = 0m,
                    Rank = Unit.UnitRank.Specialist,
                    Class = Unit.UnitClass.Other,
                    BasePower =
                    {
                        [Unit.UnitPowerType.CombatDefensive] = 1
                    }
                },
                new Unit
                {
                    Name = "Spearman",
                    Race = race,
                    Slot = 1,
                    NetworthOverride = 5m,
                    Rank = Unit.UnitRank.Specialist,
                    Class = Unit.UnitClass.Offensive,
                    BaseCost =
                    {
                        [ResourceType.Platinum] = 275,
                        [ResourceType.Ore] = 25
                    },
                    BasePower =
                    {
                        [Unit.UnitPowerType.CombatOffensive] = 3
                    }
                },
                new Unit
                {
                    Name = "Archer",
                    Race = race,
                    Slot = 2,
                    NetworthOverride = 5m,
                    Rank = Unit.UnitRank.Specialist,
                    Class = Unit.UnitClass.Defensive,
                    BaseCost =
                    {
                        [ResourceType.Platinum] = 275,
                        [ResourceType.Ore] = 15
                    },
                    BasePower =
                    {
                        [Unit.UnitPowerType.CombatDefensive] = 3
                    }
                },
                new Unit
                {
                    Name = "Knight",
                    Race = race,
                    Slot = 3,
                    Rank = Unit.UnitRank.Elite,
                    Class = Unit.UnitClass.Defensive,
                    BaseCost =
                    {
                        [ResourceType.Platinum] = 1000,
                        [ResourceType.Ore] = 75
                    },
                    BasePower =
                    {
                        [Unit.UnitPowerType.CombatOffensive] = 2,
                        [Unit.UnitPowerType.CombatDefensive] = 6
                    }
                },
                new Unit
                {
                    Name = "Cavalry",
                    Race = race,
                    Slot = 4,
                    Rank = Unit.UnitRank.Elite,
                    Class = Unit.UnitClass.Offensive,
                    BaseCost =
                    {
                        [ResourceType.Platinum] = 1250,
                        [ResourceType.Ore] = 100
                    },
                    BasePower =
                    {
                        [Unit.UnitPowerType.CombatOffensive] = 6,
                        [Unit.UnitPowerType.CombatDefensive] = 3
                    }
                },
                new Unit
                {
                    Name = "Spy",
                    NetworthOverride = 5m,
                    Rank = Unit.UnitRank.Specialist,
                    Class = Unit.UnitClass.Other,
                    BaseCost =
                    {
                        [ResourceType.Platinum] = 500
                    },
                    BasePower =
                    {
                        [Unit.UnitPowerType.Spy] = 1
                    }
                },
                new Unit
                {
                    Name = "Wizard",
                    NetworthOverride = 5m,
                    Rank = Unit.UnitRank.Specialist,
                    Class = Unit.UnitClass.Other,
                    BaseCost =
                    {
                        [ResourceType.Platinum] = 500
                    },
                    BasePower =
                    {
                        [Unit.UnitPowerType.Wizard] = 1
                    }
                },
                new Unit
                {
                    Name = "ArchMage",
                    NetworthOverride = 5m,
                    Rank = Unit.UnitRank.Elite,
                    Class = Unit.UnitClass.Other,
                    BaseCost =
                    {
                        [ResourceType.Platinum] = 1000,
                        [ResourceType.Wizards] = 1
                    },
                    BasePower =
                    {
                        [Unit.UnitPowerType.Wizard] = 2
                    }
                }
            });

            race.Units = units;

            var dominion = new Dominion
            {
                Name = "Je Vader",
                RulerName = "WaveHack",
                Race = race,
                Land =
                {
                    [LandType.Plain] = 40 + 10,
                    [LandType.Mountain] = 20,
                    [LandType.Swamp] = 20,
                    [LandType.Cavern] = 20,
                    [LandType.Forest] = 20,
                    [LandType.Hill] = 20,
                    [LandType.Water] = 20,
                },
                Buildings =
                {
                    [BuildingType.Home] = 10,
                    [BuildingType.Alchemy] = 30,
                    [BuildingType.Farm] = 30,
                    [BuildingType.Lumberyard] = 20
                },
                Units =
                {
                    [units.First(unit => unit.Name == "Peasant")] = 1300,
                    [units.First(unit => unit.Name == "Draftee")] = 100,
                    [units.First(unit => unit.Slot == 2)] = 150,
                    [units.First(unit => unit.Name == "Spy")] = 25,
                    [units.First(unit => unit.Name == "Wizard")] = 25
                }
            };

            var networthCalculator = new NetworthCalculator();
            var networth = networthCalculator.GetNetworth(dominion);

//            Debug.Assert(networth == 1000m);
            System.Console.WriteLine($"Dominion networth: {networth}");

            var buildingCalculator = new BuildingCalculator();
            var landCalculator = new LandCalculator(buildingCalculator);

            var totalLand = landCalculator.GetTotalLand(dominion);
            var totalBarrenLand = landCalculator.GetTotalBarrenLand(dominion);
            var totalBuildings = buildingCalculator.GetTotalBuildings(dominion);

            System.Console.WriteLine($"Total land: {totalLand}");
            System.Console.WriteLine($"Total buildings: {totalBuildings}");
            System.Console.WriteLine($"Total barren land: {totalBarrenLand}");
        }
    }
}
