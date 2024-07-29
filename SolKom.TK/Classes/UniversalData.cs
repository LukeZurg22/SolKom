using SolKom.TK.Classes;

namespace SolKom.TK
{
    public class UniversalData
    {
        public static UniversalData Instance = new();

        /// <summary>
        /// Game storage for all present factions. Adding a new faction is a direct addition to the dictionary.
        /// </summary>
        private readonly List<Faction> Factions;

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
            });
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
    }

}
