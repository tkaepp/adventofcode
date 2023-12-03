// See https://aka.ms/new-console-template for more information

using day1;

var result = Input.List.Select(x => Calibrator.ConvertValue(x)).Sum();

Console.WriteLine(result);