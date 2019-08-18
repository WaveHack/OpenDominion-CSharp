using System.Collections.Generic;
using System.Linq;
using OpenDominion.Engine.Models;
using OpenDominion.Engine.Types;

namespace OpenDominion.Engine.Calculators
{
    public class BuildingCalculator
    {
        public int GetTotalBuildings(Dominion dominion)
        {
            return dominion.Buildings.Sum(pair => pair.Value);
        }

        public int GetTotalBuildingsForLandType(Dominion dominion, LandType landType)
        {
            var result = 0;

            //

            return result;
        }

        public Dictionary<BuildingType, LandType> GetBuildingTypesByLandType(Race race)
        {
            return new Dictionary<BuildingType, LandType>
            {
                {BuildingType.Home, race.HomeLandType},

                {BuildingType.Alchemy, LandType.Plain},
                {BuildingType.Farm, LandType.Plain},
                {BuildingType.Smithy, LandType.Plain},
                {BuildingType.Masonry, LandType.Plain},

                {BuildingType.OreMine, LandType.Mountain},
                {BuildingType.GryphonNest, LandType.Mountain},

                {BuildingType.Tower, LandType.Swamp},
                {BuildingType.WizardGuild, LandType.Swamp},
                {BuildingType.Temple, LandType.Swamp},

                {BuildingType.DiamondMine, LandType.Cavern},
                {BuildingType.School, LandType.Cavern},

                {BuildingType.Lumberyard, LandType.Forest},
                {BuildingType.ForestHaven, LandType.Forest},

                {BuildingType.Factory, LandType.Hill},
                {BuildingType.GuardTower, LandType.Hill},
                {BuildingType.Shrine, LandType.Hill},
                {BuildingType.Barracks, LandType.Hill},

                {BuildingType.Dock, LandType.Water}
            };
        }

        public List<BuildingType> GetBuildingTypesForLandType(Race race, LandType landType)
        {
            return GetBuildingTypesByLandType(race)
                .Where(pair => pair.Value == landType)
                .Select(pair => pair.Key)
                .ToList();
        }
    }
}
