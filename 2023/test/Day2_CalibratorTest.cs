namespace test;

using day1;

public class Day2_CalibratorTest
{
    [Theory]
    [InlineData("two1nine", 29)]
    [InlineData("eightwothree", 83)]
    [InlineData("abcone2threexyz", 13)]
    [InlineData("xtwone3four", 24)]
    [InlineData("4nineeightseven2", 42)]
    [InlineData("zoneight234", 14)]
    [InlineData("7pqrstsixteen", 76)]
    public void Sample_Validation(string input, int expected)
    {
        var result = Calibrator.Day2_ConvertValue(input);

        Assert.Equal(expected, result);
    }
    
    [Theory]
    [InlineData("cmpptgjc3qhcjxcbcqgqkxhrms", 33)]
    public void SpecialCase_Validation(string input, int expected)
    {
        var result = Calibrator.Day2_ConvertValue(input);

        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void Result_Validation()
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

        var result = Day2.Calculate(inputs);

        Assert.Equal(281, result);
    }
}