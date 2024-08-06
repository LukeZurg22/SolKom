namespace SolKom.TK.Classes.Data
{
    public static class Modifiers
    {
        public enum PlanetModifierID
        {
            modifier_sacre_one, // UNFINISHED
            modifier_two,       // UNFINISHED
            modifier_three,     // UNFINISHED
            modifier_four,      // UNFINISHED
        }
        private static readonly Dictionary<PlanetModifierID, PlanetModifier> PlanetModifiers = new()
        {
            {  PlanetModifierID.modifier_sacre_one, new PlanetModifier(PlanetStatistic.Sacre, 0, "", ModMode.Additive) },
        };
        /*private static readonly Dictionary<Modifier, FactionModifier> FactionModifiers = new()
        {
            {  Modifier.modifier_one, new FactionModifier(PlanetStat.Sacre, 0, "") },
        };*/
    }
}
