using static SolKom.TK.Classes.Data.Modifier;

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

        // [WIP] When updating devastation, get base devestation plus modifiers.
        public int BaseDevastation = 0;

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

        #region Development Stats
        uint _economy = 0;
        public uint Economy
        {
            get
            {
                return _economy;
            }
            set
            {
                _economy = value;
            }
        }

        uint _industry = 0;
        public uint Industry
        {
            get
            {
                return _industry;
            }
            set
            {
                _industry = value;
            }
        }
        // D = devastation %, H = habitability %, 


        uint _society = 0;
        public uint Society
        {
            get
            {
                return _society;
            }
            set
            {
                _society = value;
            }
        }
        #endregion

        public double GetDevCost()
        {
            // [TEMP] Keeping this here because the code below is untrustable. This math is good, but i gotta make sure.
/*            int sacre = GetSacre();
            uint totalDevelopment = GetDevelopment();
            double sacreAdjust = 500 * Math.Log10(Math.Pow(sacre, 2));
            int devastationAdjust = Math.Max(GetDevastation() / 5, 1);
            int habitabilityAdjust = 20 * GetHabitability();
            double exponentialDevCostAdjust = Math.Pow(Math.E, totalDevelopment / 10) / sacre;
            double developmentCost = Math.Round(sacreAdjust * devastationAdjust / habitabilityAdjust) * exponentialDevCostAdjust;*/
            
            int sacre = GetSacre();
            uint totalDevelopment = GetDevelopment();
            double developmentCost = Math.Round(
                500 * Math.Log10(sacre * sacre) * Math.Max(GetDevastation() / 5, 1) / (20 * GetHabitability()) // [WIP] may need to change this. Habitability is from 0->100, not 0->1.
            ) * Math.Pow(Math.E, totalDevelopment / 10.0) / sacre;

            return developmentCost;
        }

        public uint GetDevelopment()
        {
            return Society + Industry + Economy;
        }

        

        public int GetSacre()
        {
            return BaseSacre;
        }

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
        public List<ModifierStruct>? Modifiers = new();
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
