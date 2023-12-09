using System.Collections.Concurrent;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Xml.Linq;

using MathNet.Numerics;

namespace Problem8;

internal class LeftRightInstructions
{
    internal static readonly string[] _separator = [" ", "=", "(", ",", ")"];

    public InstructionType[] InstructionTypeSequence { get; set; } = [];

    public Node[] StartingNodes { get; set; } = [];

    public Dictionary<string, Node> Nodes { get; set; } = [];

    public Task<long> CalculateStepsPart1() =>
        GetPathCount("AAA", node => node.Name.Equals("ZZZ"));

    private Task<long> GetPathCount(string nodeName, Func<Node, bool> zPattern)
    {
        return Task.Run(() =>
        {
            Node? zNode = null;

            var currentNode = nodeName;
            var currentDirectionIndex = 0;
            long counter = 0;

            while (zNode == null)
            {
                var node = Nodes[currentNode];

                if (zPattern(node))
                {
                    zNode = node;
                }
                else
                {
                    counter++;
                }

                currentNode =
                    InstructionTypeSequence[currentDirectionIndex] == InstructionType.L
                    ? node.Left
                    : node.Right;

                currentDirectionIndex = NextDirection(currentDirectionIndex);
            }

            return counter;
        });
    }

    public async Task<long> CalculateStepsPart2WithPath()
    {
        var allZPathCounts = await Task.WhenAll(
            StartingNodes.Select(node => GetPathCount(node.Name, node => node.Name.EndsWith("Z"))));

        return Euclid.LeastCommonMultiple(allZPathCounts);
    }

    public async Task<long> CalculateStepsPart2BruteForce()
    {
        bool foundTheEnd = false;
        var nodes = StartingNodes;
        var currentDirectionIndex = 0;
        long counter = 0;

        while (!foundTheEnd)
        {
            var nextNodes = await Task.WhenAll(nodes.Select(x => GetNextNode(x, currentDirectionIndex)));

            if (nextNodes.All(x => x.isZNode))
            {
                foundTheEnd = true;
            }
            else
            {
                nodes = nextNodes.Select(x => x.Node).ToArray();
                currentDirectionIndex = NextDirection(currentDirectionIndex);
            }

            counter++;
        }

        return counter;
    }

    private Task<(Node Node, bool isZNode)> GetNextNode(Node node, int directionIndex)
    {
        return Task.Run(() =>
        {
            var name = InstructionTypeSequence[directionIndex] == InstructionType.L
                ? node.Left
                : node.Right;

            var newNode = Nodes[name];

            return (newNode, newNode.Name.EndsWith("Z"));
        });
    }

    private int NextDirection(int index)
    {
        if (index == InstructionTypeSequence.Length - 1)
        {
            return 0;
        }

        return index + 1;
    }

    public static LeftRightInstructions ParsePart1(string input)
    {
        var instructions = new LeftRightInstructions();

        var inputLines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .ToArray();

        instructions.InstructionTypeSequence = inputLines[0]
            .ToCharArray()
            .Select(x => Enum.Parse<InstructionType>(x.ToString()))
            .ToArray();

        instructions.Nodes = inputLines
            .Skip(1)
            .Select(line =>
            {
                var parts = line.Split(_separator, StringSplitOptions.RemoveEmptyEntries);
                return new Node
                {
                    Name = parts[0],
                    Left = parts[1],
                    Right = parts[2]
                };
            })
            .ToDictionary(x => x.Name, x => x);

        return instructions;
    }

    public static LeftRightInstructions ParsePart2(string input)
    {
        var instructions = ParsePart1(input);
        instructions.StartingNodes = instructions.Nodes.Values
            .Where(x => x.Name.EndsWith("A"))
            .ToArray();

        return instructions;
    }
}

enum InstructionType
{
    None = 0,
    R = 1,
    L = 2,
}
