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