// See https://aka.ms/new-console-template for more information

using day1;

var resultDay1 = Input.ValuesToCalibrate.Select(Calibrator.Day1_ConvertValue).Sum();

Console.WriteLine(resultDay1);

Console.WriteLine(Day2.Calculate(Input.ValuesToCalibrate));

