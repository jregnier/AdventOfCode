using AocUtilities;

using Problem10;

const string INPUT_EXAMPLE = @"
.....
.S-7.
.|.|.
.L-J.
.....";

Runner.RunCodeWithTimer(1, () =>
{
    var schematic = PipeSchematic.Parse(INPUT_EXAMPLE);
    var steps = schematic.FindNumberOfSteps();

    Console.WriteLine($"Number of Steps {steps}");
});