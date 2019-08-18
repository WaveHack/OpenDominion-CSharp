using System.Linq;
using OpenDominion.Engine.Models;

namespace OpenDominion.Engine.Calculators
{
    public class BuildingCalculator
    {
        public int GetTotalBuildings(Dominion dominion)
        {
            return dominion.Buildings.Sum(pair => pair.Value);
        }
    }
}
