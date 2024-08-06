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
        public int Sacre = 5;
        int _habitability = 0;
        public int Habitability
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
        public int Devastation = 0;
    }
}
