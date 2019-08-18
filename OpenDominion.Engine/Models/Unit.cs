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
            Support,
            Mixed,
            Other
        }

        public string Name;
//        public string Description;

        public Race Race;
        public int Slot;
        public UnitRank Rank;
        public UnitType Type;

        public Dictionary<ResourceType, int> BaseCost = new Dictionary<ResourceType, int>();
        public Dictionary<PowerType, decimal> BasePower = new Dictionary<PowerType, decimal>();

        public bool NeedsBoat;

//        public List<UnitPerk> UnitPerks;
    }
}
