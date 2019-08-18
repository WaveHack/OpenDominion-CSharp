using System.Linq;
using OpenDominion.Engine.Models;

namespace OpenDominion.Engine.Calculators
{
    public class LandCalculator
    {
        public int GetTotalLand(Dominion dominion)
        {
            return dominion.Land.Sum(pair => pair.Value);
        }
    }
}
