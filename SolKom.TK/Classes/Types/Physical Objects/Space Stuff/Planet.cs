using ConsoleTables;
using SolKom.TK.Classes;
using SolKom.TK.Classes.Data;

namespace SolKom.TK
{
    #region Data Stuff
    public enum PlanetType
    {
        GasGiant,
        SuperGiant,
        IceGiant,
        CorelessPlanet,
        TerrestrialPlanet,
        CarbonPlanet,
        MegaPlanet,
        HeliumPlanet,
        HyceanPlanet,
        IronPlanet,
        LavaPlanet,
        OceanPlanet,
        DesertPlanet,
        PuffyPlanet,
        SilicatePlanet,
        /// <summary>
        /// A planet nearly entirely made up of Blood Flower flora.
        /// </summary>
        RedPlanet,
        GlassPlanet,
        RuinPlanet
    }

    struct PlanetID
    {
        public int Sector;
        public int System;
        public int Planet;
        public PlanetID(int sector, int system, int planet)
        {
            Sector = sector;
            System = system;
            Planet = planet;
        }
        public override string ToString() => $"{Sector}-{System}-{Planet}";
    }
    #endregion

    // [WIP] modifiers for planets.
    /// [WIP] Note that a possible ID system may be used for planets Ala Paradox. Could save on memory.
    public class Planet : CelestialBody
    {

        readonly PlanetID PlanetID;
        PlanetType PlanetType;
        string FactionOwnerID;
        string Name = string.Empty;
        readonly PlanetStats Stats = new();

        /// <summary>
        /// Gets the Base Sacre Value
        /// </summary>
        /// <param name="planetType">The type that which the planet -is.</param>
        /// <returns>The base Sacre value hard-coded from a set of Planet Types.</returns>
        static int GetTypeSacre(PlanetType planetType)
        {
            return planetType switch
            {
                PlanetType.GasGiant => 5,
                // [WIP] Add missing cases
                _ => 0,
            };
        }
        // [TEMP] This is completely worthless. Generating a planet via naming scheme is unecessessary, but i MIGHT need this later!
        public void Generate(NamingScheme namingScheme)
        {
            PlanetType = new PlanetType();
            Name = namingScheme.GetRandomPlanetName();
        }
        public Planet(PlanetType planetType, string name, PlanetStats planetStats) => Create(planetType, name, planetStats, null);
        public Planet(Faction faction)
        {
            Create(PlanetType.GetRandomElement(), faction.NamingScheme.GetRandomPlanetName(), new PlanetStats(), faction.Id);
        }
        public Planet(int sectorID, int systemID, int planetID)
        {
            this.PlanetID = new(sectorID, systemID, planetID);
            Create(PlanetType.GetRandomElement(), $"{PlanetID}", new PlanetStats(), null);
        }
        public void Create(PlanetType planetType, string name, PlanetStats planetStats, string? faction)
        {
            PlanetType = planetType;
            Name = name;
            Stats.BaseSacre = GetTypeSacre(planetType);
            Stats.BaseDevastation = planetStats.BaseDevastation;
            Stats.BaseHabitability = planetStats.BaseHabitability;
            FactionOwnerID = !string.IsNullOrEmpty(faction) ? faction : string.Empty;

        }
        // [WIP] Stats.Sacre : Internally in Stats, Update total according to base + modifiers. Base Sacre is 5 on most planets. Just fill 'em in.
        public void Conquer(Faction conqueror)
        {
            // [WIP] Rename planet upon conquest.
            throw new NotImplementedException();
        }
        public void Crack()
        {
            // [WIP] If the planet is destroyed / cracked.
            throw new NotImplementedException();
        }
        public override string ToString() => this.PlanetID.ToString();

        public string ToPrintString()
        {
            var table = new ConsoleTable("ID", "Name", "Type", "Faction").AddRow(new object[] { PlanetID, Name, PlanetType, FactionOwnerID });
            return
                $"[PLANET]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~" +
                $"\n{table.ToMinimalString()}" +
                $"Stats: \n{Stats}" +
                $"\n\n";
        }
    }

}
