using System.Text.RegularExpressions;

namespace day1;

public class Day2
{
    public record GameRecord(int GameId, bool IsPossible);

    public record Reveal(int Red, int Green, int Blue);

    public static int Calculate_Part1(string[] inputs)
    {
        var games = inputs.Select(ConvertInput).Where(game => game.IsPossible).ToList();
        
        return games.Sum(x => x.GameId);
    }

    public static Reveal ConvertReveal(string input)
    {
        var red = new Regex(@"(\d+) red").Match(input);
        var green = new Regex(@"(\d+) green").Match(input);
        var blue = new Regex(@"(\d+) blue").Match(input);

        return new Reveal(
            red.Success ? Convert.ToInt32(red.Groups[1].ToString()) : 0,
            green.Success ? Convert.ToInt32(green.Groups[1].ToString()) : 0,
            blue.Success ? Convert.ToInt32(blue.Groups[1].ToString()) : 0
        );
    }

    public static bool IsGamePossible(Reveal[] reveals)
    {
        return reveals.Any(r => r.Red > 12 || r.Green > 13 || r.Blue > 14) == false;
    }

    public static GameRecord ConvertInput(string input)
    {
        /*
         * Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
           Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
           Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
           Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
           Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green
         */

        var gameId = GetGameId(input);

        var colonIndex = input.IndexOf(":", StringComparison.Ordinal);

        var revealStrings = input.Substring(colonIndex + 2, input.Length - 2 - colonIndex);
        
        var cubeReveals = revealStrings
            .Split(";")
            .Select(ConvertReveal)
            .ToArray();
        
        Console.Write($"game: {gameId} ");
        return new GameRecord(gameId, IsGamePossible(cubeReveals));
    }

    public static int GetGameId(string input)
    {
        var gameIdRegex = new Regex(@"Game\s(\d+)");
        return Convert.ToInt32(gameIdRegex.Match(input).Groups[1].ToString());
    }
}