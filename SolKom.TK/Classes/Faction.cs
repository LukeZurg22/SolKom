#pragma warning disable IDE0052 // Remove unread private members
using SolKom.TK.Classes.Data;
using System.Drawing;

namespace SolKom.TK.Classes
{

    public struct RelationStruct : IEquatable<RelationModifier>
    {
        readonly Enum ModifierID;
        readonly string EnglishLocalization;
        readonly string GermanLocalization;
        int ModifierValue;

        public RelationStruct(Enum modifierID, string englishLocalization, string germanLocalization, int modifierValue)
        {
            ModifierID = modifierID;
            EnglishLocalization = englishLocalization;
            GermanLocalization = germanLocalization;
            ModifierValue = modifierValue;
        }

        /// [WIP] THIS FUNCTION IS BROKEN SOMEHOW. VALUE DOES NOT CARRY OVER POST THIS-INSTANCE.
        public void SetValue(int value) => ModifierValue = value;
        public int GetValue() => ModifierValue;

        public Enum GetModifierID() => ModifierID;

        public bool Equals(RelationModifier other) => this.ModifierID.Equals(other);
        
    }

    // [WIP] Maybe convert RelationModifiers to actual modifiers.
    public class FactionRelation
    {
        int _opinion = 0;
        public int Opinion
        {
            get
            {
                int sum = 0;
                for (int i = 0; i < Modifiers.Count; i++)
                {
                    RelationStruct modifier = Modifiers[i];
                    sum += modifier.GetValue();
                }
                return sum;
            }
            private set { _opinion = value; }
        }
        public string OtherFactionID = string.Empty;
        public List<RelationStruct> Modifiers = new();
        
        public FactionRelation(Faction sender, Faction reciever)
        {
            OtherFactionID = reciever.Id;

            // Add starting modifier for government types.
            Modifiers.Add(Modifier.GetDefinedRelationModifier(RelationModifier.BASE_OPINION, sender, reciever));
            Modifiers.Add(Modifier.GetDefinedRelationModifier(RelationModifier.BASE_GOVERNMENT_OPINION, sender, reciever));
        }

        // [WIP] PROBLEM HERE
        // Search for the first item in the list that matches the targetModifierID
        public void SetModifierValue(RelationModifier modifierID, int value)
        {
            for (int i = 0; i < Modifiers.Count; i++)
            {
                if (Modifiers[i].Equals(modifierID))
                {
                    var temp = Modifiers[i];    // Copy the struct
                    temp.SetValue(value);       // Modify the copy
                    Modifiers[i] = temp;        // Update the struct in the list
                    break;
                }
            }
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
        public PoliticalStatus PoliticalStatus = new();
        public FactionStats Stats = new();
        public List<Planet>? Planets; // [WIP] Instead of planets pointing to their factions, factions point to planets?
        public List<FactionRelation> Relations = new();
        public List<ModifierStruct>? Modifiers = new();

        public void AddRelationModifier(Faction other, RelationModifier modifier, bool isMutual)
        {
            /// Add Relation about Other Faction to this Faction
            var existingRelationModifier = Modifier.GetDefinedRelationModifier(modifier);
            FactionRelation? otherRelation = Relations.First(relation => relation.OtherFactionID.Equals(other.Id));
            otherRelation ??= new(this, other);     // If the relation doesn't exist, make it!
            this.Relations.Add(otherRelation);

            /// Add this Faction to Other Faction
            if (isMutual)
            {
                if (other != null)
                    other.AddRelationModifier(this, modifier, false);
                else
                    throw new Exception("Other faction returned null when setting mutual relations.");
            }
        }
        public void SetSelfBaseOpinion(int opinion) => SetBaseOpinion(this, opinion, false);
        public void SetBaseOpinion(Faction target, int opinion, bool isMutual)
        {
            FactionRelation? factionRelation = Relations.First(relation => relation.OtherFactionID.Equals(target.Id));
            factionRelation.SetModifierValue(RelationModifier.BASE_OPINION, opinion);
            if (isMutual)
            {
                if (target != null)
                    target.SetBaseOpinion(this, opinion, false);
                else
                    throw new Exception("Other faction returned null when setting mutual relations.");
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
#pragma warning restore IDE0052 // Remove unread private members
