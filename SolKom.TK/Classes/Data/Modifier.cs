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
        readonly Enum ModifierID;
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
    enum GalaxyModifier
    {
        ETERNAL_WAR,        // UNFINISHED
        XURNACHT_STORM,     // UNFINISHED
    }
    enum SectorModifier
    {
        CHAOS_HUME_EFFECT,  // UNFINISHED
    }
    enum SystemModifier
    {
        CHAOS_CURSE,        // UNFINISHED
    }
    enum PlanetModifier
    {
        CAPITAL_PLANET,
        CHAOS_INFESTATION,  // UNFINISHED
        modifier_two,       // UNFINISHED
        modifier_three,     // UNFINISHED
        modifier_four,      // UNFINISHED
    }
    enum FactionModifier // UNFINISHED
    {

    }

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
