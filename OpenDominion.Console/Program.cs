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
                    Race = race,
                    Rank = Unit.UnitRank.Generic,
                    Class = Unit.UnitClass.Other
                },
                new Unit
                {
                    Name = "Draftee",
                    Race = race,
                    Rank = Unit.UnitRank.Specialist,
                    Class = Unit.UnitClass.Other,
                    BasePower =
                    {
                        [PowerType.CombatDefensive] = 1
                    }
                },
                new Unit
                {
                    Name = "Spearman",
                    Race = race,
                    Slot = 1,
                    Rank = Unit.UnitRank.Specialist,
                    Class = Unit.UnitClass.Offensive,
                    BaseCost =
                    {
                        [ResourceType.Platinum] = 275,
                        [ResourceType.Ore] = 25
                    },
                    BasePower =
                    {
                        [PowerType.CombatOffensive] = 3
                    }
                },
                new Unit
                {
                    Name = "Archer",
                    Race = race,
                    Slot = 2,
                    Rank = Unit.UnitRank.Specialist,
                    Class = Unit.UnitClass.Defensive,
                    BaseCost =
                    {
                        [ResourceType.Platinum] = 275,
                        [ResourceType.Ore] = 15
                    },
                    BasePower =
                    {
                        [PowerType.CombatDefensive] = 3
                    }
                },
                new Unit
                {
                    Name = "Knight",
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
                        [PowerType.CombatOffensive] = 2,
                        [PowerType.CombatDefensive] = 6
                    }
                },
                new Unit
                {
                    Name = "Cavalry",
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
                        [PowerType.CombatOffensive] = 6,
                        [PowerType.CombatDefensive] = 3
                    }
                },
                new Unit
                {
                    Name = "Spy",
                    Rank = Unit.UnitRank.Specialist,
                    Class = Unit.UnitClass.Other,
                    BaseCost =
                    {
                        [ResourceType.Platinum] = 500
                    },
                    BasePower =
                    {
                        [PowerType.Spy] = 1
                    }
                },
                new Unit
                {
                    Name = "Wizard",
                    Rank = Unit.UnitRank.Specialist,
                    Class = Unit.UnitClass.Other,
                    BaseCost =
                    {
                        [ResourceType.Platinum] = 500
                    },
                    BasePower =
                    {
                        [PowerType.Wizard] = 1
                    }
                },
                new Unit
                {
                    Name = "ArchMage",
                    Rank = Unit.UnitRank.Elite,
                    Class = Unit.UnitClass.Other,
                    BaseCost =
                    {
                        [ResourceType.Platinum] = 1000,
                        [ResourceType.Wizards] = 1
                    },
                    BasePower =
                    {
                        [PowerType.Wizard] = 2
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
                    [units.First(unit => unit.Slot == 2)] = 150
                }
            };

            var networthCalculator = new NetworthCalculator();
            var networth = networthCalculator.GetNetworth(dominion);

//            Debug.Assert(networth == 1250m);
            System.Console.WriteLine($"Dominion networth: {networth}");
        }
    }
}
