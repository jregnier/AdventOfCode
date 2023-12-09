using Problem6;

const string INPUT_EXAMPLE = @"
Time:      7  15   30
Distance:  9  40  200";

const string INPUT = @"
Time:        58     81     96     76
Distance:   434   1041   2219   1218";

Console.WriteLine("PART 1!!");

var raceTime1 = RaceTimes.ParsePart1(INPUT);

Console.WriteLine($"Margin of Error: {raceTime1.GetMarginOfErrorPart1()}");

Console.WriteLine();
Console.WriteLine("PART 2!!");

var raceTime2 = RaceTimes.ParsePart2(INPUT);
Console.WriteLine($"Margin of Error: {raceTime2.GetMarginOfErrorPart2()}");

