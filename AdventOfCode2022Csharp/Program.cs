// See https://aka.ms/new-console-template for more information
class Solution
{
    public static void Main(string[] args)
    {
        //Day1();
        //Day2();
        Day3();
    }

    public static void Day1()
    {
        //open file
        StreamReader sr = new StreamReader("../../../day1.txt");

        //read entire whole file - im sure this is efficient 
        string wholefile = sr.ReadToEnd();

        //close file
        sr.Close();

        //split at empty lines
        string[] sections = wholefile.Split("\n\n");

        //create three longs for the three top calories
        long highest = 0;
        long secondHighest = 0;
        long thirdHighest = 0;

        //iterate through all 'elves'
        for (int i = 0;  i < sections.Length; i++)
        {
            //each number is separated by newline
            string[] nums = sections[i].Split("\n");
            long total = 0;

            //iterate through each value the elf has
            for (int j = 0; j < nums.Length; j++)
            {
                //using TryParse so that no stray newlines slip through
                long value;
                if (long.TryParse(nums[j].Trim(), out value))
                {
                    total += value;
                }
            }

            //if the total is more than the lowest
            if (total > thirdHighest)
            {
                //as well as the second highest
                if (total > secondHighest)
                {
                    //as well as the highest
                    if (total > highest)
                    {
                        //shift the highests downward by one, and set the highest to the total
                        thirdHighest = secondHighest;
                        secondHighest = highest;
                        highest = total;
                    }
                    else
                    {
                        //shift only the two lowest downward, and set the second highest to the total
                        thirdHighest = secondHighest;
                        secondHighest = total;
                    }
                }
                else
                {
                    //only higher than third highest, all that needs to be done is to set the third highest
                    thirdHighest = total;
                }
            }
        }

        Console.WriteLine(highest);
        Console.WriteLine(secondHighest); 
        Console.WriteLine(thirdHighest);
        Console.WriteLine("\n"+(highest+secondHighest+thirdHighest));
    }

    public static void Day2()
    {
        //open file
        StreamReader sr = new StreamReader("../../../day2.txt");

        //create dictionary / hashmap based off of strategy guide 
        // A/X = rock (1 point), B/Y = paper (2 points), C/Z = scissors (3 points)
        // ABC = opponent, XYZ = you/me?
        // Win = 6 points, Draw = 3 points, Loss = 0 points
        Dictionary<string, int> strategyGuide = new Dictionary<string, int>()
        {
            { "A X", 4 },
            { "B X", 1 },
            { "C X", 7 },
            { "A Y", 8 },
            { "B Y", 5 },
            { "C Y", 2 },
            { "A Z", 3 },
            { "B Z", 9 },
            { "C Z", 6 }
        };

        //X = we/i lose, Y = draw, Z = win
        //otherwise, same as before
        Dictionary<string, int> strategyGuide2 = new Dictionary<string, int>()
        {
            { "A X", 3 },
            { "B X", 1 },
            { "C X", 2 },
            { "A Y", 4 },
            { "B Y", 5 },
            { "C Y", 6 },
            { "A Z", 8 },
            { "B Z", 9 },
            { "C Z", 7 }
        };

        //create total to record while iterating through each line
        long total = 0;
        //creating new total to store updated strategy guide score
        long newTotal = 0;

        //iterate through each line - cant do entire file, just not efficient sorry
        while (!sr.EndOfStream)
        {
            string fight = sr.ReadLine().Trim();
            if (strategyGuide.ContainsKey(fight))
            {
                total += strategyGuide[fight];
            }
            if (strategyGuide2.ContainsKey(fight))
            {
                newTotal += strategyGuide2[fight];
            }

        }

        //close file
        sr.Close();

        //output
        Console.WriteLine(total);
        Console.WriteLine(newTotal);

        //looking back, this is MUCH better than my c++ soln - the hell was i thinking
        
    }

    public static void Day3()
    {
        //open file
        StreamReader sr = new StreamReader("../../../day3.txt");

        //create total incrementer
        int total = 0;

        //incr that goes to 3 (0,1,2) and resets for triplets


        while (!sr.EndOfStream)
        {
            string line = sr.ReadLine();

            //create two sets for the first half and second half
            HashSet<char> secondHalf = line.Substring(line.Length / 2).ToHashSet();
            HashSet<char> firstHalf = line.Substring(0, line.Length / 2).ToHashSet();
            
            //compare elements to see which element is present in both
            foreach (char c in firstHalf)
            {
                //means common element in both
                if (secondHalf.Contains(c))
                {
                    //check if it's upper or lowercase
                    //if upper, subtract 'A', if lower, subtract 'a'
                    if (c.ToString().ToLower() == c.ToString())
                    {
                        //to get the 'priority' where 'a' = 1, 'z' = 26
                        total += c - 'a' + 1;
                    }
                    //char is uppercase
                    else
                    {
                        //to get the 'priority' where 'A' = 27, 'Z' = 52 
                        total += c - 'A' + 27;
                    }
                    break;
                }
            }
            Console.WriteLine();
        }
    }
}
