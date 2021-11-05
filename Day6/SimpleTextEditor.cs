using System;
using System.Collections.Generic;
using System.IO;

namespace HackerRank.Day6
{
    public static partial class SimpleTextEditor
    {
        #region Setup stuff
        public static void Run()
        {
            foreach (var test in TestCases())
            {
                Main1(test);
            }
        }

        public static void Main1(IList<string> test)
        {
            var program = new List<(Operation, string)>();

            for (var i = 0; i < test.Count; i++)
            {
                var instruction = Parse(test[i]);
                program.Add(instruction);
            }

            var outputStream = new StringWriter();
            Start(program, outputStream);
            Console.Write(outputStream.ToString());
        }

        public static void Main2(string[] args)
        {
            var numInstructions = int.Parse(Console.ReadLine());
            var program = new List<(Operation, string)>();

            for (var i = 0; i < numInstructions; i++)
            {
                var instruction = Parse(Console.ReadLine());
                program.Add(instruction);
            }

            var outputStream = new StringWriter();
            Start(program, outputStream);
            Console.Write(outputStream.ToString());
        }

        public static IEnumerable<IList<string>> TestCases()
        {
            return new[]
            {
                //new[]
                //{
                //    "1 abc",
                //    "3 3",
                //    "2 3",
                //    "1 xy",
                //    "3 2",
                //    "4 ",
                //    "4 ",
                //    "3 1"
                //},
                File.ReadAllLines("Day6\\SimpleTextEditor_input09.txt")
            };
        }
        #endregion

        private static (Operation, string) Parse(string line)
        {
            var split = line.Split(' ');
            var op = GetOperation(split[0]);
            string arg = null;

            if (split.Length > 1)
            {
                arg = split[1];
            }

            return (op, arg);
        }

        private static void Start(IList<(Operation op, string arg)> program, TextWriter outputStream)
        {
            var buffer = new List<char>();
            var undoStack = new Stack<(Operation, string)>();

            foreach (var instruction in program)
            {
                Execute(buffer, undoStack, instruction, outputStream);
            }
        }

        private static void Execute(List<char> buffer, Stack<(Operation op, string arg)> undoStack, (Operation op, string arg) instruction, TextWriter outputStream, bool isUndo = false)
        {
            switch (instruction.op)
            {
                case Operation.Append:
                {
                    buffer.AddRange(instruction.arg);
                    if (!isUndo)
                    {
                        undoStack.Push((Operation.Delete, instruction.arg.Length.ToString()));
                    }
                    break;
                }
                case Operation.Delete:
                {
                    var numCharsToRemove = int.Parse(instruction.arg);
                    var index = buffer.Count - numCharsToRemove;
                    var removedValue = buffer.GetRange(index, numCharsToRemove).ToArray();
                    buffer.RemoveRange(index, numCharsToRemove);
                    if (!isUndo)
                    {
                        undoStack.Push((Operation.Append, new string(removedValue)));
                    }
                    break;
                }
                case Operation.Print:
                {
                    var index = int.Parse(instruction.arg);
                    outputStream.WriteLine(buffer[index - 1]);
                    break;
                }
                case Operation.Undo:
                    var undoInstruction = undoStack.Pop();
                    Execute(buffer, undoStack, undoInstruction, outputStream, true);
                    break;
            }
        }

        public static Operation GetOperation(string value)
        {
            switch (value)
            {
                case "1":
                    return Operation.Append;
                case "2":
                    return Operation.Delete;
                case "3":
                    return Operation.Print;
                case "4":
                    return Operation.Undo;
                default:
                    throw new InvalidOperationException();
            }
        }

        public enum Operation
        {
            Append,
            Delete,
            Print,
            Undo
        }
    }
}
