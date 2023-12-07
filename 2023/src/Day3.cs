using System.Text.RegularExpressions;

namespace day1;

public class Day3
{
    enum CharType
    {
        Number,
        Special,
        EOL
    }

    public record Vector(int X, int Y, int Length, int Value);

    public record struct Symbol(int X, int Y);

    public static int Calculate_Part1(string input)
    {
        var partNumbers = new HashSet<int>();
        int sum = 0;
        var (vectors, symbols) = Parse(input);

        var maxDistance = Math.Sqrt(Math.Pow(0 - 1, 2) + Math.Pow(0 - 1, 2));
        
        foreach (var vector in vectors)
        {
            foreach (var symbol in symbols)
            {
                /*
                 * Learn how to find the distance between two points by using the distance formula, which is an application of the Pythagorean theorem. We can rewrite the Pythagorean theorem as d=√((x_2-x_1)²+(y_2-y_1)²) to find the distance between any two points.
                 */
                var distanceStart = Math.Sqrt(Math.Pow(vector.X + vector.Length - 1 - symbol.X, 2) + Math.Pow(vector.Y - symbol.Y, 2));
                var distanceEnd = Math.Sqrt(Math.Pow(vector.X - symbol.X, 2) + Math.Pow(vector.Y - symbol.Y, 2));
                
                if ((distanceStart <= maxDistance) || (distanceEnd <= maxDistance)) // max diagonal
                {
                    partNumbers.Add(vector.Value);
                    sum += vector.Value;
                    break;
                }
            }
        }
        
        return sum;
    }

    public static (List<Vector> vectors, HashSet<Symbol> symbols) Parse(string input)
    {
        var vectors = new List<Vector>();
        var symbols = new HashSet<Symbol>();

        char[] numbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        char[] specialChars = { '*', '/', '=', '+', '%', '@', '#', '&', '-', '$' };

        // convert string into 2D-Array
        var split = input.Split(Environment.NewLine);
        for (var y = 0; y < split.Length; y++)
        {
            var line = split[y];
            for (int x = 0; x < line.Length - 1; x++)
            {
                var index = (number: line.IndexOfAny(numbers, x), special: line.IndexOfAny(specialChars, x));

                var (pos, chartype, to) = index switch
                {
                    (-1, -1) => (-1, CharType.EOL, -1),
                    (-1, var special) => (special, CharType.Special, special),
                    (var number, -1) => (number, CharType.Number, GetNumberLength(number, line)),
                    (var number, 0) => (number, CharType.Number, GetNumberLength(number, line)),
                    var (number, special) when number < special => (number, CharType.Number, GetNumberLength(number, line)),
                    var (number, special) when number > special => (special, CharType.Special, special),
                    (_, _) => throw new Exception("should not be possible??")
                };

                switch (chartype)
                {
                    case CharType.Number:
                        vectors.Add(new(pos, y, to - pos, Convert.ToInt32(line[pos..to])));
                        x = to - 1;
                        break;
                    case CharType.Special:
                        symbols.Add(new(to, y));
                        x = to;
                        break;
                    case CharType.EOL:
                        x = line.Length; // end for
                        break;
                }
            }
        }

        return (vectors, symbols);
    }

    private static int GetNumberLength(int index, string line)
    {
        while (index < line.Length && char.IsNumber(line[index]))
        {
            index++;
        }

        return index;
    }

    public static int Calculate_Part2(string input)
    {
        return 0;
    }
}