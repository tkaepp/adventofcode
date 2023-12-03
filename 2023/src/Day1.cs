namespace day1;

public class Day1
{
    public static int Calculate_Part1(string[] inputs)
    {
        return inputs.Select(Day1_Calibrator.Day1_Part1_ConvertValue).Sum();
    }
    
    public static int Calculate_Part2(string[] inputs)
    {
        return inputs.Select(Day1_Calibrator.Day1_Part2_ConvertValue).Sum();
    }
}