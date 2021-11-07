using System;
using System.Collections.Generic;

namespace HackerRank
{
    public interface IChallenge
    {
        void Start();
    }

    public abstract class Challenge<TInput, TOutput>
        : IChallenge
        where TOutput : IComparable
    {
        public void Start()
        {
            var testNumber = 1;

            foreach (var test in TestCases())
            {
                Console.WriteLine($"Test: {testNumber++}");
                var result = Run(test.input);
                var success = result.CompareTo(test.expectedResult) == 0;
                Console.WriteLine($"Result: {(success ? "PASS" : "FAIL")}, Output: {result}");
            }
        }

        protected abstract TOutput Run(TInput input);

        public abstract IEnumerable<(TInput input, TOutput expectedResult)> TestCases();
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
