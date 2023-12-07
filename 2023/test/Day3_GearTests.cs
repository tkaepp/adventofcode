namespace test;

using day1;

public class Day3_GearTests
{
    [Fact]
    public void Result_Part2_Validation()
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