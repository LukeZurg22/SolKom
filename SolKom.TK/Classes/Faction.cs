using SolKom.TK.Classes.Data;

namespace SolKom.TK.Classes
{
    public class FactionRelation
    {
        public int Opinion = 0;
        public string Id = string.Empty;
        Dictionary<string, int> Modifiers = new();

        public FactionRelation(int opinion, string id)
        {
            Opinion = opinion;
            Id = id;
        }
    }

    public class Faction
    {
        public string Id;
        public string Name;
        public string Flag = string.Empty; /// [WIP]
        public GovernmentType GovernmentType;
        public List<FactionRelation> FactionRelations = new();
        public Scheme NamingScheme;

        public void SetOpinion(string id, int opinion, bool isMutual)
        {
            var factionRelation = FactionRelations.FirstOrDefault(relation => relation.Id.Equals(id));
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
            NamingScheme = new Scheme(pattern);
        }
        public Faction(string id, string name, GovernmentType governmentType)
        {
            Id = id;
            Name = name;
            GovernmentType = governmentType;
            NamingScheme = new Scheme();
        }
        public Faction(string id, string name)
        {
            Id = id;
            Name = name;
            NamingScheme = new Scheme();
        }

        public override string ToString()
        {
            return $"{Id} | {Name} | {GovernmentType}";
        }

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