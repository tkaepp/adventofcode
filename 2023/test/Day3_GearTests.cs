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

        var result = Day3.Calculate_Part2(input);

        Assert.Equal(467835, result);
    }
}