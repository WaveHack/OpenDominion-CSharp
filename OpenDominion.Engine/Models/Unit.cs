using System.Collections.Generic;
using System.Runtime.InteropServices;
using OpenDominion.Engine.Types;

namespace OpenDominion.Engine.Models
{
    public class Unit
    {
        public enum UnitRank
        {
            Specialist,
            Elite,
            Hero
        }

        public enum UnitType
        {
            Offensive,
            Defensive,
            Support,
            Mixed,
            Special,
            Other
        }

        public string Name;
//        public string Description;

        public Race Race;
        public int Slot;
        public UnitRank Rank;
        public UnitType Type;

        public Dictionary<ResourceType, int> BaseCost;
        public Dictionary<PowerType, float> BasePower;

        public bool NeedsBoat;

//        public List<UnitPerk> UnitPerks;
    }
}
