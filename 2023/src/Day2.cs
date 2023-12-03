namespace day1;

public class Day2
{
    public static int Calculate(string[] inputs)
    {
        return inputs.Select(Calibrator.Day2_ConvertValue).Sum();
    }
}