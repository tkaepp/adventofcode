using System.Text.RegularExpressions;

namespace day1;

public class Calibrator
{
    public static int Day1_ConvertValue(string input)
    {
        var twoDigits = new int[2];
        var currentDigit = 0;

        foreach (var character in input)
        {
            if (char.IsNumber(character))
            {
                twoDigits[currentDigit] = int.Parse(character.ToString());

                if (currentDigit == 0)
                {
                    currentDigit++;
                }
            }
        }

        var firstDigit = twoDigits[0];
        var secondDigit = twoDigits[1];
        if (secondDigit == 0)
        {
            secondDigit = firstDigit;
        }

        var result = 10 * firstDigit + secondDigit;


        return result;
    }


    private static Dictionary<string, int> digitsByWord = new Dictionary<string, int>()
    {
        { "one", 1 },
        { "two", 2 },
        { "three", 3 },
        { "four", 4 },
        { "five", 5 },
        { "six", 6 },
        { "seven", 7 },
        { "eight", 8 },
        { "nine", 9 }
    };


    public static int ConvertGroup(string input)
    {
        if (digitsByWord.TryGetValue(input, out var digit))
        {
            return digit;
        }
        
        return int.Parse(input);
    }

    public static int Day2_ConvertValue(string input)
    {
        var regex = new Regex(
            "((?:[0-9])|(?:one)|(?:two)|(?:three)|(?:four)|(?:five)|(?:six)|(?:seven)|(?:eight)|(?:nine)).*((?:[0-9])|(?:one)|(?:two)|(?:three)|(?:four)|(?:five)|(?:six)|(?:seven)|(?:eight)|(?:nine))");

        var regexResult = regex.Match(input);

        if (regexResult.Success == false)
        {
            return Day1_ConvertValue(input);
        }
        
        var firstDigit = ConvertGroup(regexResult.Groups[1].ToString());
        int secondDigit;
        if (regexResult.Groups.Count == 1)
        {
            secondDigit = firstDigit;
        }
        else
        {
            secondDigit = ConvertGroup(regexResult.Groups[2].ToString());
        }

        var result = 10 * firstDigit + secondDigit;


        return result;
    }
}