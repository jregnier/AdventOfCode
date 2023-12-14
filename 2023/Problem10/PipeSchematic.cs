using System.Reflection.Metadata;

using MathNet.Spatial.Euclidean;

namespace Problem10;

internal class PipeSchematic
{
    public Pipe[,] Map { get; init; } = new Pipe[0, 0];

    public Pipe? Start { get; init; }

    public long SolvePart1() => GetPath().Count / 2;

    private List<Pipe> GetPath()
    {
        if (Start == null)
        {
            return [];
        }

        var seenList = new HashSet<Pipe>
        {
            Start,
        };

        var pipeQueue = new Queue<Pipe>();
        pipeQueue.Enqueue(Start);

        while (pipeQueue.Count > 0)
        {
            var pipe = pipeQueue.Dequeue();

            GetPossiblePipes(pipe)
                .Where(pipe => !seenList.Contains(pipe))
                .ToList()
                .ForEach(pipe =>
                {
                    seenList.Add(pipe);
                    pipeQueue.Enqueue(pipe);
                });
        }

        return [.. seenList];
    }

    public long SolvePart2()
    {
        // I need to make the path in sequence since it's using the flood approach.
        var paths = GetPath();
        var pathHashSet = paths.ToHashSet();
        var evens = paths.Where((_, i) => i % 2 == 0);
        var odds = paths.Where((_, i) => i % 2 != 0);

        var orderedPath = evens.Union(odds.Reverse());
        var corners = orderedPath
            .Where(pipe => "SLJ7F".Contains(pipe.Symbol))
            .ToList();

        var points = corners.ConvertAll(pipe => new Point2D(pipe.X, pipe.Y));
        var polygon = new Polygon2D(points);

        var counter = 0;

        foreach (var pipe in Map.Cast<Pipe>().ToList())
        {
            var point = new Point2D(pipe.X, pipe.Y);
            if (!pathHashSet.Contains(pipe)
                && polygon.EnclosesPoint(point))
            {
                counter++;
            }
        }

        return counter;
    }

    private List<Pipe> GetPossiblePipes(Pipe pipe)
    {
        var result = new List<Pipe>();

        if (pipe.Y > 0
            && pipe.CanUp)
        {
            var above = Map[pipe.X, pipe.Y - 1];
            if (above.CanDown && !above.IsStart)
            {
                result.Add(above);
            }
        }

        if (pipe.Y < Map.GetLength(1) - 1
            && pipe.CanDown)
        {
            var below = Map[pipe.X, pipe.Y + 1];
            if (below.CanUp && !below.IsStart)
            {
                result.Add(below);
            }
        }

        if (pipe.X > 0
            && pipe.CanLeft)
        {
            var left = Map[pipe.X - 1, pipe.Y];
            if (left.CanRight && !left.IsStart)
            {
                result.Add(left);
            }
        }

        if (pipe.X < Map.GetLength(0) - 1
            && pipe.CanRight)
        {
            var right = Map[pipe.X + 1, pipe.Y];
            if (right.CanLeft && !right.IsStart)
            {
                result.Add(right);
            }
        }

        return result;
    }

    public static PipeSchematic Parse(string input)
    {
        var inputLines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).ToList();

        var map = new Pipe[inputLines[0].Length, inputLines.Count];

        Pipe? startPipe = null;

        foreach (var line in inputLines.Select((x, i) => new { Line = x, Index = i }))
        {
            foreach (var column in line.Line
                .ToCharArray()
                .Select((x, i) => new { Symbol = x, Index = i }))
            {
                var pipe = new Pipe
                {
                    X = column.Index,
                    Y = line.Index,
                    Symbol = column.Symbol,
                };

                if (pipe.IsStart)
                {
                    startPipe = pipe;
                }

                map[column.Index, line.Index] = pipe;
            }
        }

        return new PipeSchematic
        {
            Map = map,
            Start = startPipe,
        };
    }
}
