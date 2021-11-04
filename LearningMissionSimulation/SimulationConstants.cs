using System;
using System.Collections.Generic;

namespace LearningMissionSimulation
{
    public class SimulationConstants
    {
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
        public static Random random = new Random();

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
              //Region Aparan 
              { "0301", "Aparan" },
              { "0302", "Aragatz" },
              { "0305", "Hartavan" },
              //Region Armavir 
              { "0912", "Amasia" },
              { "0915", "Araqs" },
              { "0914", "Arazap" },
              //Region Gegharquniq 
              { "1403", "Astghadzor" },
              { "1412", "Dzoragyugh" },
              { "1405", "Geghhovit" },
              //Region Kotayq
              { "2201 - 2208", "Abovyan" },
              { "2209", "Akunq" },
              { "2211", "Aramus" },
              //Region Lori
              { "1821", "Jrashen" },
              { "1812", "Lusaghbyur" },
              { "1822", "Saralanj" },
              //Region Syuniq 
              { "2613", "Haykavan" },
              { "2614", "Hatsik" },
              { "2615", "Hovuni" },
              //Region Shirak
              { "3010", "Gexanist" },
              { "3011", "Getap" },
              { "3014", "Haritsh" },
              //Region Tavush
              { "4210", "Norashen" },
              { "4214", "Paravaqar" },
              { "4205", "Tovuz" },
              //Region Vayoc dzor
              { "3606", "Getap" },
              { "3607", "Gladzor" },
              { "3609", "Hermon" },
              //Erevan
              { "0001", "Yerevan" }
            };

    }
}
