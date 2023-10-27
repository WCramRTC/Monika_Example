# Monika_Example

## Breakdown
Hi Monika,

Here's a breakdown of how I might approach validations for your code. I kept your logic the same, I just wrapped everything in a couple of if statements to check for string length and if it was a letter ( full explination below ).

I also converted some things early and fleshed out our reponse depending on how many players were found.

I hope this helps answer your question regarding validating Option 3. If not, let me know and I'll be happy to try again!

Thanks again for all your hard work.

### Validations

1. ***Did the user enter a single character?***  
We only want the user to pass us a single character. Checking the length of the string array is 1 verifies it's not an empty string, or a word with 2+ letters
```csharp
    public static bool IsSingleCharacter(string userString)
    {
        return userString.Length == 1;
    } // IsSingleCharacter
```

This allowed us our first specific validation, please enter a SINGLE character.

```csharp

    Console.Write($"Enter the letter: ");
    string enter = Console.ReadLine();
    bool isASingleCharacter = IsSingleCharacter(enter);

   if(isASingleCharacter) { run code }
    else 
    {
        Console.WriteLine("Please enter a SINGLE character");
    }
```
---
2. ***Is it a valid character?***  
Our next check is if the user entered a letter, not a number or symbol. If we recall, characters are recognized by the computer as numbers in ascii. So we find the range of a to z in ascii, 97 to 122, and see that the users letter falls inbetween this range.

[Reference for ASCII Chart](https://www.rapidtables.com/code/text/ascii-table.html)
```csharp

    public static bool IsALetter(char character)
    {
        return character >= 97 && character <= 122;
    } // IsALetter
```

| Letter | ASCII Value | Letter | ASCII Value | Letter | ASCII Value | Letter | ASCII Value |
|--------|-------------|--------|-------------|--------|-------------|--------|-------------|
| a      | 97          | g      | 103         | m      | 109         | s      | 115         |
| b      | 98          | h      | 104         | n      | 110         | t      | 116         |
| c      | 99          | i      | 105         | o      | 111         | u      | 117         |
| d      | 100         | j      | 106         | p      | 112         | v      | 118         |
| e      | 101         | k      | 107         | q      | 113         | w      | 119         |
| f      | 102         | l      | 108         | r      | 114         | x      | 120         |
|        |             |        |             |        |             | y      | 121         |
|        |             |        |             |        |             | z      | 122         |

This lead to our second specific validation

```csharp
    char letter = enter.ToLower()[0];
    bool isALetter = IsALetter(letter);

   if(isALetter) { run code }
    else 
    {
        Console.WriteLine("Please enter a single LETTER");
    }
```
---
### Conversions

I converted the users string to a char on line 36 to help validate it was an actual letter.

```csharp
    char letter = enter.ToLower()[0];
```

And since I already had this single lower case character, I did the same thing to the players first letter too.

```csharp
    char firstLetter = players[i].ToLower()[0];
```

By doing this I now has two lower case chacters, ensuring it was not case sensitive. And my condition was straight forward.

```csharp
    if(letter == firstLetter) { display the name }
```
---
### Keeping Counts
And finally we wanted to display to the user if we didn't find any players that started with that first letter. I went simple with this, I just created a count variable. Every it found a player, it incremented.

```csharp
    if (firstLetter == letter)
    {
        Console.WriteLine(players[i]);
        count++; // Increase if player found
    }
```

And to customize it a little, we did an decision structure that displayed if there were 0, 1 ( for singular Player ), or more ( for plural Players ).

```csharp
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

```

---
### Final Code - Short Notes ( Full Notes in Program.cs )

```csharp
    public static void DisplayFirstLetterOfName(List<string> players)
    {
        Console.Write($"Enter the letter: ");
        string enter = Console.ReadLine();

        bool isASingleCharacter = IsSingleCharacter(enter);

        if(isASingleCharacter) // Validate Length
        {
            char letter = enter.ToLower()[0]; // Conver to lower
            bool isALetter = IsALetter(letter);

            if(isALetter) // Validate Letter
            {
                int count = 0;

                for (int i = 0; i < players.Count; i++)
                {

                    char firstLetter = players[i].ToLower()[0]; // Convert to lower

                    if (firstLetter == letter)
                    {
                        Console.WriteLine(players[i]);
                        count++; 
                    }
                }
                // ----------------------------------
                   
                if(count == 0) // No Players Found
                {
                    Console.WriteLine($"No Players who start with the letter {letter} were found ");
                }
                else if (count == 1) // 1 Found
                {
                    Console.WriteLine($"1 Player with the letter of {letter} found ");
                }
                else // Multiple Found
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
```