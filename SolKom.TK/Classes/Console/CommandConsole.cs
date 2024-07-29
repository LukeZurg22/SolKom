using ConsoleTables;
using SolKom.TK.Classes;

namespace SolKom.TK
{
    public class CommandConsole
    {
        public CommandConsole() { }
        public CommandConsole Initialize()
        {
            MainMenu_Options();
            return this;
        }
        #region MAIN MENU
        void MainMenu_Options()
        {
            Console.WriteLine("~=SolKom Commands Console=~\r");
            Console.WriteLine("--------------------------------------------------------------------");
            Spit("f", ConsoleColor.Blue, "actions - Displays current factions and relations.");
            Spit("p", ConsoleColor.Blue, "lanets - Displays current planets.");
            Spit("g", ConsoleColor.Blue, "overnments - Displays base relation modifiers between all government types.");
            Spit("e", ConsoleColor.Red, "xit - Closes the Game and Console.");
            Console.WriteLine("--------------------------------------------------------------------\n");

            Console.Write("Enter a command: ");
            MainMenu_Input();
        }
        void MainMenu_Input()
        {
            string? result = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("--------------------------------------------------------------------\n");
            switch (result)
            {
                case "factions" or "f":
                    Factions_Options();
                    break;
                case "planets" or "p":
                    Console.WriteLine($"PLANETS CURRENTLY UNFINISHED");
                    break;
                case "governments" or "g":
                    Governments_Options();
                    break;
                case "exit" or "e":
                    Console.WriteLine("Exiting...");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Input invalid or command not present.");
                    break;
            }
            MainMenu_Options();
        }

        void Governments_Options()
        {
            Console.Clear();
            Console.WriteLine("GOVERNMENTS============================================================\n");
            var table = new ConsoleTable("#");
            List<string> governments = Enum.GetNames(typeof(GovernmentType)).ToList();
            foreach (var govType in governments)
            {
                table.Columns.Add(govType);
            }

            int numba = 0;
            var baseOpinionMods = UniversalData.Instance.GetBaseOpinionModifierTable();

            // For each column,
            List<object> values;
            for (int x = 0; x < baseOpinionMods[0].Length; x++)
            {
                values = new() { numba };
                for (int y = 0; y < baseOpinionMods[x].Length; y++)
                {
                    values.Add(baseOpinionMods[y]);
                }
                table.AddRow(values);
                numba++;
            }

            table.Write();
            Console.WriteLine("\nGOVERNMENTS============================================================\n");

            MainMenu_Options();
        }
        #endregion

        #region FACTIONS & RELATIONS
        void Factions_Options()
        {
            Console.Clear();
            Console.WriteLine("FACTONS==============================================================\n");
            var table = new ConsoleTable("#", "FACTION ID", "FACTION NAME", "FACTION GOVERNMENT");
            int numba = 0;
            foreach (var faction in UniversalData.Instance.GetFactions())
            {
                table.AddRow(numba++, faction.Id, faction.Name, faction.GovernmentType);
            }
            table.Write();
            Console.WriteLine("\nFACTONS==============================================================\n");

            Relations_Options();
        }
        void Relations_Options()
        {
            Console.WriteLine("--------------------------------------------------------------------");
            Spit("#", ConsoleColor.Green, " - Select faction from list.");
            Spit("f", ConsoleColor.Blue, "actions - Go to factions menu.");
            Spit("e", ConsoleColor.Red, "xit - Goes back to Main Menu.");
            Console.WriteLine("--------------------------------------------------------------------\n");

            Console.Write("Enter a command: ");
            Relations_Input();
        }
        void Relations_Input()
        {
            var factions = UniversalData.Instance.GetFactions();
            string? result = Console.ReadLine();
            var parsedRight = int.TryParse(result, out int number);
            if (number < factions.Count && number >= 0 && parsedRight)
            {
                Console.Clear();
                Console.WriteLine("RELATIONS=============================================================\n");
                Console.WriteLine($"RELATIONS OF {factions[number].Id} \\/\\/\\/");
                var table = new ConsoleTable("#", "FACTION ID", "OPINION");
                int numba = 0;
                foreach (var relation in factions[number].FactionRelations)
                {
                    table.AddRow(numba++, relation.Id, relation.Opinion);
                }
                table.Write();
                Console.WriteLine("\nRELATIONS=============================================================\n");


                Relations_Options();
                return;
            }

            switch (result)
            {
                case "factions" or "f":
                    Console.WriteLine("Going back...");
                    Factions_Options();
                    return;
                case "exit" or "e":
                    Console.WriteLine("Going back...");
                    MainMenu_Options();
                    return;
                default:
                    Console.WriteLine("Input invalid or command not present.");
                    break;
            }
        }
        #endregion

        void Spit(string text, ConsoleColor inputColor, string otherText)
        {
            ConsoleColor currentColor = Console.ForegroundColor;
            Console.ForegroundColor = inputColor;
            Console.Write(text);
            Console.ForegroundColor = currentColor;
            Console.WriteLine(otherText);
        }

    }
}
