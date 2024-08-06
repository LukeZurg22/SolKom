using static SolKom.TK.Classes.Data.Modifiers;

namespace SolKom.TK.Classes.Data
{
    public enum PlanetStatistic
    {
        /// <summary>
        /// Short for "Space-Acre", as some unit to measure the amount of plottable space on a Planet or Station.
        /// <br></br>It's used to measure the "size" of a world's habitable space.
        /// </summary>
        Sacre,
        Habitability,
        Devastation
    }


    public class PlanetStats
    {
        public PlanetStats() { }
        public int BaseSacre = 0;

        public int BaseDevastation = 0;
        // [WIP] When updating devastation, get base devestation plus modifiers.

        int _habitability = 0;
        public int BaseHabitability
        {
            get
            {
                return _habitability;
            }
            set
            {
                int sum = _habitability + value;
                if (sum! < 0 && sum! > 100)
                {
                    _habitability = value;
                }
                else
                {
                    if (sum < 0)
                        _habitability = 0;
                    else
                        _habitability = 100;
                }
            }
        }

        public int GetSacre() { return BaseSacre; }
        
        public int GetDevastation()
        {
            return BaseDevastation + 0 + 0 * 1; // [WIP] See? Why not return BaseDevastation with modifiers calculated into it on the fly. Alternatively,
            // the only reason the value is here is to avoid overhead for constantly recalculating every get-attempt.
        }

        public int GetHabitability()
        {
            return BaseHabitability;    // [WIP] change habitability based on : devestation, who owns it, planet type
        }

        // [WIP] if a modifier is added or removed, make the planet dirty and put on naughty list!
        public Dictionary<PlanetModifierID, PlanetModifier>? Modifiers = new();
        public void MarkPlanetAsDirty()
        {
            // [WIP] Code
            // Add to list of planets to update. Maybe multi-thread the updates for every sector?
        }
        public void AddModifier()
        {
            // [WIP] Code
            MarkPlanetAsDirty();
        }
        public void RemoveModifier()
        {
            // [WIP] Code
            MarkPlanetAsDirty();
        }
        public override string ToString()
        {
            return
                $"\tSac / Base Sac: {GetSacre()}/{BaseSacre}" +
                $"\n\tDev / Base Dev: {GetDevastation()}/{BaseDevastation}" +
                $"\n\tHab / Base Hab: {GetHabitability()}/{BaseHabitability}";
        }
    }
}
