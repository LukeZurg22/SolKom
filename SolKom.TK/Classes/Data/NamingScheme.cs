using RandN;
using RandN.Distributions;

namespace SolKom.TK.Classes.Data
{
    public enum NamingPattern
    {
        Numerical,
        Human,
        Rogue,
        Sarakaan,
        Niecronian,
        Xyphonian,
        Circibon,

        Null,           // [WIP] Alternate to Rogue.
        Old_Niecronian, // [WIP] Old Niecronian Names : non-verbs.
    }

    public class Scheme
    {
        static readonly string[] Numerical_FirstNames = { "Unit", "Entity" };
        static readonly string[] Numerical_LastNames = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99", "100", "101", "102", "103", "104", "105", "106", "107", "108", "109", "110", "111", "112", "113", "114", "115", "116", "117", "118", "119", "120", "121", "122", "123", "124", "125", "126", "127", "128", "129", "130", "131", "132", "133", "134", "135", "136", "137", "138", "139", "140", "141", "142", "143", "144", "145", "146", "147", "148", "149", "150", "151", "152", "153", "154", "155", "156", "157", "158", "159", "160", "161", "162", "163", "164", "165", "166", "167", "168", "169", "170", "171", "172", "173", "174", "175", "176", "177", "178", "179", "180", "181", "182", "183", "184", "185", "186", "187", "188", "189", "190", "191", "192", "193", "194", "195", "196", "197", "198", "199", "200", "201", "202", "203", "204", "205", "206", "207", "208", "209", "210", "211", "212", "213", "214", "215", "216", "217", "218", "219", "220", "221", "222", "223", "224", "225", "226", "227", "228", "229", "230", "231", "232", "233", "234", "235", "236", "237", "238", "239", "240", "241", "242", "243", "244", "245", "246", "247", "248", "249", "250", "251", "252", "253", "254", "255", "256", "257", "258", "259", "260", "261", "262", "263", "264", "265", "266", "267", "268", "269", "270", "271", "272", "273", "274", "275", "276", "277", "278", "279", "280", "281", "282", "283", "284", "285", "286", "287", "288", "289", "290", "291", "292", "293", "294", "295", "296", "297", "298", "299", "300", "301", "302", "303", "304", "305", "306", "307", "308", "309", "310", "311", "312", "313", "314", "315", "316", "317", "318", "319", "320", "321", "322", "323", "324", "325", "326", "327", "328", "329", "330", "331", "332", "333", "334", "335", "336", "337", "338", "339", "340", "341", "342", "343", "344", "345", "346", "347", "348", "349", "350", "351", "352", "353", "354", "355", "356", "357", "358", "359", "360", "361", "362", "363", "364", "365", "366", "367", "368", "369", "370", "371", "372", "373", "374", "375", "376", "377", "378", "379", "380", "381", "382", "383", "384", "385", "386", "387", "388", "389", "390", "391", "392", "393", "394", "395", "396", "397", "398", "399", "400" };
        static readonly string[] Numerical_PlanetNames = { "Planet", "Celestial Body", "Overspace Entity", "Gravity Well" };
        static readonly string[] Human_FirstNames = { "Aadil", "Aaron", "Abigail", "Adel", "Adil", "Adnan", "Adrian", "Ahmed", "Aiden", "Alexander", "Ali", "Amelia", "Amin", "Andrew", "Angel", "Anthony", "Anwar", "Aria", "Asher", "Aurora", "Ava", "Avery", "Ayman", "Bader", "Bahaa", "Bassam", "Bassem", "Benjamin", "Bilal", "Caleb", "Cameron", "Carter", "Charles", "Charlotte", "Chloe", "Christopher", "Cooper", "Dawood", "Delilah", "Diya", "Diyar", "Ehab", "Elena", "Eliana", "Elijah", "Ella", "Ellie", "Emad", "Emilia", "Emily", "Emma", "Evelyn", "Ezekiel", "Ezra", "Fadi", "Fahed", "Faisal", "Farid", "Firas", "Gabriel", "Ghaith", "Ghassan", "Ghazi", "Gianna", "Grace", "Grayson", "Hadi", "Hakeem", "Hamza", "Hannah", "Harith", "Harper", "Hassan", "Haytham", "Hazel", "Henry", "Ibrahim", "Imran", "Isaac", "Isabella", "Isaiah", "Isla", "Ismail", "Ivy", "Jabir", "Jack", "Jafar", "James", "Jamil", "Jawad", "Jayden", "Joshua", "Josiah", "Kai", "Kamal", "Kareem", "Karim", "Khalaf", "Khalid", "Labeeb", "Lainey", "Laith", "Layla", "Leah", "Leo", "Levi", "Liam", "Liliana", "Lily", "Lincoln", "Logan", "Luay", "Luca", "Lucas", "Lucy", "Luna", "Lutfi", "Maan", "Maaz", "Madison", "Mahdi", "Majid", "Mansour", "Marwan", "Mateo", "Maya", "Mia", "Mila", "Miles", "Muammar", "Munir", "Naif", "Naomi", "Nasir", "Nasser", "Nathan", "Nidal", "Noah", "Nolan", "Nora", "Nour", "Nova", "Oliver", "Olivia", "Omar", "Othman", "Penelope", "Qais", "Qasim", "Rabih", "Raed", "Rafik", "Raheem", "Rami", "Rashad", "Rashid", "Riley", "Roman", "Sadeq", "Saeed", "Salman", "Sami", "Samir", "Santiago", "Sophia", "Stella", "Sufyan", "Tahir", "Talal", "Tamer", "Tariq", "Theodore", "Thomas", "Usama", "Uthman", "Valentina", "Victoria", "Wael", "Wafi", "Wajdi", "Waleed", "Waylon", "William", "Willow", "Wyatt", "Yahya", "Yasir", "Yassin", "Yusuf", "Zafar", "Zaid", "Zakaria", "Zaki", "Zayn", "Zoe", "Zoey" };
        static readonly string[] Human_LastNames = { "Abadi", "Abdul", "Adams", "Ahmadi", "Ajami", "Al-Abadi", "Al-Abdul", "Al-Ahmadi", "Al-Ajami", "Al-Alami", "Al-Ali", "Al-Amari", "Alami", "Al-Amin", "Al-Amine", "Al-Anbari", "Al-Arabi", "Al-Asadi", "Al-Assad", "Al-Attar", "Al-Awadhi", "Al-Awlaqi", "Al-Aziz", "Al-Azm", "Al-Badr", "Al-Bakri", "Al-Barazi", "Al-Barghouti", "Al-Bazzar", "Albrecht", "Al-Bunni", "Al-Dabbagh", "Al-Dahwi", "Al-Darwish", "Al-Fahad", "Al-Fakih", "Al-Farsi", "Al-Fatimah", "Al-Fayad", "Al-Ghamdi", "Al-Ghazi", "Al-Habib", "Al-Hadid", "Al-Hakim", "Al-Hammadi", "Al-Hassan", "Al-Hendi", "Al-Husseini", "Ali", "Al-Ibrahim", "Al-Jabbar", "Al-Jabouri", "Al-Jamal", "Al-Jawadi", "Al-Kabir", "Al-Khalifa", "Al-Khatib", "Al-Khouri", "Al-Kinani", "Al-Latif", "Allen", "Al-Maliki", "Al-Mansour", "Al-Masri", "Al-Mohammed", "Al-Muammar", "Al-Mughni", "Al-Najjar", "Al-Nashmi", "Al-Nasser", "Al-Omari", "Al-Qadi", "Al-Qassim", "Al-Rahim", "Al-Rashid", "Al-Rawi", "Al-Sabah", "Al-Sadiq", "Al-Safar", "Al-Saghir", "Al-Said", "Al-Saif", "Al-Salman", "Al-Samarrai", "Al-Shamari", "Al-Sharif", "Al-Shehri", "Al-Sudairi", "Al-Tamimi", "Al-Tikriti", "Al-Turki", "Al-Ubaydi", "Alvarez", "Al-Wafi", "Al-Walid", "Al-Yamani", "Al-Yazidi", "Al-Zahra", "Al-Zahrani", "Al-Zaid", "Al-Zain", "Al-Zarqawi", "Al-Zawawi", "Al-Zeidan", "Al-Ziyadi", "Al-Zuhair", "Al-Zuhd", "Al-Zuhri", "Amari", "Amin", "Amine", "Anbari", "Anderson", "Arabi", "Arnold", "Asadi", "Assad", "Attar", "Awadhi", "Awlaqi", "Aziz", "Azm", "Badr", "Bailey", "Baker", "Bakri", "Barazi", "Barghouti", "Bauer", "Baumann", "Bazzar", "Beck", "Becker", "Bennet", "Berger", "Bergmann", "Böhm", "Brandt", "Braun", "Brooks", "Brown", "Bunni", "Busch", "Campbell", "Carter", "Castillo", "Chavez", "Clark", "Collins", "Cook", "Cooper", "Cox", "Cruz", "Dabbagh", "Dahwi", "Darwish", "Davis", "Diaz", "Dietrich", "Edwards", "Engel", "Evans", "Fahad", "Fakih", "Farsi", "Fatimah", "Fayad", "Fischer", "Flores", "Foster", "Frank", "Franke", "Friedrich", "Fuchs", "Garcia", "Ghamdi", "Ghazi", "Gomez", "Gonzales", "Graf", "Gray", "Green", "Groß", "Günther", "Gutierrez", "Haas", "Habib", "Hadid", "Hahn", "Hakim", "Hall", "Hammadi", "Harris", "Hartmann", "Hassan", "Heinrich", "Hendi", "Hernandez", "Herrmann", "Hill", "Hoffmann", "Hofmann", "Horn", "Howard", "Huber", "Hughes", "Husseini", "Ibrahim", "Jabbar", "Jabouri", "Jackson", "Jäger", "Jamal", "James", "Jawadi", "Jimenez", "Johnson", "Jones", "Jung", "Kabir", "Kaiser", "Keller", "Kelly", "Khalifa", "Khatib", "Khouri", "Kim", "Kinani", "King", "Klein", "Koch", "Köhler", "König", "Krämer", "Kraus", "Krause", "Krüger", "Kuhn", "Kühn", "Lang", "Lange", "Latif", "Lee", "Lehmann", "Lewis", "Long", "Lopez", "Lorenz", "Ludwig", "Maier", "Maliki", "Mansour", "Martin", "Martinez", "Masri", "Mayer", "Meier", "Mendoza", "Meyer", "Miller", "Mitchell", "Mohammed", "Möller", "Moore", "Morales", "Morgan", "Morris", "Muammar", "Mughni", "Müller", "Murphy", "Myers", "Najjar", "Nashmi", "Nasser", "Nelson", "Neumann", "Nguyen", "Omari", "Ortiz", "Otto", "Parker", "Patel", "Perez", "Peters", "Peterson", "Pfeiffer", "Phillips", "Pohl", "Price", "Qadi", "Qassim", "Rahim", "Ramirez", "Ramos", "Rashid", "Rawi", "Reed", "Reyes", "Richardson", "Richter", "Rivera", "Roberts", "Robinson", "Rodriguez", "Rogers", "Ross", "Roth", "Ruiz", "Sabah", "Sadiq", "Safar", "Saghir", "Said", "Saif", "Salman", "Samarrai", "Sanchez", "Sanders", "Sauer", "Schäfer", "Schmid", "Schmidt", "Schmitt", "Schmitz", "Schneider", "Scholz", "Schreiber", "Schröder", "Schubert", "Schulte", "Schulz", "Schulze", "Schumacher", "Schuster", "Schwarz", "Scott", "Seidel", "Shamari", "Sharif", "Shehri", "Simon", "Smith", "Sommer", "Stein", "Stewart", "Sudairi", "Tamimi", "Taylor", "Thomas", "Thompson", "Tikriti", "Torres", "Turki", "Turner", "Ubaydi", "Vogel", "Vogt", "Voigt", "Wafi", "Wagner", "Walid", "Walker", "Walter", "Ward", "Watson", "Weber", "Weiß", "Werner", "White", "Williams", "Wilson", "Winkler", "Winter", "Wolf", "Wolff", "Wood", "Wright", "Yamani", "Yazidi", "Young", "Zahra", "Zahrani", "Zaid", "Zain", "Zarqawi", "Zawawi", "Zeidan", "Ziegler", "Zimmermann", "Ziyadi", "Zuhair", "Zuhd", "Zuhri" };
        static readonly string[] Human_PlanetNames = { "Aegis", "Aeon", "Aether", "Aether Prime", "Altair", "Andromeda", "Andromeda Nexus", "Andromeda Prime", "Antares", "Arcadia", "Arcadia Prime", "Astra", "Astraea", "Astral", "Astral Prime", "Astralis", "Astralis Prime", "Astrid", "Astronomia", "Atlantis", "Aurora", "Aurora Australis", "Aurora Borealis", "Aurora Eterna", "Aurora Prime", "Aurora Sanctum", "Aurora Vortex", "Avalon", "Borealis", "Borealis Prime", "Celeste", "Celestia", "Celestia Prime", "Centauri", "Eclipse", "Eden", "Eden Prime", "Elysium", "Equinox", "Excalibur", "Exoplanet", "Exoplanet Prime", "Galatea", "Genesis", "Harmonia", "Helios", "Helios Prime", "Heliosphere", "Horizon", "Hyperborea", "Hyperion", "Hyperion Nexus", "Illumina", "Lumina", "Lumina Prime", "Lyra", "Meridian", "Nebula", "Nebula Prime", "Nexus", "Nova Prime", "Nova Terra", "Olympus", "Omega", "Orion", "Orion Prime", "Paragon", "Phoenix", "Polaris", "Prometheus", "Prometheus Prime", "Quantum", "Radiance", "Radiant", "Radiant Prime", "Seraph", "Serendipity", "Sirius", "Sol Invictus", "Solara", "Solara Prime", "Solaris", "Solaris Nexus", "Solstice", "Starfall", "Starlight", "Starlight Haven", "Stellar", "Tempest", "Terra Nova", "Thalassa", "Titania", "Utopia", "Valhalla", "Valhalla Nexus", "Vega", "Vesper", "Zenith", "Zenith Horizon", "Zenith Prime" };
        static readonly string[] Rogue_FirstNames = { "Bane", "Bankrup", "Enzin", "He", "Jeltzin", "Jerry", "Jesh", "Jimmy", "Joe", "John", "Juntonsson", "Jurgen", "Kill", "Mark", "Mateo", "McGraw", "Mordak", "Rodnev", "Ronaj", "Shane", "Tumult", "Vendetta" };
        static readonly string[] Rogue_LastNames = { "Blackeye", "Burnhard", "C. Johnas", "Ho", "Ironbones", "Ironhide", "J. Johnas", "Metalmeat", "of Merchants", "of the Weak", "of the Week", "Ohnen", "Raulnor", "Space", "Steelhide", "the Businessman", "the Janitor", "Zero" };
        static readonly string[] Rogue_PlanetNames = { "Black Site", "Branch Office", "Hideout", "Office", "Rogue Site", "Restored Site", "Inhabited Zone", "Sector-Filler" };
        static readonly string[] Sarakaan_FirstNames = { "Alakzandr", "Amaunator", "Halafax", "Halat", "Havano", "Lauhn", "Leugh'An", "Lorenzo", "Sofont", "Xyn'Sara" };
        static readonly string[] Sarakaan_LastNames = { "Abbot", "Dean", "Pohst", "Vincere", "Rh'Ch'Nak", "Vohn'Vanak", "Lin'Ag'Tch", "Va'Sarak", "Na'Sarakiin", "Naseverin" };
        static readonly string[] Sarakaan_PlanetNames = { "Vralakar", "Zar'kalthar", "Reminit", "Valianakar", "Jullakkarath", "Clemence Station" };
        static readonly string[] Niecronian_FirstNames = { "Ensign", "Cadet", "Lieutenant", "Captain", "Admiral", "High Admiral", "Nero" };
        static readonly string[] Niecronian_LastNames = { "Na-Ereziak", "Na-Etinak", "Na-Krazak", "Na-Lerak", "Na-Lohinak", "Na-Nia'tak", "Na-Rovinak", "Na-Ryak", "Na-Rylorak", "Na-Sarak", "Na-Turak", "Na-Vayak", "Na-Volurak" };
        static readonly string[] Niecronian_PlanetNames = { "Occupied Planet", "Occupation Zone", "Seized Planet", "Junta Government", "Base of Operations" };
        static readonly string[] Xyphonian_FirstNames = { "Del'Acht", "Et'ach", "Nim'Xach", "N'Tck'Tck", "Toh'Acht", "Xan'Lak", "Xarachtne", "Xiezchak", "Xin'Anach", "Xyph" };
        static readonly string[] Xyphonian_LastNames = { "the Diabolical", "the Engorged", "the Grunt", "the Inferior", "the Maddened", "the Marauder", "the Meager", "the Render of Flesh", "the Rotpiler", "the Trapped", "the Violent", "the Warmonger", "Xyph" };
        static readonly string[] Circibon_FirstNames = { "AT1", "B0", "CL1", "CU", "D0C", "D1", "Gage", "J0", "J0N", "J1", "J2", "J3", "J4", "Kilang", "N3" };
        static readonly string[] Circibon_LastNames = { "13", "3Y", "B1", "D3", "D4", "L0", "L2", "M", "T3R", "Type-7", "X1", "X2", "X3", "X4", "X5" };
        static readonly string[] Circibon_PlanetNames = { "Discovery", "Eclipse", "Epsilon", "Foree", "Gammapoint", "Horizon", "New Circia", "New Forgepoint", "New Mezak", "New Xanak", "Nexorium", "Sepulcher" };

