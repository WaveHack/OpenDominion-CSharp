using OpenDominion.Engine.Models;

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
            if (unit.NetworthOverride != null)
                return (decimal) unit.NetworthOverride;

//            var op = unit.BasePower[UnitPowerType.Offensive];
//            var dp = unit.BasePower[UnitPowerType.Defensive];
//
//            return (
//                (1.8m * Math.Min(6m, Math.Max(op, dp)))
//                + (0.45m * Math.Min(6m, Math.Min(op, dp)))
//                + (0.2m * (Math.Max((op - 6m), 0m) + Math.Max((dp - 6m), 0m)))
//            );

            return 0;
        }
    }
}
