using ConsoleTables;
using SolKom.TK.Classes;
using SolKom.TK.Classes.Data;

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
            DisplayOptions(new Option[]
            {
                new Option("f", ConsoleColor.Blue, "actions - Displays current factions and relations."),
                new Option("p", ConsoleColor.Blue, "lanets - Displays current planets."),
                new Option("s", ConsoleColor.Blue, "ystems - Displays current systems."),
                new Option("g", ConsoleColor.Blue, "overnments - Displays base relation modifiers between all government types."),
                new Option("e", ConsoleColor.Red, "xit - Closes the Game and Console.")
            });
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
                    Factions_Display();
                    break;
                case "planets" or "p":
                    for (int i = 0; i < 10; i++)
                    {
                        var randomFaction = UniversalData.Instance.GetFactions().ToArray().GetRandomElement();
                        Console.WriteLine(new Planet(randomFaction).ToPrintString());
                    }
                    break;
                case "systems" or "s":
                    Console.WriteLine($"SYSTEMS CURRENTLY UNFINISHED");
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

        #endregion

        #region FACTIONS & RELATIONS
        void Factions_Display()
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

            Factions_Options();
        }
        void Factions_Options()
        {
            DisplayOptions(new Option[]
            {
                new Option("#", ConsoleColor.Green, " - Select faction from list."),
                new Option("f", ConsoleColor.Blue, "actions - Go to factions menu."),
                new Option("e", ConsoleColor.Red, "xit - Goes back to Main Menu.")
            });
            Console.Write("Enter a command: ");
            Factions_Input();
        }
        void Factions_Input()
        {
            var factions = UniversalData.Instance.GetFactions();
            string? result = Console.ReadLine();
            var entryIsNumber = int.TryParse(result, out int number);
            if (entryIsNumber && number < factions.Count && number >= 0)
            {
                Specific_Faction_Options(factions[number]);
                return;
            }
            switch (result)
            {
                case "factions" or "f":
                    Console.WriteLine("Going back...");
                    Factions_Display();
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
        void Specific_Faction_Options(Faction faction)
        {
            var table = new ConsoleTable("FACTION ID", "FACTION NAME", "FACTION GOVERNMENT", "NAMING SCHEME");
            table.AddRow(faction.Id, faction.Name, faction.GovernmentType, faction.NamingScheme.Title);
            table.Write();

            DisplayOptions(new Option[]
            {
                new Option("r", ConsoleColor.Green, " - See faction's relations with other factions."),
                new Option("e", ConsoleColor.Red, "xit - Goes back to factions list..")
            });
            Specific_Faction_Input(faction);
        }
        void Specific_Faction_Input(Faction faction)
        {
            string? result = Console.ReadLine();
            switch (result)
            {
                case "relations" or "r":
                    Console.WriteLine("Going back...");
                    Specific_Faction_Relations(faction);
                    return;
                case "exit" or "e":
                    Console.WriteLine("Going back...");
                    Factions_Display();
                    return;
                default:
                    Console.WriteLine("Input invalid or command not present.");
                    break;
            }
        }
        void Specific_Faction_Relations(Faction faction)
        {
            Console.Clear();
            Console.WriteLine("RELATIONS=============================================================\n");
            Console.WriteLine($"RELATIONS OF {faction.Id} \\/\\/\\/");
            var table = new ConsoleTable("#", "FACTION ID", "OPINION");
            int numba = 0;
            foreach (var relation in faction.Relations)
            {
                table.AddRow(numba++, relation.Id, relation.Opinion);
            }
            table.Write();
            Console.WriteLine("\nRELATIONS=============================================================\n");
            Specific_Faction_Options(faction);
        }
        #endregion

        #region GOVERNMENT
        void Governments_Options()
        {
            Console.Clear();
            Console.WriteLine("GOVERNMENTS============================================================\n");
            Console.WriteLine($"GOVERNMENT TYPE OPINION ARE BASE MODIFIERS \\/\\/\\/");
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
                    values.Add(baseOpinionMods[x][y]);
                }
                table.AddRow(values.ToArray());
                numba++;
            }

            table.Write();
            Console.WriteLine("\nGOVERNMENTS============================================================\n");

            MainMenu_Options();
        }
        #endregion

        /// <summary>
        /// "Spits" out colored text, alongside any text put adjacent to it.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="inputColor"></param>
        /// <param name="otherText">This is here simplify for simplicity and convienience.</param>
        static void Spit(string text, ConsoleColor inputColor, string otherText)
        {
            ConsoleColor currentColor = Console.ForegroundColor;
            Console.ForegroundColor = inputColor;
            Console.Write(text);
            Console.ForegroundColor = currentColor;
            Console.WriteLine(otherText);
        }
        static void DisplayOptions(params Option[] options)
        {
            Console.WriteLine("--------------------------------------------------------------------");
            foreach (Option option in options)
                Spit(option.hindText, option.hindTextColor, option.foreText);
            Console.WriteLine("--------------------------------------------------------------------\n");
        }
        class Option
        {
            public string hindText = string.Empty;
            public ConsoleColor hindTextColor = ConsoleColor.Blue;
            public string foreText = string.Empty;
            public Option(string hind, ConsoleColor color, string front)
            {
                hindText = hind;
                hindTextColor = color;
                foreText = front;
            }
        }
    }
}
