namespace day1;

public class Calibrator
{
    public static int ConvertValue(string input)
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
}