using System.Collections.Generic;
using OpenDominion.Engine.Types;

namespace OpenDominion.Engine.Models
{
    public class Unit
    {
        public enum UnitRank
        {
            Specialist,
            Elite
        }

        public enum UnitType
        {
            Offensive,
            Defensive,
            Hybrid,
            Support,
            Other
        }

        public string Name;
//        public string Description;

        public Race Race;
        public int Slot;
        public UnitRank Rank;
        public UnitType Type;

        public readonly Dictionary<ResourceType, int> BaseCost = new Dictionary<ResourceType, int>();
        public readonly Dictionary<PowerType, decimal> BasePower = new Dictionary<PowerType, decimal>();

        public bool NeedsBoat = true;

//        public List<UnitPerk> UnitPerks;
    }
}
