namespace SolKom.TK.Classes.Data
{
    public static class Modifiers
    {
        enum Modifier
        {
            modifier_one,
            modifier_two,
            modifier_three,
            modifier_four,
        }
        private static readonly Dictionary<Modifier, PlanetModifier> PlanetModifiers = new()
        {
            {  Modifier.modifier_one, new PlanetModifier(PlanetStatistic.Sacre, 0, "", ModMode.Additive) },
        };
        /*private static readonly Dictionary<Modifier, FactionModifier> FactionModifiers = new()
        {
            {  Modifier.modifier_one, new FactionModifier(PlanetStat.Sacre, 0, "") },
        };*/
    }
}
