using OpenTK.Mathematics;

namespace SolKom.TK.Classes
{
    public class SpaceSystem
    {
        struct SystemID
        {
            public int Sector;
            public int System;
            public override string ToString() => $"{Sector}-{System}";
        }
        /// <summary>
        /// System location in Galactic Space.
        /// </summary>
        Vector3 Location;
        List<CelestialBody> CelestialBodies;
        Structure[]? Structures;
        Faction SystemOwner;

        internal void RandomInstantiate()
        {
            throw new NotImplementedException();
        }
        // [WIP] Star defined in system. Also other stats?


        // [WIP] Read pixel data and create planets to append to CelestialBodies
        // [WIP] Every system has its own defined internal coordinate grid.
    }
}
