using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using OpenDominion.Engine.Calculators;
using OpenDominion.Engine.Models;
using OpenDominion.Engine.Types;
using SimpleInjector;

namespace OpenDominion.Console
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var race = GetRace();
            var units = GetUnits(race);
            race.Units = units;
            var dominion = GetDominion(race, units);

            var container = GetContainer();

            var buildingCalculator = container.GetInstance<BuildingCalculator>();
            var networthCalculator = container.GetInstance<NetworthCalculator>();
            var landCalculator = container.GetInstance<LandCalculator>();

            System.Console.WriteLine($"Dominion networth: {networthCalculator.GetNetworth(dominion)}");
            System.Console.WriteLine($"Total land: {landCalculator.GetTotalLand(dominion)}");
            System.Console.WriteLine($"Total buildings: {buildingCalculator.GetTotalBuildings(dominion)}");
            System.Console.WriteLine($"Total barren land: {landCalculator.GetTotalBarrenLand(dominion)}");

            container.Dispose();
        }

        private static Container GetContainer()
        {
            var container = new Container();

            container.Register<BuildingCalculator>(Lifestyle.Singleton);
            container.Register<LandCalculator>(Lifestyle.Singleton);
            container.Register<NetworthCalculator>(Lifestyle.Singleton);

            container.Verify();

            return container;
        }

        private static Race GetRace()
        {
            return new Race
            {
                Name = "Human",
                Description = "Humie!",
                Alignment = Alignment.Good,
                HomeLandType = LandType.Plain,
            };
        }

        private static List<Unit> GetUnits(Race race)
        {
            return new List<Unit>(new[]
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
        }

        private static Dominion GetDominion(Race race, IReadOnlyCollection<Unit> units)
        {
            return new Dominion
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
        }
    }
}
