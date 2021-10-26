 using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public static class NewYearChaos
    {
        public static void Run()
        {
            foreach (var test in TestCases())
            {
                Console.WriteLine(minimumBribes(test));
            }
        }

        public static void minimumBribes(List<int> q)
        {

        }
    }
}
