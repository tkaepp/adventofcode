namespace test;

using day1;

public class Day2_PuzzleTests
{
    [Fact]
    public void Result_Part2_Validation()
    {
        string[] inputs = {
            "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
            "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
            "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
            "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
            "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green"
        };

        var result = Day2.Calculate_Part1(inputs);

        Assert.Equal(8, result);
    }

    [Theory]
    [InlineData(1, "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green")]
    [InlineData(2, "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue")]
    [InlineData(3, "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red")]
    [InlineData(40, "Game 40: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red")]
    [InlineData(55, "Game 55: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green")]
    [InlineData(101, "Game 101: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green")]
    public void Validate_GameId_Parsing(int expected, string game)
    {
        Assert.Equal(expected, Day2.GetGameId(game));
    }
    
    [Theory]
    [InlineData(4,0,3, "3 blue, 4 red;")]
    [InlineData(1,3,4, "3 green, 4 blue, 1 red")]
    [InlineData(4,13,5, "5 blue, 4 red, 13 green;")]
    [InlineData(1,2,2, "2 blue, 1 red, 2 green")]
    public void Validate_Parsing(int red, int green, int blue,string game)
    {
        var reveal = Day2.ConvertReveal(game);
        
        Assert.Equal(red, reveal.Red);
        Assert.Equal(green, reveal.Green);
        Assert.Equal(blue, reveal.Blue);
    }
    
    [Theory]
    [InlineData(true, "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green")]
    [InlineData(true, "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue")]
    [InlineData(false, "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red")]
    [InlineData(false, "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red")]
    [InlineData(true, "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green")]
    public void Validate_IsPossible(bool expected, string game)
    {
        Assert.Equal(expected, Day2.ConvertInput(game).IsPossible);
    }
}