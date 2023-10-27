using System.Diagnostics.Metrics;
using System.Numerics;

namespace Monika_Example
{
    internal class Program
    {

        static List<string> firstNames = new List<string>
        {
            "Emma", "Liam", "Olivia", "Noah", "Ava", "Isabella", "Sophia", "Jackson",
            "Mia", "Aiden", "Lucas", "Amelia", "Harper", "Ethan", "Evelyn", "Madison",
            "Luna", "Oliver", "Isaiah", "Scarlett", "Victoria", "Mason", "Mila", "Charlotte",
            "James", "Avery", "Benjamin", "Chloe", "Aria", "Liam"
        };


        static void Main(string[] args)
        {
            DisplayFirstLetterOfName(firstNames);
        }

        // Converted to List<string> just for ease of example
        public static void DisplayFirstLetterOfName(List<string> players)
        {
            Console.Write($"Enter the letter: ");
            string enter = Console.ReadLine();

            // Validations
            // Check Validation Method Below
            bool isASingleCharacter = IsSingleCharacter(enter);

            // First Validation ( Run only if it's a single character )
            if(isASingleCharacter)
            {
                // Convert the string to a lower case char
                char letter = enter.ToLower()[0];
                // Validation Method Below
                bool isALetter = IsALetter(letter);

                // Second Validation ( Run if a single letter )
                if(isALetter)
                {
                    // Using this to check if any players were found
                    int count = 0;

                    for (int i = 0; i < players.Count; i++)
                    {
                        // Converting it to lower case, just like line 36
                        char firstLetter = players[i].ToLower()[0];

                        // We've converted both the users letter and the players first letter to lower case. This allows us to compare the 2 without worrying about case
                        if (firstLetter == letter)
                        {
                            Console.WriteLine(players[i]);
                            count++; // Increase if player found
                        }
                    }
                    // ----------------------------------
                    // Displays if 0, 1, or multiple people were found
                    if(count == 0)
                    {
                        Console.WriteLine($"No Players who start with the letter {letter} were found ");
                    }
                    else if (count == 1)
                    {
                        Console.WriteLine($"1 Player with the letter of {letter} found ");
                    }
                    else
                    {
                        Console.WriteLine($"{count} Players with the letter of {letter} found");
                    }

                }
                else
                {
                    Console.WriteLine("Please enter a single LETTER");
                }
            } 
            else
            {
                Console.WriteLine("Please enter a SINGLE character");
            }


        } // 

        public static bool IsSingleCharacter(string userString)
        {
            // Since the string is an array, we use the length to check that they user didn't enter a blank string ( count of 0 ) or more than 1 character
            return userString.Length == 1;
        } // IsSingleCharacter

        public static bool IsALetter(char character)
        {
            // In Ascii, a thru z is 97 thru 122.
            // Check that the char is in this range, we can ensure it's a letter and not a number or symbol
            // I used this table for reference
            // https://www.rapidtables.com/code/text/ascii-table.html
            return character >= 97 && character <= 122;
        } // IsALetter

        // Original 
        //public static void DisplayFirstLetterOfName(List<Player> players)
        //{
        //    Console.Write($"Enter the letter: ");
        //    string enter = Console.ReadLine();
        //    int i;

        //    for (i = 0; i < players.Count; i++)
        //    {
        //        string playerName = players[i].Name[0].ToString();
        //        if (enter == playerName || enter == playerName.ToLower())
        //        {
        //            Console.WriteLine(players[i]);

        //        }
        //        else
        //        {
        //            playerName = FirstLetter;

        //        }

        //    }

        //    if (FirstLetter == enter)
        //    {
        //        Console.WriteLine($"No Player's Name starts with {enter}");
        //    }

        //}
    }
}