namespace test;

using day1;

public class Day3_PuzzleTests
{
    [Fact]
    public void Result_Part1_Validation()
    {
        var input = @"467..114..
...*......
..35..633.
......#...
617*......
.....+.58.
..592.....
......755.
...$.*....
.664.598..";

        var result = Day3.Calculate_Part1(input);

        Assert.Equal(4361, result);
    }
    
    [Fact]
    public void Validate_FalsePositive_Part1_Validation()
    {
        var input = @"....509.....=...........890...................&........9................./..847.154..568............@...102................280...*..........
.....*..950.67.............-......161.......530....=...................=............*...../..............@.......................426........";

        var result = Day3.Calculate_Part1(input);

        Assert.Equal(509+67+890+530+568+102+426, result);
    }
    
    [Fact]
    public void Validate_FalsePositiveParsing_Part1_Validation()
    {
        var input = @"
....509.....=...........890...................&........9................./..847.154..568............@...102................280...*..........
.....*..950.67.............-......161.......530....=...................=............*...../..............@.......................426........";

        var (vectors, symbols) = Day3.Parse(input);
        
        Assert.Equal(12, symbols.First().X);
        Assert.Equal(1, symbols.First().Y);
        
        // Assert.Equal(509+67+890+530+568+102+426, result);
    }
    
    [Fact]
    public void Parse_Part1_Validation()
    {
        var input = @"467..114..
...*......
..35..633.
......#...
617*......
.....+.58.
..592.....
......755.
...$.*....
.664.598..";

        var (vectors, symbols) = Day3.Parse(input);
        
        Assert.Equal(10, vectors.Count);
        Assert.Equal(6, symbols.Count);
    }
}