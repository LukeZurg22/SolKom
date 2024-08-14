using OpenTK.Mathematics;

namespace SolKom.TK.Classes
{
    internal class SpaceSystem
    {
        struct SystemID
        {
            public int Sector;
            public int System;

            public SystemID(int sector, int system)
            {
                Sector = sector;
                System = system;
            }

            public override string ToString() => $"{Sector}-{System}";
        }
        /// <summary>
        /// System location in Galactic Space.
        /// </summary>
        Vector3 Location;
        SystemID ID;
        List<CelestialBody> CelestialBodies = new();
        Structure[]? Structures;
        Faction SystemOwner;

        public SpaceSystem(int sectorID, int systemID)
        {
            ID = new SystemID(sectorID, systemID);
        }

        internal void RandomInstantiate()
        {
            for (int i = 0; i < RNG.RN(30); i++)
            {
                Planet planet = new(ID.Sector, ID.System, i);
                Console.WriteLine("\t\tPlanet: " + planet);
                CelestialBodies.Add(planet);
            }
        }
        // [WIP] Star defined in system. Also other stats?


        // [WIP] Read pixel data and create planets to append to CelestialBodies
        // [WIP] Every system has its own defined internal coordinate grid.
        
        public override string ToString() => $"{ID.Sector}-{ID.System}";
    }
}
