using ConsoleTables;
using SolKom.TK.Classes;
using SolKom.TK.Classes.Data;

namespace SolKom.TK
{
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
        public override string ToString() => $"{Sector}-{System}-{Planet}";
    }

    // [WIP] modifiers for planets.
    /// [WIP] Note that a possible ID system may be used for planets Ala Paradox. Could save on memory.
    public class Planet : CelestialBody
    {

        PlanetID PlanetID;
        PlanetType PlanetType;
        Faction? FactionOwner;
        string Name = string.Empty;
        readonly PlanetStats Stats = new();

        /// <summary>
        /// Gets the Base Sacre Value
        /// </summary>
        /// <param name="planetType">The type that which the planet -is.</param>
        /// <returns>The base Sacre value hard-coded from a set of Planet Types.</returns>
        int GetBaseSacre(PlanetType planetType)
        {
            return planetType switch
            {
                PlanetType.GasGiant => 5,
                // [WIP] Add missing cases
                _ => 0,
            };
        }
        public void Generate(Scheme namingScheme)
        {
            PlanetType = new PlanetType();
            Name = namingScheme.GetRandomPlanetName();
        }
        public Planet(PlanetType planetType, string name, PlanetStats planetStats) => Create(planetType, name, planetStats, null);
        public Planet(Faction faction)
        {
            Create(PlanetType.GetRandomElement(), faction.NamingScheme.GetRandomPlanetName(), new PlanetStats(), faction);
        }
        public void Create(PlanetType planetType, string name, PlanetStats planetStats, Faction? faction)
        {
            PlanetType = planetType;
            Name = name;
            Stats.BaseSacre = GetBaseSacre(planetType);
            Stats.BaseDevastation = planetStats.BaseDevastation;
            Stats.BaseHabitability = planetStats.BaseHabitability;
            FactionOwner = faction;
        }
        // [WIP] Stats.Sacre : Internally in Stats, Update total according to base + modifiers. Base Sacre is 5 on most planets. Just fill 'em in.
        public void Conquer(Faction conqueror)
        {
            // [WIP] Rename planet upon conquest.
        }
        public void Crack()
        {
            // [WIP] If the planet is destroyed / cracked.
        }
        public override string ToString()
        {
            var table = new ConsoleTable("ID", "Name", "Type", "Faction").AddRow(new object[] { PlanetID, Name, PlanetType, FactionOwner });
            return
                $"[PLANET]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~" +
                $"\n{table.ToMinimalString()}" +
                $"Stats: \n{Stats}" +
                $"\n\n";
        }
    }

}
