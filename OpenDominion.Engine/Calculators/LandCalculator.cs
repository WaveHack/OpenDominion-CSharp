using System;
using System.Collections.Generic;
using System.Linq;
using OpenDominion.Engine.Models;
using OpenDominion.Engine.Types;

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

        public int GetTotalLandForLandType(Dominion dominion, LandType landType)
        {
            throw new NotImplementedException();
        }

        public int GetTotalBarrenLandForLandType(Dominion dominion, LandType landType)
        {
            throw new NotImplementedException();
        }

        public Dictionary<LandType, int> GetTotalLandByLandType(Dominion dominion)
        {
            return dominion.Land;
        }

        public Dictionary<LandType, int> GetTotalBarrenLandByLandType(Dominion dominion)
        {
            var result = new Dictionary<LandType, int>();

            foreach (LandType landType in Enum.GetValues(typeof(LandType)))
            {
                result[landType] = dominion.Land[landType]
                                   - _buildingCalculator.GetTotalBuildingsForLandType(dominion, landType);
            }

            return result;
        }
    }
}
