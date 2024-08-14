using SkiaSharp;
using SolKom.TK.Classes;
using System.Drawing;

namespace SolKom.TK
{
    internal class Galaxy
    {
        public Galaxy() { }

        /// <summary>
        /// The sectors of the Galaxy.
        /// </summary>
        Sector[] Sectors;

        public Galaxy GenerateRandomSectors()
        {
            int sectors = RNG.RN(13) + 1;          // Creates a crap ton of sectors. 100% NOT necessary, but tests limits.
            Sectors = new Sector[sectors];
            for (int i = 0; i < sectors; i++)
            {
                Sector sector = new(i);
                Console.WriteLine("Sector " + sector);
                sector.RandomInstantiate();
                Sectors[i] = sector;
            }
            return this;
        }

        // [IMPL] For actual generation of sectors & whatot based on image.
        public void Generate()
        {
            string imagePath = "C:\\Users\\LukeZurg22_Gaming\\source\\repos\\SolKom\\SolKom.TK\\Assets\\galaxy_gen_small.png";
            using (FileStream stream = new(imagePath, FileMode.Open))
            {
                SKBitmap bitmap = SKBitmap.Decode(stream);

                /*  STEPS TODO
                 * Step 1: Divide image into sectors.
                 * Step 2: For every sector -> for every pixel in that sector -> {
                 * ) Roll a dice.
                 * ) If that dice is in a certain range depending on pixel color, plop a random planet.
                 * ) Else, do nothing and keep going.
                 * NOTE: ONLY CREATE SECTORS. Each sector creates its own set of systems.
                 */

                for (int i = 0; i < bitmap.Width; i++)
                {
                    for (int j = 0; j < bitmap.Height; j++)
                    {
                        var pixel = bitmap.GetPixel(i, j);
                        Console.Write(" " + pixel.ToString());

                        /*if (pixel == *somecondition *)
                        {
                            //**Store pixel here in a array or list or whatever**
                        }*/
                    }
                }
                Console.Write("\n");
            }


        }
    }
}
