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
            var networthCalculator = new NetworthCalculator();

            var knight = new Unit
            {
                Name = "Knight",
                Slot = 3,
                Rank = Unit.UnitRank.Elite,
                Type = Unit.UnitType.Defensive,
                NeedsBoat = true,
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
            };

            var networth = networthCalculator.GetNetworth(knight);

            Debug.Assert(networth == 11.7m);
            System.Console.WriteLine($"Knight networth: {networth}");
        }
    }
}
