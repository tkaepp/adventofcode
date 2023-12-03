// See https://aka.ms/new-console-template for more information

using day1;

var resultDay1 = Input_Day1.Day1_ValuesToCalibrate.Select(Day1_Calibrator.Day1_Part1_ConvertValue).Sum();

Console.WriteLine(resultDay1);

Console.WriteLine(Day1.Calculate_Part2(Input_Day1.Day1_ValuesToCalibrate));

