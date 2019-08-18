using System.Collections.Generic;
using OpenDominion.Engine.Types;

namespace OpenDominion.Engine.Models
{
    public class Dominion
    {
        public string Name;
        public string RulerName;

        public Race Race;

        public Dictionary<LandType, int> Land = new Dictionary<LandType, int>();
        public Dictionary<BuildingType, int> Buildings = new Dictionary<BuildingType, int>();

        // relational:
        // user
        // round
        // realm
        // race
        // pack

        // general:
        // name/ruler name
        // race
        // prestige
        // daily bonuses taken

        // population:
        // peasants
        // peasants_last_hour
        // draft_rate
        // morale
        // spy/wiz str

        // resources

        // improvements

        // military

        // land

        // buildings

        // stats (attack/def success etc)

    }
}
