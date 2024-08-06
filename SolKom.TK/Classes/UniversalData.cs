using SolKom.TK.Classes;
using System.Security.AccessControl;
using System.Linq;
using RandN;
using SolKom.TK.Classes.Data;

namespace SolKom.TK
{
    public class UniversalData
    {
        public static UniversalData Instance = new();

        public static readonly SmallRng RANDOM_NUMBER_GENERATOR = SmallRng.Create();
        private readonly Galaxy Galaxy;

        /// <summary>
        /// Game storage for all present factions. Adding a new faction is a direct addition to the dictionary.
        /// </summary>
        private readonly List<Faction> Factions;
        private readonly int[][] BaseOpinionModifierTable = new int[][]
        {
               //                         Anarchy | Democracy | Republic | Monarchy | Autocracy | Oligarchy | Technocracy | Communal | Theocracy | Totalitariat | Collective | Scourge | Niekroniak |
            //                            ANARCHY   DEMOCRACY   REPUBLIC    MONARCHY    AUTOCRACY   OLIGARCHY   TECHNOCRACY     COMMUNAL    THEOCRACY   TOTALITARIAT    SCOURGE     NIEKRONIAK  COLLECTIVE
            new int[] /* ANARCHY */     { -25,      -25,        -25,        -25,        -25,        -25,        -25,            -25,        -25,        -25,            -100,       -25,        -25,    },
            new int[] /* DEMOCRACY */   { -25,      25,         -15,        -25,        -25,        -25,        25,             0,          -25,        -100,           -100,       -50,        -15,    },
            new int[] /* REPUBLIC */    { -25,      -15,        25,         -25,        -25,        -25,        -25,            -25,        -25,        -50,            -100,       -50,        -25,    },
            new int[] /* MONARCHY */    { -25,      -25,        -25,        0,          -15,        -15,        -25,            -25,        -15,        -25,            -100,       -25,        -25,    },
            new int[] /* AUTOCRACY */   { -25,      -25,        -25,        -15,        0,          -15,        -25,            -25,        -15,        -15,            -100,       -25,        -25,    },
            new int[] /* OLIGARCHY */   { -25,      -25,        -25,        -15,        -15,        0,          -25,            -25,        -15,        -15,            -100,       -25,        -25,    },
            new int[] /* TECHNOCRACY */ { -25,      25,         -25,        -25,        -25,        -25,        25,             -25,        -25,        -15,            -100,       -15,        -25,    },
            new int[] /* COMMUNAL */    { -25,      0,          -25,        -25,        -25,        -25,        -25,            0,          -25,        -50,            -100,       -25,        -25,    },
            new int[] /* THEOCRACY */   { -25,      -25,        -25,        -15,        -15,        -15,        -25,            -25,        -25,        -25,            -100,       -25,        -25,    },
            new int[] /* TOTALITARIAT*/ { -25,      -100,       -50,        -25,        -15,        -15,        -15,            -50,        -25,        0,              -100,       0,          -25,    },
            new int[] /* SCOURGE */     { -100,     -100,       -100,       -100,       -100,       -100,       -100,           -100,       -100,       -100,           -100,       -100,       -100,   },
            new int[] /* NIEKRONIAK */  { -25,      -50,        -50,        -25,        -25,        -25,        -15,            -25,        -25,        0,              -100,       100,        -25,    },
            new int[] /* COLLECTIVE */  { -25,      -15,        -25,        -25,        -25,        -25,        -25,            -25,        -25,        -25,            -100,       -25,        -100,   },
        };

 

        public UniversalData()
        {
            Instance = this;
            Galaxy = new Galaxy();

            Factions = new()
            {
                { new Faction("base_faction_scavengers", "Scavengers", GovernmentType.Anarchy, NamingPattern.Rogue) },
                { new Faction("base_faction_sarak_pirates", "Sarak Upheavers", GovernmentType.Anarchy, NamingPattern.Sarakaan) },
                { new Faction("base_faction_arialial_pirates", "Arialial Raiders", GovernmentType.Anarchy, NamingPattern.Rogue) },
                { new Faction("base_faction_circibon_military", "Circibon Concordat", GovernmentType.Technocracy, NamingPattern.Circibon) },
                { new Faction("base_faction_circiabon_military", "Circiabon Holy Accord", GovernmentType.Theocracy, NamingPattern.Circibon) },
                { new Faction("base_faction_xyph", "Xyphonian Scourge", GovernmentType.Scourge, NamingPattern.Xyphonian) },
                { new Faction("base_faction_niecronians", "Niekroniak", GovernmentType.Niekroniak, NamingPattern.Niecronian) },
                { new Faction("base_faction_toril", "Toril", GovernmentType.Republic, NamingPattern.Human) },
                { new Faction("base_faction_verestek", "Verestek Corporations", GovernmentType.Oligarchy, NamingPattern.Human) },
                { new Faction("base_faction_dwarves", "Jormundgand'rai've", GovernmentType.Democracy, NamingPattern.Human) },
                { new Faction("base_faction_robots", "Tier 2 Annexants", GovernmentType.Communal, NamingPattern.Circibon) },
                { new Faction("base_faction_xurnacht", "Xur'nacht", GovernmentType.Collective, NamingPattern.Niecronian) },
            };
            ResetRelations();
        }

        /// <summary>
        /// For Every Faction, add new Faction Relation List.
        /// </summary>
        void ResetRelations()
        {
            Factions.ForEach(faction =>
            {
                //Console.WriteLine($"\nRELATIONS OF {faction.Name}");
                faction.FactionRelations = Factions.Select(f => new FactionRelation(0, f.Id)).ToList();
                foreach (Faction otherFaction in Factions.Where(otherFaction => !otherFaction.Id.Equals(faction.Id)))
                {
                    int baseOpinion = BaseOpinionModifierTable[(int)faction.GovernmentType][(int)otherFaction.GovernmentType];
                    faction.SetOpinion(otherFaction.Id, baseOpinion, true);
                    //Console.WriteLine($"{baseOpinion} | {otherFaction.Name}");
                }

                // Factions love themselves, except for the Xyph.
                if (!faction.Id.Equals("base_faction_xyph"))
                {
                    faction.SetOpinion(faction.Id, 100, false);
                }
                // If its the Xyph, make them hate themselves.
                else
                {
                    faction.SetOpinion(faction.Id, -100, false);
                }
            });
            //GetFaction("base_faction_scavengers").SetOpinion();

        }

        /// <summary>
        /// A function call to add a bit of encapsulation in the UniversalData class.
        /// </summary>
        /// <returns>A list of factions in the Universal Data.</returns>
        /// <exception cref="Exception"></exception>
        public List<Faction> GetFactions()
        {
            if (Factions != null)
                return Factions;
            throw new Exception("Attempted to call GetFactions() whilst factions were still null. Called before Factions was initialized, somehow.");
        }

        public int[][] GetBaseOpinionModifierTable() => BaseOpinionModifierTable;


        public Faction GetFaction(string id)
        {
            var faction = GetFactions().FirstOrDefault(faction => faction.Id.Equals(id));
            if (faction != null)
                return faction;
            else
                throw new Exception("GetFaction returned null from given ID. Likely ID is not present.");
        }

        /// [WIP] Update relations function in UniversalData.
        public void UpdateRelations()
        {
            foreach (var faction in Factions)
            {

            }
        }

        /* public static bool IsHostile(Faction faction1, Faction faction2)
         {
             int index1 = (int)faction1;
             int index2 = (int)faction2;
             return relations[index1][index2];
         }*/
    }

}
