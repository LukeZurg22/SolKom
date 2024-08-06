using RandN;
using RandN.Distributions;
using System;

namespace SolKom.TK.Classes
{
    public static class RNG
    {
        public static readonly SmallRng RANDOM_NUMBER_GENERATOR = SmallRng.Create();

        [Obsolete("Replaced by the superior extension-version of this function.")]
        public static string GetRandomElement(string[] array)
        {
            int index = Uniform.NewInclusive(0, array.Length - 1).Sample(RANDOM_NUMBER_GENERATOR);
            return array[index] ?? string.Empty;
        }

        /// <summary>
        /// An assisting Extension function designed for Enumerables.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_">An enumberable.</param>
        /// <returns>A random enum-value from the enum.</returns>
        /// <exception cref="Exception"></exception>
        public static T GetRandomElement<T>(this T _) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum) { throw new Exception("Random enum variable is not an enum."); }

            var values = Enum.GetValues(typeof(T));
            int index = Uniform.NewInclusive(0, values.Length - 1).Sample(RANDOM_NUMBER_GENERATOR);
#pragma warning disable CS8605 // Unboxing a possibly null value.
            return (T)values.GetValue(index);
#pragma warning restore CS8605 // Unboxing a possibly null value.
        }

        public static T GetRandomElement<T>(this T[] array)
        {
            int index = Uniform.NewInclusive(0, array.Length - 1).Sample(RANDOM_NUMBER_GENERATOR);
            return array[index];
        }
    }
}
