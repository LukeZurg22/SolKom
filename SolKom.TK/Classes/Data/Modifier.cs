#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace SolKom.TK.Classes.Data
{
    public enum ModMode
    {
        Additive,           // Append - for subtract.
        Multiplicative,     // Lower to decimal places for divide.
        Equalitative,       // Simply just *assigns* the value, above all else.
    }
    public readonly struct ModifierStruct
    {
#pragma warning disable IDE0052 // Remove unread private members
        public readonly Enum ModifierID;
        readonly string EnglishLocalization;
        readonly string GermanLocalization;
        readonly Modifier[] Modifiers;
#pragma warning restore IDE0052 // Remove unread private members

        public ModifierStruct(Enum id, string english, string german, Modifier[] modifiers)
        {
            ModifierID = id;
            EnglishLocalization = english;
            GermanLocalization = german;
            Modifiers = modifiers;
        }
        public ModifierStruct(Enum id, string english, Modifier[] modifiers)
        {
            ModifierID = id;
            EnglishLocalization = english;
            GermanLocalization = "no_localization";
            Modifiers = modifiers;
        }
    }

    #region Defined Modifiers
    public enum GalaxyModifier
    {
        ETERNAL_WAR,        // UNFINISHED
        XURNACHT_STORM,     // UNFINISHED
    }
    public enum SectorModifier
    {
        CHAOS_HUME_EFFECT,  // UNFINISHED
    }
    public enum SystemModifier
    {
        CHAOS_CURSE,        // UNFINISHED
    }
    public enum PlanetModifier
    {
        CAPITAL_PLANET,
        CHAOS_INFESTATION,  // UNFINISHED
        modifier_two,       // UNFINISHED
        modifier_three,     // UNFINISHED
        modifier_four,      // UNFINISHED
    }
    public enum FactionModifier // UNFINISHED
    {

    }
    public enum RelationModifier
    {
        BASE_OPINION,
        BASE_GOVERNMENT_OPINION,
    }
    #endregion

    public class Modifier
    {
        private static readonly List<ModifierStruct> PLANET_MODIFIERS = new()
        {
            { new ModifierStruct(
                PlanetModifier.CAPITAL_PLANET, "Capital Planet", "Hauptstadtplanet",
                new Modifier[] {
                    new Modifier(PlanetStatistic.Sacre, 5, ModMode.Additive),
                    new Modifier(PlanetStatistic.Habitability, 100, ModMode.Equalitative),
                }
            )},
        };
        private static readonly List<ModifierStruct> FACTION_MODIFIERS = new()
        {

        };
        private static readonly List<RelationStruct> RELATION_MODIFIERS = new()
        {
            { new RelationStruct(RelationModifier.BASE_OPINION, "Base Opinion", "Grundmeinung", 0) },
            { new RelationStruct(RelationModifier.BASE_GOVERNMENT_OPINION, "Opposing Government", "Die Opposition", 0)},
        };

        public static ModifierStruct GetDefinedModifier(Enum modifier) 
        {
            switch(modifier)
            {
                case GalaxyModifier gm:
                    break;
                case SectorModifier secm:
                    break;
                case SystemModifier sysm:
                    break;
                case PlanetModifier pm:
                    return PLANET_MODIFIERS.First(@struct => @struct.ModifierID.Equals(pm));
                case FactionModifier fm:
                    break;
            }
            return default; // [TEMP] stopgap.
        }

        public static RelationStruct GetDefinedRelationModifier(RelationModifier modifier) => GetDefinedRelationModifier(modifier, null, null);
        
        public static RelationStruct GetDefinedRelationModifier(RelationModifier modifier, Faction? aggressor, Faction? defender)
        {
            RelationStruct foundModifier = RELATION_MODIFIERS.First(@struct => @struct.Equals(modifier));

            // Return a modified version of the Relation modifier for Government Type opinion modifier.
            if (aggressor != null && defender != null && modifier.Equals(RelationModifier.BASE_GOVERNMENT_OPINION))
            {
                foundModifier.SetValue(Faction.GetBaseOpinion(aggressor.GovernmentType, defender.GovernmentType));
            }
            return foundModifier;

        }
        

        protected Enum Stat;
        protected int Amount;
        protected ModMode Mode = ModMode.Additive;
        public Modifier(Enum stat, int amount, ModMode mode) => Instantiate(stat, amount, mode);
        public Modifier(Enum stat, int amount) => Instantiate(stat, amount, ModMode.Additive);
        void Instantiate(Enum stat, int amount, ModMode mode)
        {
            Stat = stat;
            Amount = amount;
            Mode = mode;
        }
    }
}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
