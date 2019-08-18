using System.Collections.Generic;
using System.Diagnostics;
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
                    Name = "Spearman",
                    Race = race,
                    Slot = 1,
                    Rank = Unit.UnitRank.Specialist,
                    Type = Unit.UnitType.Offensive,
                    BaseCost =
                    {
                        [ResourceType.Platinum] = 275,
                        [ResourceType.Ore] = 25
                    },
                    BasePower =
                    {
                        [PowerType.Offensive] = 3
                    }
                },
                new Unit
                {
                    Name = "Archer",
                    Race = race,
                    Slot = 2,
                    Rank = Unit.UnitRank.Specialist,
                    Type = Unit.UnitType.Defensive,
                    BaseCost =
                    {
                        [ResourceType.Platinum] = 275,
                        [ResourceType.Ore] = 15
                    },
                    BasePower =
                    {
                        [PowerType.Defensive] = 3
                    }
                },
                new Unit
                {
                    Name = "Knight",
                    Slot = 3,
                    Rank = Unit.UnitRank.Elite,
                    Type = Unit.UnitType.Defensive,
                    BaseCost =
                    {
                        [ResourceType.Platinum] = 1000,
                        [ResourceType.Ore] = 75
                    },
                    BasePower =
                    {
                        [PowerType.Offensive] = 2,
                        [PowerType.Defensive] = 6
                    }
                },
                new Unit
                {
                    Name = "Cavalry",
                    Slot = 4,
                    Rank = Unit.UnitRank.Elite,
                    Type = Unit.UnitType.Offensive,
                    BaseCost =
                    {
                        [ResourceType.Platinum] = 1250,
                        [ResourceType.Ore] = 100
                    },
                    BasePower =
                    {
                        [PowerType.Offensive] = 6,
                        [PowerType.Defensive] = 3
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
                    [units[0]] = 0,
                    [units[1]] = 150,
                    [units[2]] = 0,
                    [units[3]] = 0,
                }
            };

            var networthCalculator = new NetworthCalculator();
            var networth = networthCalculator.GetNetworth(dominion);

            Debug.Assert(networth == 750m);
            System.Console.WriteLine($"Dominion networth: {networth}");
        }
    }
}
