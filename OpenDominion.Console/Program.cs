using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Autofac;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using OpenDominion.Engine.Calculators;
using OpenDominion.Engine.Models;
using OpenDominion.Engine.Types;

namespace OpenDominion.Console
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var unit = new Unit
            {
                Name = "Spearman",
                Rank = UnitRank.Specialist,
                Class = UnitClass.Offensive,
                BasePower =
                {
                    [UnitPowerType.Offensive] = 3
                },
                BaseCost =
                {
                    [ResourceType.Platinum] = 275,
                    [ResourceType.Ore] = 25
                },
                NetworthOverride = 5m,
            };

            string output = JsonConvert.SerializeObject(unit, Formatting.Indented);

//            using (var writer = new StreamWriter(@".\Data\Test.json", false, Encoding.UTF8))
//            {
//                writer.Write(output);
//            }

//            var unit2 = JsonConvert.DeserializeObject<Unit>(output);

//            var a = unit == unit2;

            System.Console.WriteLine(output);

            //

//            var race = GetRace();
//            var units = GetUnits(race);
//            race.Units = units;
//            var dominion = GetDominion(race, units);

//            var container = GetContainer();

//            var buildingCalculator = container.Resolve<BuildingCalculator>();
//            var networthCalculator = container.Resolve<NetworthCalculator>();
//            var landCalculator = container.Resolve<LandCalculator>();

//            System.Console.WriteLine($"Networth: {networthCalculator.GetNetworth(dominion)}");
//            System.Console.WriteLine();
//            System.Console.WriteLine($"Total land: {landCalculator.GetTotalLand(dominion)}");
//            System.Console.WriteLine($"Total barren land: {landCalculator.GetTotalBarrenLand(dominion)}");
//            System.Console.WriteLine();
//            System.Console.WriteLine($"Total buildings: {buildingCalculator.GetTotalBuildings(dominion)}");

//            container.Dispose();
        }

        private static IContainer GetContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<BuildingCalculator>().SingleInstance();
            builder.RegisterType<LandCalculator>().SingleInstance();
            builder.RegisterType<NetworthCalculator>().SingleInstance();

            return builder.Build();
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

//        private static List<Unit> GetUnits(Race race)
//        {
//            return new List<Unit>(new[]
//            {
//                new Unit
//                {
//                    Name = "Peasant",
//                    NetworthOverride = 0m,
//                    Rank = Unit.Rank.Generic,
//                    Class = UnitClass.Other
//                },
//                new Unit
//                {
//                    Name = "Draftee",
//                    NetworthOverride = 0m,
//                    Rank = Unit.Rank.Specialist,
//                    Class = UnitClass.Other,
//                    BasePower =
//                    {
//                        [Unit.UnitPowerType.CombatDefensive] = 1
//                    }
//                },
//                new Unit
//                {
//                    Name = "Spearman",
//                    Race = race,
//                    Slot = 1,
//                    NetworthOverride = 5m,
//                    Rank = Unit.Rank.Specialist,
//                    Class = UnitClass.Offensive,
//                    BaseCost =
//                    {
//                        [ResourceType.Platinum] = 275,
//                        [ResourceType.Ore] = 25
//                    },
//                    BasePower =
//                    {
//                        [Unit.UnitPowerType.CombatOffensive] = 3
//                    }
//                },
//                new Unit
//                {
//                    Name = "Archer",
//                    Race = race,
//                    Slot = 2,
//                    NetworthOverride = 5m,
//                    Rank = Unit.Rank.Specialist,
//                    Class = UnitClass.Defensive,
//                    BaseCost =
//                    {
//                        [ResourceType.Platinum] = 275,
//                        [ResourceType.Ore] = 15
//                    },
//                    BasePower =
//                    {
//                        [Unit.UnitPowerType.CombatDefensive] = 3
//                    }
//                },
//                new Unit
//                {
//                    Name = "Knight",
//                    Race = race,
//                    Slot = 3,
//                    Rank = Unit.Rank.Elite,
//                    Class = UnitClass.Defensive,
//                    BaseCost =
//                    {
//                        [ResourceType.Platinum] = 1000,
//                        [ResourceType.Ore] = 75
//                    },
//                    BasePower =
//                    {
//                        [Unit.UnitPowerType.CombatOffensive] = 2,
//                        [Unit.UnitPowerType.CombatDefensive] = 6
//                    }
//                },
//                new Unit
//                {
//                    Name = "Cavalry",
//                    Race = race,
//                    Slot = 4,
//                    Rank = Unit.Rank.Elite,
//                    Class = UnitClass.Offensive,
//                    BaseCost =
//                    {
//                        [ResourceType.Platinum] = 1250,
//                        [ResourceType.Ore] = 100
//                    },
//                    BasePower =
//                    {
//                        [Unit.UnitPowerType.CombatOffensive] = 6,
//                        [Unit.UnitPowerType.CombatDefensive] = 3
//                    }
//                },
//                new Unit
//                {
//                    Name = "Spy",
//                    NetworthOverride = 5m,
//                    Rank = Unit.Rank.Specialist,
//                    Class = UnitClass.Other,
//                    BaseCost =
//                    {
//                        [ResourceType.Platinum] = 500
//                    },
//                    BasePower =
//                    {
//                        [Unit.UnitPowerType.Spy] = 1
//                    }
//                },
//                new Unit
//                {
//                    Name = "Wizard",
//                    NetworthOverride = 5m,
//                    Rank = Unit.Rank.Specialist,
//                    Class = UnitClass.Other,
//                    BaseCost =
//                    {
//                        [ResourceType.Platinum] = 500
//                    },
//                    BasePower =
//                    {
//                        [Unit.UnitPowerType.Wizard] = 1
//                    }
//                },
//                new Unit
//                {
//                    Name = "ArchMage",
//                    NetworthOverride = 5m,
//                    Rank = Unit.Rank.Elite,
//                    Class = UnitClass.Other,
//                    BaseCost =
//                    {
//                        [ResourceType.Platinum] = 1000,
//                        [ResourceType.Wizards] = 1
//                    },
//                    BasePower =
//                    {
//                        [Unit.UnitPowerType.Wizard] = 2
//                    }
//                }
//            });
//        }

//        private static Dominion GetDominion(Race race, IReadOnlyCollection<Unit> units)
//        {
//            return new Dominion
//            {
//                Name = "Je Vader",
//                RulerName = "WaveHack",
//                Race = race,
//                Land =
//                {
//                    [LandType.Plain] = 40 + 10,
//                    [LandType.Mountain] = 20,
//                    [LandType.Swamp] = 20,
//                    [LandType.Cavern] = 20,
//                    [LandType.Forest] = 20,
//                    [LandType.Hill] = 20,
//                    [LandType.Water] = 20,
//                },
//                Buildings =
//                {
//                    [BuildingType.Home] = 10,
//                    [BuildingType.Alchemy] = 30,
//                    [BuildingType.Farm] = 30,
//                    [BuildingType.Lumberyard] = 20
//                },
//                Units =
//                {
//                    [units.First(unit => unit.Name == "Peasant")] = 1300,
//                    [units.First(unit => unit.Name == "Draftee")] = 100,
//                    [units.First(unit => unit.Slot == 2)] = 150,
//                    [units.First(unit => unit.Name == "Spy")] = 25,
//                    [units.First(unit => unit.Name == "Wizard")] = 25
//                }
//            };
//        }
    }
}
