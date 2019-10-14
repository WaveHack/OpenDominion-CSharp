using System.Collections.Generic;
using OpenDominion.Engine.Types;

namespace OpenDominion.Engine.Models
{
    public class Unit
    {
        public string Name;
        public string Description;

        public UnitClass Class;
        public UnitRank Rank;

        public Dictionary<UnitPowerType, decimal> BasePower = new Dictionary<UnitPowerType, decimal>();
        public Dictionary<ResourceType, int> BaseCost = new Dictionary<ResourceType, int>();

        public decimal? NetworthOverride;
        public bool NeedsBoat = true;

        public List<UnitPerk> Perks = new List<UnitPerk>();
    }
}
