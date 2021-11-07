using HackerRank;
using HackerRank.OneMonthPreparationKit.Week1;
using HackerRank.OneWeekPreparationKit;
using HackerRank.OneWeekPreparationKit.Day3;
using HackerRank.OneWeekPreparationKit.Day4;
using HackerRank.OneWeekPreparationKit.Day5;
using HackerRank.OneWeekPreparationKit.Day6;
using HackerRank.OneWeekPreparationKit.Day7;

namespace HackerRank
{
    class Program
    {
        public static void Main(string[] args)
        {
            OneMonthPreparationKit();
        }

        public static void OneWeekPreparationKit()
        {
            TowerBreakers.Run();
            CaesarCipher.Run();
            GridChallenge.Run();
            RecursiveDigitSum.Run();
            NewYearChaos.Run();
            QueueUsingTwoStacks.Run();
            BalancedBrackets.Run();
            SimpleTextEditor.Run();
            LegoBlocks.Run();
            JesseAndCookies.Run();
            TreeHuffmanDecoding.Run();
            TreePreorderTraversal.Run();
        }

        public static void OneMonthPreparationKit()
        {
            var challenges = new IChallenge[]
            {
                //new PlusMinus(),
                new MiniMaxSum(),
            };

            foreach (var challenge in challenges)
            {
                challenge.Start();
            }
        }
    }
}