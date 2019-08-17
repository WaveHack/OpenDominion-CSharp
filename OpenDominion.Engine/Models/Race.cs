using System;
using System.Collections;
using System.Collections.Generic;
using OpenDominion.Engine.Types;

namespace OpenDominion.Engine.Models
{
    public class Race
    {
        public string Name;
        public string Description;

        public Alignment Alignment;
        public LandType HomeLandType;

        public List<Unit> Units;
    }
}
