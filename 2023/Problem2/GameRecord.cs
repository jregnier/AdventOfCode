using System.Diagnostics.CodeAnalysis;

namespace Problem2;

internal class GameRecord
{
    public const string BLUE_CUBE = "blue";
    public const string GREEN_CUBE = "green";
    public const string RED_CUBE = "red";

    public int GameNumber { get; set; }

    public List<GameSet> Sets { get; } = [];

    public static List<GameRecord> Parse(string history)
    {
        var recordsList = new List<GameRecord>();

        foreach (var line in history.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries))
        {
            var gamePart = line.Split(":");
            var gameNumber = int.Parse(gamePart[0].Split(" ")[1]);

            var record = new GameRecord
            {
                GameNumber = gameNumber,
            };

            foreach (var set in gamePart[1].Split(";", StringSplitOptions.RemoveEmptyEntries))
            {
                var gameSet = new GameSet();

                foreach (var cubeTypeParts in set.Split(",", StringSplitOptions.RemoveEmptyEntries))
                {
                    var cubeParts = cubeTypeParts.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    if (cubeParts[1] == RED_CUBE)
                    {
                        gameSet.RedNum = int.Parse(cubeParts[0]);
                    }
                    else if (cubeParts[1] == GREEN_CUBE)
                    {
                        gameSet.GreenNum = int.Parse(cubeParts[0]);
                    }
                    else if (cubeParts[1] == BLUE_CUBE)
                    {
                        gameSet.BlueNum = int.Parse(cubeParts[0]);
                    }
                }

                record.Sets.Add(gameSet);
            }

            recordsList.Add(record);
        }

        return recordsList;
    }

    public bool IsValid(int red, int green, int blue) =>
        Sets.All(set =>
            set.RedNum <= red
            && set.GreenNum <= green
            && set.BlueNum <= blue);

    public int GetPower() =>
        Sets.Max(x => x.RedNum)
        * Sets.Max(x => x.GreenNum)
        * Sets.Max(x => x.BlueNum);
}