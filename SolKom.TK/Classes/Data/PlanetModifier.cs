namespace SolKom.TK.Classes.Data
{
    public enum ModMode
    {
        Additive,           // Append - for subtract.
        Multiplicative,     // Lower to decimal places for divide.
    }
    public class PlanetModifier
    {
        public PlanetStatistic Stat;
        public int Amount;
        public string Localization = string.Empty;
        public ModMode Mode = ModMode.Additive;
        public PlanetModifier(PlanetStatistic stat, int amount, string localization, ModMode mode) => Instantiate(stat, amount, localization, mode);
        public PlanetModifier(PlanetStatistic stat, int amount, string localization) => Instantiate(stat, amount, localization, ModMode.Additive);
        void Instantiate(PlanetStatistic stat, int amount, string localization, ModMode mode)
        {
            Stat = stat;
            Amount = amount;
            Localization = localization;
            Mode = mode;
        }

    }
}
