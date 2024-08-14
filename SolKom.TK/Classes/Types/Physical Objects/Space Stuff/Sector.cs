using SolKom.TK.Classes;

namespace SolKom.TK
{
    internal class Sector
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

        public Sector(int id) => ID = id;

        // [WIP] Read pixel data and create systems.
        public void RandomInstantiate()
        {
            for(int i = 0; i < RNG.RN(30); i++)
            {
                SpaceSystem system = new(ID, i);
                Console.WriteLine("\tSystem: " + system);
                system.RandomInstantiate();
                Systems.Add(system);
            }
        }

        public override string ToString()
        {
            return $"{ID}";
        }
    }
}
