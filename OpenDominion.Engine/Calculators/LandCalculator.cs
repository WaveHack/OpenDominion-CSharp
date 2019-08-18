using System.Linq;
using OpenDominion.Engine.Models;

namespace OpenDominion.Engine.Calculators
{
    public class LandCalculator
    {
        private readonly BuildingCalculator _buildingCalculator;

        public LandCalculator(BuildingCalculator buildingCalculator)
        {
            _buildingCalculator = buildingCalculator;
        }

        public int GetTotalLand(Dominion dominion)
        {
            return dominion.Land.Sum(pair => pair.Value);
        }

        public int GetTotalBarrenLand(Dominion dominion)
        {
//            return (
//                $this->getTotalLand($dominion)
//                - $this->buildingCalculator->getTotalBuildings($dominion)
//                - $this->queueService->getConstructionQueueTotal($dominion)
//            );

            return (
                GetTotalLand(dominion)
                - _buildingCalculator.GetTotalBuildings(dominion)
            );
        }
    }
}
