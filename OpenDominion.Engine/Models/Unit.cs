using System.Collections.Generic;
using OpenDominion.Engine.Types;

namespace OpenDominion.Engine.Models
{
    public class Unit
    {
        public enum UnitClass
        {
            Offensive,
            Defensive,
            Hybrid,
            Support,
            Other
        }

        public enum UnitRank
        {
            Generic,
            Specialist,
            Elite
        }

        public string Name;
//        public string Description;

        public Race Race;
        public int? Slot;
        public decimal? NetworthOverride;

        public UnitRank Rank;
        public UnitClass Class;

        public readonly Dictionary<ResourceType, int> BaseCost = new Dictionary<ResourceType, int>();
        public readonly Dictionary<PowerType, decimal> BasePower = new Dictionary<PowerType, decimal>();

        public bool NeedsBoat = true;

//        public List<UnitPerk> UnitPerks;
    }
}
