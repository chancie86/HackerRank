using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank.Other
{
    public class Countdown
        : Challenge<(int target, IList<double> testData), bool>
    {
        private IList<string> _result = new List<string>();

        protected override bool Run((int target, IList<double> testData) input)
        {
            _result.Clear();
            Console.WriteLine($"Target: {input.target}");

            var found = Test(input.target, input.testData);

            Console.WriteLine("Operations:");

            for (var i = _result.Count - 1; i >= 0; i--)
            {
                Console.WriteLine(_result[i]);
            }

            return found;
        }

        private bool Test(int target, IList<double> testData)
        {
            for (var i = 0; i < testData.Count; i++)
            {
                for (var j = i + 1; j < testData.Count; j++)
                {
                    var first = testData[i];
                    var second = testData[j];

                    if (Iterate(target, first, second, testData, i, j)
                        || Iterate(target, second, first, testData, i, j))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool Iterate(int target, double first, double second, IList<double> testData, int i, int j)
        {
            if (first == target || second == target)
            {
                return true;
            }

            foreach (Operation op in Enum.GetValues(typeof(Operation)))
            {
                double newNumber;
                switch (op)
                {
                    case Operation.Add:
                        newNumber = first + second;
                        break;
                    case Operation.Subtract:
                        newNumber = first - second;
                        break;
                    case Operation.Multiply:
                        newNumber = first * second;
                        break;
                    case Operation.Divide:
                        newNumber = first + second;
                        break;
                    default: // never happen
                        newNumber = -1;
                        break;
                }

                if (newNumber == target)
                {
                    AddResult(first, second, op, newNumber);
                    return true;
                }

                var newList = new List<double>();
                newList.Add(newNumber);
                for (var x = 0; x < testData.Count; x++)
                {
                    if (x == i
                        || x == j)
                    {

                    }
                    else
                    {
                        newList.Add(testData[x]);
                    }
                }

                if (Test(target, newList))
                {
                    AddResult(first, second, op, newNumber);
                    return true;
                }
            }

            return false;
        }

        public enum Operation
        {
            Add,
            Subtract,
            Multiply,
            Divide
        }

        public override IEnumerable<((int target, IList<double> testData) input, bool expectedResult)> TestCases()
        {
            return new List<((int target, IList<double> testData) input, bool expectedResult)>
            {
                ((104, new double[] { 50, 2, 4, 5, 2, 1, 7 }), true),
                ((941, new double[] { 50, 100, 7, 6, 1, 10 }), true),
                ((386, new double[] { 25, 75, 50, 1, 9, 3 }), true),
                ((644, new double[] { 25, 75, 3, 7, 4, 2 }), true),
                ((101, new double[] { 100, 75, 5, 9, 5, 4 }), true),
                ((130, new double[] { 62, 12, 7, 1, 5, 10 }), true),
                ((724, new double[] { 12, 87, 8, 3, 4, 8 }), true),
                ((649, new double[] { 37, 4, 1, 5, 10, 6 }), true),
                ((971, new double[] { 50, 100, 8, 10, 5, 2 }), true),
                ((949, new double[] { 37, 12, 5, 8, 6, 4 }), true),
                ((824, new double[] { 3, 7, 6, 2, 1, 7 }), false)
            };
        }

        private void AddResult(double first, double second, Operation op, double result)
        {
            char opChar = '$';
            switch (op)
            {
                case Operation.Add:
                    opChar = '+';
                    break;
                case Operation.Subtract:
                    opChar = '-';
                    break;
                case Operation.Divide:
                    opChar = '/';
                    break;
                case Operation.Multiply:
                    opChar = 'x';
                    break;
            }
            _result.Add($"{first} {opChar} {second} = {result}");
        }
    }
}
