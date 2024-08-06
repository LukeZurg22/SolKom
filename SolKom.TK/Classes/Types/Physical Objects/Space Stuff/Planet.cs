using SolKom.TK.Classes;
using SolKom.TK.Classes.Data;

namespace SolKom.TK
{
    public enum PlanetType
    {
        GasGiant,
        SuperGiant,
        IceGiant,
        MegaPlanet,
        TerrestrialPlanet,
        CarbonPlanet,
        CorelessPlanet,
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
        GlassPlanet
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
        PlanetModifier[]? Modifiers = Array.Empty<PlanetModifier>();
        PlanetStats Stats;
        // [WIP] Each planet has its own stats

        public void Generate(Scheme namingScheme)
        {
            PlanetType = new PlanetType();
            Name = namingScheme.GetRandomPlanetName();
        }
        public void Create(PlanetType planetType, string name, int devastation) => Create(planetType, name, devastation, null);
        public void Create(PlanetType planetType, string name, int devastation, Faction? faction)
        {
            PlanetType = planetType;
            Name = name;
            Stats.Devastation = devastation;
            FactionOwner = faction;
        }
        public void Conquer(Faction conqueror)
        {
            // [WIP] Rename planet upon conquest.
        }
        public void Crack()
        {
            // [WIP] If the planet is destroyed / cracked.
        }
        public override string ToString() => $"{PlanetID} | Planet Name: {Name} | Type: {PlanetType} | Faction: {FactionOwner}";

    }

}
