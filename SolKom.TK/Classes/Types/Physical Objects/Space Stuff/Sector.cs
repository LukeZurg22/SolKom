using SolKom.TK.Classes;

namespace SolKom.TK
{
    public class Sector
    {
        // [IMPL] Color code for sectors.

        // [IMPL] ID arrangement for other Galaxies?
         public int ID;
         
        /// <summary>
        /// The systems contained within a sector.
        /// </summary>
        readonly List<SpaceSystem> Systems = new();

        /// <summary>
        /// The faction currently in active control of the sector. Can be null, to state that there is NO faction in control.
        /// </summary>
        readonly Faction? Faction;

        // [WIP] Read pixel data and create systems.

        public void RandomInstantiate()
        {
            for(int i = 0; i< RNG.RN(100); i++)
            {
                SpaceSystem newSystem = new();
                newSystem.RandomInstantiate();
                Systems.Add(newSystem);
            }
        }
    }
}
