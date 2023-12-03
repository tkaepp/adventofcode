namespace test;

using day1;

public class Day1_CalibratorTest
{
    [Theory]
    [InlineData("1abc2", 12)]
    [InlineData("pqr3stu8vwx", 38)]
    [InlineData("a1b2c3d4e5f", 15)]
    [InlineData("treb7uchet", 77)]
    public void Sample_Part1_Validation(string input, int expected)
    {
        var result = Day1_Calibrator.Day1_Part1_ConvertValue(input);

        Assert.Equal(expected, result);
    }
    
    [Theory]
    [InlineData("two1nine", 29)]
    [InlineData("eightwothree", 83)]
    [InlineData("abcone2threexyz", 13)]
    [InlineData("xtwone3four", 24)]
    [InlineData("4nineeightseven2", 42)]
    [InlineData("zoneight234", 14)]
    [InlineData("7pqrstsixteen", 76)]
    public void Sample_Part2_Validation(string input, int expected)
    {
        var result = Day1_Calibrator.Day1_Part2_ConvertValue(input);

        Assert.Equal(expected, result);
    }
    
    [Theory]
    [InlineData("cmpptgjc3qhcjxcbcqgqkxhrms", 33)]
    public void SpecialCase_Part2_Validation(string input, int expected)
    {
        var result = Day1_Calibrator.Day1_Part2_ConvertValue(input);

        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void Result_Part2_Validation()
    {
        string[] inputs = {
            "two1nine",
            "eightwothree",
            "abcone2threexyz",
            "xtwone3four",
            "4nineeightseven2",
            "zoneight234",
            "7pqrstsixteen"
        };

        var result = Day1.Calculate_Part2(inputs);

        Assert.Equal(281, result);
    }
}