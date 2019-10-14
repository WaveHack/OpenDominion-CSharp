using System.Collections.Generic;
using OpenDominion.Engine.Types;

namespace OpenDominion.Engine.Models
{
    public class Dominion
    {
        public string Name;
        public string RulerName;

//        public Pack Pack;
        public Race Race;
//        public Realm Realm;
//        public Round Round;
//        public User User;

        public int Prestige;

        public bool DailyLandTaken;
        public bool DailyPlatinumTaken;

        public Dictionary<ResourceType, int> Resources = new Dictionary<ResourceType, int>();

        public Dictionary<BuildingType, int> Buildings = new Dictionary<BuildingType, int>();
        public Dictionary<LandType, int> Land = new Dictionary<LandType, int>();
        public Dictionary<Unit, int> Units = new Dictionary<Unit, int>();

        public decimal Boats;

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
