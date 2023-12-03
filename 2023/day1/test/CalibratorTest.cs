namespace test;

using day1;

public class CalibratorTest
{
    [Theory]
    [InlineData("1abc2", 12)]
    [InlineData("pqr3stu8vwx", 38)]
    [InlineData("a1b2c3d4e5f", 15)]
    [InlineData("treb7uchet", 77)]
    public void Sample_Validation(string input, int expected)
    {
        var result = Calibrator.ConvertValue(input);

        Assert.Equal(expected, result);
    }
}