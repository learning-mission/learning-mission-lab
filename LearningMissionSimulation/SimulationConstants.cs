using System;
using System.Collections.Generic;

namespace LearningMissionSimulation
{
    public class SimulationConstants
    {
        // Minimum valid building number
        public static readonly byte MinBuildingNumber = 1;
        // Maximum valid building number
        public static readonly byte MaxBuildingNumber = 200;
        // Minimum valid appartment number
        public static readonly byte MinApartmentNumber = 1;
        // Maximum valid appartment number
        public static readonly byte MaxApartmentNumber = 100;
        // Minimum valid applicant age
        public static readonly byte ApplicantMinAge = 18;
        // Maximum valid applicant age
        public static readonly byte ApplicantMaxAge = 70;
        // Minimum valid password length
        public static readonly int PasswordMinLength = 3;
        // Maximum valid password length
        public static readonly int PasswordMaxLength = 8;
        /// <summary>Generates random date of birth values within the specified age range./>
        /// <param name="minAge">The minimum age.</param>
        /// <param name="maxAge">The maximum age.</param>
        /// <returns>The DateTime value within specified range.</returns>

        public static readonly char[] CharacterPool = {'~', '!', '@', '#', '$', '%', '^', '&', '*', '(',
            ')', '-', '_', '+', '=', '<', '>', '/', '?', ';', ':', '"', '{', '}', '[', ']' };

        public static readonly string[] SyllablePool = { "Ab", "Saa", "Levo", "Pari", "Rub", "Ask",
            "Mam", "Ket", "Zar", "Luci", "Ter", "Ova", "Sar", "Vol", "Ver" };

        public static readonly string[] MaleNamePool = { "Sevak", "Mher", "Arevshat",
            "Garush", "Karen", "Smbat", "Rouben", "Garegin", "Vahe", "Eduard",
            "Gavril", "Suren", "Arkadij" };

        public static readonly string[] FemaleNamePool = { "Nina", "Karine", "Margarita",
            "Narine", "Nane", "Marina", "Lilit", "Yelena" };
        static readonly string[] LastNamePool = new string[] { "Lalazryan", "Mkhrtchyan",
            "Hakobyan", "Vardanyan", "Lobyan", "Levonyan", "Sahakyan", "Gevorgyan" };

        public static readonly string[] AlphabetVocalLetterPool = new string[] { "a", "e", "i", "o", "u", "y" };

        public static readonly string[] AlphabetConsonantLetterPool = new string[] { "b", "c", "d", "f", "g",
            "h", "j", "k", "l", "m", "n", "p", "q", "r", "s", "t", "v", "w", "x", "z" };


        public static readonly string CountryCode = "+374";
        public static readonly string[] PhoneOperatorCode = { "10", "11", "33", "44", "47", "55", "77", "91", "93", "94", "95", "96", "97", "98", "99" };

        public static readonly char[] LetterPool = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l',
                                           'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