        string _title = string.Empty;
        public string Title
        {
            get
            {
                if (!string.IsNullOrEmpty(_title))
                    return _title;
                else
                    return "No Scheme";
            }
            set
            {
                _title = value;
            }
        }
        string[] FirstNames { get; set; } = Array.Empty<string>();
        string[] LastNames { get; set; } = Array.Empty<string>();
        string[] PlanetNames { get; set; } = Array.Empty<string>();

        public Scheme() => AssignPattern(NamingPattern.Numerical);
        public Scheme(NamingPattern pattern) => AssignPattern(pattern);
        void AssignPattern(NamingPattern pattern)
        {
            switch (pattern)
            {
                case NamingPattern.Numerical:
                    Title = "Numerical";
                    FirstNames = Numerical_FirstNames;
                    LastNames = Numerical_LastNames;
                    PlanetNames = Numerical_PlanetNames;
                    break;
                case NamingPattern.Human:
                    Title = "Human";
                    FirstNames = Human_FirstNames;
                    LastNames = Human_LastNames;
                    PlanetNames = Human_PlanetNames;
                    break;
                case NamingPattern.Rogue:
                    Title = "Rogue";
                    FirstNames = Rogue_FirstNames;
                    LastNames = Rogue_LastNames;
                    PlanetNames = Rogue_PlanetNames;
                    break;
                case NamingPattern.Sarakaan:
                    Title = "Sarakaan";
                    FirstNames = Sarakaan_FirstNames;
                    LastNames = Sarakaan_LastNames;
                    PlanetNames = Sarakaan_PlanetNames;
                    break;
                case NamingPattern.Niecronian:
                    Title = "Niecronian";
                    FirstNames = Niecronian_FirstNames;
                    LastNames = Niecronian_LastNames;
                    PlanetNames = Niecronian_PlanetNames;
                    break;
                case NamingPattern.Xyphonian:
                    Title = "Xyphonian";
                    FirstNames = Xyphonian_FirstNames;
                    LastNames = Xyphonian_LastNames;
                    PlanetNames = Numerical_PlanetNames;
                    break;
                case NamingPattern.Circibon:
                    Title = "Circibon";
                    FirstNames = Circibon_FirstNames;
                    LastNames = Circibon_LastNames;
                    PlanetNames = Circibon_PlanetNames;
                    break;
                /*case NamingPattern.Null:
                    break;
                case NamingPattern.Old_Niecronian:
                    break;*/
                default:
                    Title = "Undefined";
                    FirstNames = Numerical_FirstNames;
                    LastNames = Numerical_LastNames;
                    PlanetNames = Numerical_PlanetNames;
                    break;
            }
        }

        static string GetRandomElement(string[] array)
        {
            int index = Uniform.NewInclusive(0, array.Length - 1).Sample(UniversalData.RANDOM_NUMBER_GENERATOR);
            return array[index] ?? string.Empty;
        }
        public string GetRandomFirstName() => GetRandomElement(FirstNames);

        public string GetRandomLastName() => GetRandomElement(LastNames);

        public string GetRandomPlanetName() => GetRandomElement(PlanetNames);
    }

}

