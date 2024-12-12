namespace Day6;

internal class GuardLocatorMap
{
    public const char CURRENT_LOCATION_DOWN = 'v';
    public const char CURRENT_LOCATION_LEFT = '<';
    public const char CURRENT_LOCATION_RIGHT = '>';
    public const char CURRENT_LOCATION_UP = '^';
    public const char PATH_INTERSECTION = '+';
    public const char PATH_LEFTRIGHT = '-';
    public const char PATH_UPDOWN = '|';

    public List<List<MapLocation>> Map { get; init; } = [];

    public MapLocation StartingLocation { get; init; } = new MapLocation(0, 0, CURRENT_LOCATION_UP);

    public static GuardLocatorMap Parse(string content)
    {
        var map = AocUtilities.InputReader.GetMapAsList(content);

        var locationsMaps = new List<List<MapLocation>>();
        var startingLocation = new MapLocation(0, 0, CURRENT_LOCATION_UP);

        for (var row = 0; row < map.Count; row++)
        {
            var rowList = new List<MapLocation>();
            for (var col = 0; col < map[row].Count; col++)
            {
                var location = new MapLocation(row, col, map[row][col]);
                if (location.Value == CURRENT_LOCATION_UP)
                {
                    startingLocation = location;
                }

                rowList.Add(location);
            }

            locationsMaps.Add(rowList);
        }

        return new GuardLocatorMap
        {
            Map = locationsMaps,
            StartingLocation = startingLocation
        };
    }

    public long Solve1()
    {
        var result = new HashSet<MapLocation>();

        var row = StartingLocation.Row;
        var col = StartingLocation.Col;
        var currentDirection = CURRENT_LOCATION_UP;

        while (true)
        {
            var nextRow = row;
            var nextCol = col;

            if (currentDirection == CURRENT_LOCATION_UP)
            {
                nextRow = row - 1;
            }
            else if (currentDirection == CURRENT_LOCATION_DOWN)
            {
                nextRow = row + 1;
            }
            else if (currentDirection == CURRENT_LOCATION_LEFT)
            {
                nextCol = col - 1;
            }
            else if (currentDirection == CURRENT_LOCATION_RIGHT)
            {
                nextCol = col + 1;
            }

            if (IsOutOfBounds(nextRow, nextCol))
            {
                break;
            }

            if (Map[nextRow][nextCol].IsObstruction)
            {
                currentDirection = ChangeDirection(currentDirection);
            }
            else
            {
                result.Add(Map[nextRow][nextCol]);
                row = nextRow;
                col = nextCol;
            }
        }

        return result.Count;
    }

    public long Solve2()
    {
        var optionsCount = 0;

        for (var r = 0; r < Map.Count; r++)
        {
            for (var c = 0; c < Map[r].Count; c++)
            {
                var location = Map[r][c];
                if (location.Value != '.')
                {
                    continue;
                }

                location.Value = MapLocation.OBSTRUCTION_LOCATION;

                var route = new HashSet<RouteItem>();

                var row = StartingLocation.Row;
                var col = StartingLocation.Col;
                var currentDirection = CURRENT_LOCATION_UP;

                while (true)
                {
                    var nextRow = row;
                    var nextCol = col;
                    var pathValue = ' ';

                    if (currentDirection == CURRENT_LOCATION_UP)
                    {
                        nextRow = row - 1;
                        pathValue = PATH_UPDOWN;
                    }
                    else if (currentDirection == CURRENT_LOCATION_DOWN)
                    {
                        nextRow = row + 1;
                        pathValue = PATH_UPDOWN;
                    }
                    else if (currentDirection == CURRENT_LOCATION_LEFT)
                    {
                        nextCol = col - 1;
                        pathValue = PATH_LEFTRIGHT;
                    }
                    else if (currentDirection == CURRENT_LOCATION_RIGHT)
                    {
                        nextCol = col + 1;
                        pathValue = PATH_LEFTRIGHT;
                    }

                    if (IsOutOfBounds(nextRow, nextCol))
                    {
                        break;
                    }

                    if (Map[nextRow][nextCol].IsObstruction)
                    {
                        currentDirection = ChangeDirection(currentDirection);
                        pathValue = PATH_INTERSECTION;
                    }
                    else
                    {
                        row = nextRow;
                        col = nextCol;

                        var routeItem = new RouteItem(row, col, pathValue, currentDirection);
                        if (route.Contains(routeItem))
                        {
                            optionsCount++;
                            break;
                        }

                        route.Add(new RouteItem(row, col, pathValue, currentDirection));
                    }
                }

                location.Value = '.';
            }
        }

        return optionsCount;
    }

    private static char ChangeDirection(char currentDirection) =>
        currentDirection switch
        {
            CURRENT_LOCATION_UP => CURRENT_LOCATION_RIGHT,
            CURRENT_LOCATION_RIGHT => CURRENT_LOCATION_DOWN,
            CURRENT_LOCATION_DOWN => CURRENT_LOCATION_LEFT,
            CURRENT_LOCATION_LEFT => CURRENT_LOCATION_UP,
            _ => throw new Exception("Invalid direction")
        };

    private bool IsOutOfBounds(int row, int col)
    {
        return row < 0
            || col < 0
            || row >= Map.Count
            || col >= Map[0].Count;
    }
}