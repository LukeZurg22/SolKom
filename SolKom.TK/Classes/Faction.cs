using SolKom.TK.Classes.Data;
using System.Drawing;

namespace SolKom.TK.Classes
{
    // [WIP] Maybe convert RelationModifiers to actual modifiers.
    public class FactionRelation
    {
        public int Opinion = 0;
        public string Id = string.Empty;
        Dictionary<string, int> RelationModifiers = new();

        public FactionRelation(int opinion, string id)
        {
            Opinion = opinion;
            Id = id;
        }
    }


    public class FactionStats
    {
        public int Stability;               // Determines how internally stable one's faction is.
        public float EconomicPower;         // Spent buying things
        public float IndustrialPower;       // Spent making ships
        public float PersonnelPower;        // Spent creating units
        public float Affluence;             // Spent manipulating other factions
        public float TechnologicalEdge;     // Measurement of how far ahead one is of the rest of the galaxy. Provides bonuses.
    }

    public class Faction
    {
        public string Id;
        public string Name;
        public string Flag = string.Empty; /// [WIP] Use URI to file, or store image locally.
        public Color Color;
        public GovernmentType GovernmentType;
        public NamingScheme NamingScheme;
        public PoliticalStatus PoliticalStatus;
        public FactionStats Stats;
        readonly List<Planet> Planets; // [WIP] Instead of planets pointing to their factions, factions point to planets?
        readonly List<FactionRelation> Relations = new();
        readonly List<ModifierStruct>? Modifiers = new();

        public void SetOpinion(string id, int opinion, bool isMutual)
        {
            var factionRelation = Relations.FirstOrDefault(relation => relation.Id.Equals(id));
            if (factionRelation != null)
                factionRelation.Opinion = opinion;
            if (isMutual)
            {
                var otherFaction = UniversalData.Instance.GetFaction(id);
                if (otherFaction != null)
                {
                    otherFaction.SetOpinion(this.Id, opinion, false);
                }
                else
                {
                    throw new Exception("Other faction returned null when setting mutual relations.");
                }
            }
        }

        public Faction(string id, string name, GovernmentType governmentType, NamingPattern pattern)
        {
            Id = id;
            Name = name;
            GovernmentType = governmentType;
            NamingScheme = new NamingScheme(pattern);
        }
        public Faction(string id, string name, GovernmentType governmentType)
        {
            Id = id;
            Name = name;
            GovernmentType = governmentType;
            NamingScheme = new NamingScheme();
        }
        public Faction(string id, string name)
        {
            Id = id;
            Name = name;
            NamingScheme = new NamingScheme();
        }

        public override string ToString() => Id;

        /// <summary>
        /// Calculates the hostility (true) or peacefulness (false) between two factions. The first parameter is the aggressor.
        /// </summary>
        public static bool IsHostileWith(Faction faction)
        {
            // Simply compare relations and if they are below a certain value, factions are hostile.
            /*int index1 = (int)faction1;
            int index2 = (int)faction2;
            return relations[index1][index2];*/

            return default;
        }




    }



}