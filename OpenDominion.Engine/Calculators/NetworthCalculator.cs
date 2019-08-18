using System;
using OpenDominion.Engine.Models;
using OpenDominion.Engine.Types;

namespace OpenDominion.Engine.Calculators
{
    public class NetworthCalculator
    {
//        public decimal GetNetworth(Realm realm)
//        {
//            throw new NotImplementedException();
//        }

        public decimal GetNetworth(Dominion dominion)
        {
            decimal networth = 0;

            foreach (var (unitType, amount) in dominion.Units)
            {
                networth += (amount * GetNetworth(unitType));
            }

            return networth;
        }

        public decimal GetNetworth(Unit unit)
        {
            if (unit.Slot == 1 || unit.Slot == 2)
                return 5m;

            var op = unit.BasePower[PowerType.Offensive];
            var dp = unit.BasePower[PowerType.Defensive];

            return (
                (1.8m * Math.Min(6m, Math.Max(op, dp)))
                + (0.45m * Math.Min(6m, Math.Min(op, dp)))
                + (0.2m * (Math.Max((op - 6m), 0m) + Math.Max((dp - 6m), 0m)))
            );
        }
    }
}
