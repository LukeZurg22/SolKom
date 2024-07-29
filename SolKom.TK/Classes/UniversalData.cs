using SolKom.TK.Classes;
using System.Security.AccessControl;

namespace SolKom.TK
{
    public class UniversalData
    {
        public static UniversalData Instance = new();

        /// <summary>
        /// Game storage for all present factions. Adding a new faction is a direct addition to the dictionary.
        /// </summary>
        private readonly List<Faction> Factions;
        private readonly int[][] BaseOpinionModifierTable = new int[][]
        {

        //                            ANARCHY   TECHNOCRACY     THEOCRACY   SCOURGE     NIEKRONIAK  REPUBLIC   MONARCHY     AUTOCRACY    OLIGARCHY    DEMOCRACY   COMMUNAL    TOTALITARIAT  COLLECTIVE
        new int[] /* ANARCHY */     { -50,      -50,            -50,        -100,       -50,        -50,       -50,         -50,         -50,         -50,        -50,        -50,          -50  },
        new int[] /* TECHNOCRACY */ { -50,      25,             -50,        -100,       0,          10,        -25,         0,           10,          -25,        -100,       0,            -25  },
        new int[] /* THEOCRACY */   { -50,      -50,            -50,        -100,       -50,        -25,       0,           -50,         -20,         -50,        -25,        -25,          -50  },
        new int[] /* SCOURGE */     { -100,     -100,           -100,       -100,       -100,       -100,      -100,        -100         -100,        -100,       -100,       -100,         -100 },
        new int[] /* NIEKRONIAK */  { -50,      -50,            -50,        -100,       100,        -50,       -50,         -25,         -25,         -50,        -50,        10,           -25  },
        new int[] /* REPUBLIC */    { -50,      -25,            -25,        -100,       -50,        50,        -50,         -50          -25,         50,         25,         -100,         -25  },
        new int[] /* MONARCHY */    { -50,      -25,            0,          -100,       -50,        -50,       -10,         0,           -25,         -50,        -50,        -25,          -100 },
        new int[] /* AUTOCRACY */   { -50,      0,              -50,        -100,       -25,        -50,       0,           0,           0,           -50,        -50,        0,            -100 },
        new int[] /* OLIGARCHY */   { -50,      -25,            10,         -100,       -25,        -25,       -25,         0,           -25,         -50,        -50,        0,            -50  },
        new int[] /* DEMOCRACY */   { -50,      50,             -50,        -100,       -50,        -25,       -50,         -50,         -50,         50,         0,          -100,         -25  },
        new int[] /* COMMUNAL */    { -50,      0,              -25,        -100,       -100,       25,        -50,         -50,         -50,         0,          0,          -100,         -25  },
        new int[] /* TOTALITARIAT*/ { -50,      0,              -25,        -100,       10,         -100,      -25,         0,           0,           -100,       -100,       10,           -100 },
        new int[] /* COLLECTIVE */  { -50,      -100,           -50,        -100,       -25,        -25,       -100,        -100,        -50,         -25,        -25,        -100,         -100 },

        };
        
        public UniversalData()
        {
            Instance = this;
            Factions = new()
            {
                { new Faction("base_faction_scavengers", "Scavengers", GovernmentType.Anarchy) },
                { new Faction("base_faction_sarak_pirates", "Sarak Upheavers", GovernmentType.Anarchy) },
                { new Faction("base_faction_arialial_pirates", "Arialial Raiders", GovernmentType.Anarchy) },
                { new Faction("base_faction_circibon_military", "Circibon Concordat", GovernmentType.Technocracy) },
                { new Faction("base_faction_circiabon_military", "Circiabon Holy Accord", GovernmentType.Theocracy) },
                { new Faction("base_faction_xyph", "Xyphonian Scourge", GovernmentType.Scourge) },
                { new Faction("base_faction_niecronians", "Niekroniak", GovernmentType.Niekroniak) },
                { new Faction("base_faction_toril", "Toril", GovernmentType.Republic) },
                { new Faction("base_faction_verestek", "Verestek Corporations", GovernmentType.Oligarchy) },
                { new Faction("base_faction_dwarves", "Jormundgand'rai've", GovernmentType.Democracy) },
                { new Faction("base_faction_robots", "Tier 2 Annexants", GovernmentType.Communal) },
                { new Faction("base_faction_xurnacht", "Xur'nacht", GovernmentType.Collective) },
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
                faction.FactionRelations = Factions.Select(f => new FactionRelation(0, f.Id)).ToList();
                faction.SetOpinion(faction.Id, 100, false);
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

        public int[][] GetBaseOpinionModifierTable()
        {
            return BaseOpinionModifierTable;
        }

        public Faction GetFaction(string id)
        {
            var faction = GetFactions().FirstOrDefault(faction => faction.Id.Equals(id));
            if (faction != null)
                return faction;
            else
                throw new Exception("GetFaction returned null from given ID. Likely ID is not present.");
        }

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
