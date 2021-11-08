using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace HackerRank
{
    public interface IChallenge
    {
        void Start();
    }

    public abstract class Challenge<TInput, TOutput>
        : IChallenge
    {
        public void Start()
        {
            var testNumber = 1;

            foreach (var test in TestCases())
            {
                Console.WriteLine($"Test: {testNumber++}");
                var result = Run(test.input);
                var success = test.expectedResult.Equals(result);

                Console.WriteLine($"Result: {(success ? "PASS" : "FAIL")}");

                if (result is string)
                {
                    Console.WriteLine($"Output: {result}");
                } 
                else if (result is IEnumerable convertedResult)
                {
                    Console.WriteLine($"Output:\n{StringifyEnumerable(convertedResult)}");
                }
                else
                {
                    Console.WriteLine($"Output: {result}");
                }
            }
        }

        protected abstract TOutput Run(TInput input);

        public abstract IEnumerable<(TInput input, TOutput expectedResult)> TestCases();

        public static string StringifyEnumerable(IEnumerable list)
        {
            var sb = new StringBuilder();
            foreach (var item in list)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }
    }

    public abstract class Challenge<TInput>
        : IChallenge
    {
        public virtual void Start()
        {
            var testNumber = 1;

            foreach (var test in TestCases())
            {
                Console.WriteLine($"Test: {testNumber++}");
                Run(test);
            }
        }

        protected abstract void Run(TInput input);

        public abstract IEnumerable<TInput> TestCases();
    }
}
