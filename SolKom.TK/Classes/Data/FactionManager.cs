using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolKom.TK.Classes.Data
{
    public static class FactionManager
    {
        /// <summary>
        /// Game storage for all present factions. Adding a new faction is a direct addition to the dictionary.
        /// </summary>
        public static readonly List<Faction> Factions = new() {
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

        /// <summary>
        /// A function call to add a bit of encapsulation in the UniversalData class.
        /// </summary>
        /// <returns>A list of factions in the Universal Data.</returns>
        /// <exception cref="Exception"></exception>
        public static List<Faction> GetFactions()
        {
            if (Factions != null)
                return Factions;
            throw new Exception("Attempted to call GetFactions() whilst factions were still null. Called before Factions was initialized, somehow.");
        }

        public static Faction GetFaction(string id)
        {
            var faction = GetFactions().FirstOrDefault(faction => faction.Id.Equals(id));
            if (faction != null)
                return faction;
            else
                throw new Exception("GetFaction returned null from given ID. Likely ID is not present.");
        }

        // [IMPL] Automate the creation of relations between all factions when a new faction is made.
        /// <summary>
        /// For Every Faction, add new Faction Relation List.
        /// </summary>
        public static void ResetRelations()
        {
            Factions.ForEach(faction =>
            {
                faction.Relations.Clear();
                foreach (Faction otherFaction in Factions/*.Where(otherFaction => !otherFaction.Id.Equals(faction.Id))*/)
                {
                    faction.Relations.Add(new FactionRelation(faction, otherFaction));
                }
                faction.SetSelfBaseOpinion(100);
            });
            // Factions love themselves, except for the Xyph.
            GetFaction("base_faction_xyph").SetSelfBaseOpinion(-100);
        }



        /// [WIP] Update relations function in.
        public static void UpdateRelations()
        {
            foreach (var faction in Factions)
            {

            }
        }
    }
}
