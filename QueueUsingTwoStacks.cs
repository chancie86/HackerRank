using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank
{
    class QueueUsingTwoStacks
    {
        public static void Run()
        {
            foreach (var test in TestCases())
            {
                Start(test.Select(x => Parse(x)));
            }
        }

        private static void Main1(string[] args)
        {
            var numQueries = int.Parse(Console.ReadLine());
            var program = new List<(Operation, int?)>();

            for (var i = 0; i < numQueries; i++)
            {
                var line = Console.ReadLine();
                var instruction = Parse(line);
                program.Add(instruction);
            }

            Start(program);
        }

        private static (Operation, int?) Parse(string line)
        {
            var split = line.Split(' ');
            var op = GetOperation(split[0]);

            int? value = null;
            if (split.Length > 1)
            {
                value = int.Parse(split[1]);
            }

            return (op, value);
        }

        private static void Start(IEnumerable<(Operation, int?)> instructions)
        {
            var queue = new Collections.Queue<int>();

            foreach (var instruction in instructions)
            {
                switch (instruction.Item1)
                {
                    case Operation.Enqueue:
                        queue.Enqueue(instruction.Item2.Value);
                        break;
                    case Operation.Dequeue:
                        queue.Dequeue();
                        break;
                    case Operation.Print:
                        Console.WriteLine(queue.Peek());
                        break;
                }
            }
        }

        private static Operation GetOperation(string value)
        {
            switch (value)
            {
                case "1":
                    return Operation.Enqueue;
                case "2":
                    return Operation.Dequeue;
                case "3":
                    return Operation.Print;
                default:
                    throw new InvalidOperationException();
            }
        }

        public enum Operation
        {
            Enqueue,
            Dequeue,
            Print
        }

        public static IList<string[]> TestCases()
        {
            return new List<string[]>
            {
                new[]
                {
                    "1 42",
                    "2",
                    "1 14",
                    "3",
                    "1 28",
                    "3",
                    "1 60",
                    "1 78",
                    "2",
                    "2"
                }
            };
        }
    }
}