        public static readonly List<string> DomainPool = new List<string>()
            {"@email.ru", "@gmail.com", "@yahoo.com", "@yandex.ru"};
        public static readonly Dictionary<string, string> CityDictionary = new Dictionary<string, string>()
        {
              //Region Ararat
            { "0613", "Noyakert" },
            { "0605", "Avshar" },
            { "0604", "Aygavan" },
            { "0602", "Ararat" },
            { "0624", "Armash" },
            { "0625", "Dashtaqar" },
            { "0608", "Goravan" },
            //Region Aparan 
            { "0301", "Aparan" },
            { "0311", "Quchak" },
            { "0306", "Mravyan" },
            { "0307", "Nigavan" },
            { "0310", "Vardenut" },
            { "0302", "Aragatz" },
            { "0305", "Hartavan" },
            //Region Armavir 
            { "0912", "Amasia" },
            { "0915", "Araqs" },
            { "0914", "Arazap" },
            { "0917", "Arevik" },
            { "0916", "Argavand" },
            { "0919", "Artashar" },
            { "0921", "Berqashat" },
            //Region Gegharquniq 
            { "1403", "Astghadzor" },
            { "1412", "Dzoragyugh" },
            { "1405", "Geghhovit" },
            { "1206", "Gandzak" },
            { "1209", "Ltshap" },
            { "1213", "Noratus" },
            { "1214", "Sarukhan" },
            //Region Kotayq
            { "2201", "Abovyan" },
            { "2208", "Abovyan"},
            { "2209", "Akunq" },
            { "2212", "Arzni" },
            { "2215", "Garni" },
            { "2216", "Geghadir" },
            { "2217", "Geghashen" },
            { "2222", "Kaputan" },
            //Region Lori
            { "1821", "Jrashen" },
            { "1812", "Lusaghbyur" },
            { "1822", "Saralanj" },
            { "1809", "Gogaran" },
            { "1813", "Khnkoyan" },
            { "1811", "Lernavan" },
            { "1825", "Qaradzor" },
            //Region Syuniq 
            { "2613", "Haykavan" },
            { "2614", "Hatsik" },
            { "2615", "Hovuni" },
            { "3505", "Aghitu" },
            { "3507", "Brnakot" },
            { "3510", "Darbas" },
            { "3508", "Gorayq" },
            //Region Shirak
            { "3010", "Gexanist" },
            { "3011", "Getap" },
            { "3014", "Haritsh" },
            { "3015", "Horom" },
            { "3012", "Lernakert" },
            { "3017", "Meghrashen" },
            { "3019", "Nor Kyanq" },
            //Region Tavush
            { "4210", "Norashen" },
            { "4214", "Paravaqar" },
            { "4205", "Tovuz" },
            { "4213", "Choratan" },
            { "4211", "Cinari" },
            { "4208", "Nerqin Karmir Aghbyur" },
            { "4215", "Verin Karmir Aghbyur" },
            //Region Vayoc dzor
            { "3606", "Getap" },
            { "3607", "Gladzor" },
            { "3609", "Hermon" },
            { "3602", "Agarakadzor" },
            { "3604", "Areni" },
            { "3612", "Chiva" },
            { "3614", "Vernashen" },
            //Erevan
            { "0001", "Yerevan" },
            { "0002", "Yerevan" },
            { "0003", "Yerevan" },
            { "0004", "Yerevan" }
        };

        public static readonly Dictionary<string, string> ProvinceDictionary = new Dictionary<string, string>()
        {
            { "03", "Aparan" },
            { "04", "Aragac" },
            { "02", "Ashtarak" },
            { "05", "Talin" },
            { "06", "Ararat" },
            { "07", "Artashat" },
            { "08", "Masis" },
            { "09", "Armavir" },
            { "10", "Baghramyan" },
            { "11", "Vagharshapat" },
            { "12", "Gavar" },
            { "14", "Martuni" },
            { "15", "Sevan" },
            { "13", "Tshambarak" },
            { "16", "Vardenis" },
            { "22", "Abovyan" },
            { "25", "Charencavan" },
            { "23", "Hrazdan" },
            { "24", "Nairi" },
            { "18", "Spitak" },
            { "19", "Stepanavan" },
            { "17", "Tumanyan"},
            { "20", "Vanadzor"},
            { "21", "Vanadzor"},
            { "26", "Akhuryan"},
            { "27", "Amasia" },
            { "29", "Ani" },
            { "30", "Artik" },
            { "31", "Gyumri" },
            { "32", "Gyumri" },
            { "33", "Kapan" },
            { "34", "Meghri" },
            { "35", "Sisian" },
            { "39", "Dilijan" },
            { "40", "Ijevan" },
            { "41", "Noyemberyan" },
            { "42", "Tavush" },
            { "36", "Eghegnadzor" },
            { "37", "Jermuk" },
            { "38", "Vayq" },
            { "00", "Yerevan" }
        };

    }
}
