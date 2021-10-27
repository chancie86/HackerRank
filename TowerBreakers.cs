using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank
{
    public static class TowerBreakers
    {
        public static void Run()
        {
            foreach (var test in TestData())
            {
                Console.WriteLine(towerBreakers(test.Item1, test.Item2));
            }
        }

        public static int towerBreakers(int numTowers, int initialHeight)
        {
            // initialise
            var towers = new int[numTowers];
            for (var i = 0; i<towers.Length; i++)
            {
                towers[i] = initialHeight;
            }

            var currentPlayer = 1;
            var lastTowerIndex = 0;
        
            while (true)
            {
                var towerIndex = -1;
                
                for (var i = lastTowerIndex; i < towers.Length; i++)
                {
                    if (towers[i] > 1)
                    {
                        towerIndex = i;
                        break;
                    }
                }
                
                if (towerIndex < 0)
                {
                    break;
                }

                lastTowerIndex = towerIndex;

                towers[towerIndex] = FindNewHeight(towers[towerIndex]);
                currentPlayer = currentPlayer == 1 ? 2 : 1;
            }
        
            // current player loses
            return currentPlayer == 1 ? 2 : 1;
        }
    
        private static int FindNewHeight(int height)
        {
            for (var i = 1; i < height; i++)
            {
                if (height % i == 0)
                {
                    return i;
                }
            }

            throw new Exception();
        }

        private static List<(int, int)> TestData()
        {
            return new List<(int, int)>() { (2,2) };

            var tests = new[]
            {
                "100000 1",
                "100001 1",
                "61092 2596",
                "276941 868497",
                "806383 84537",
                "748429 597413",
                "184563 986480",
                "209397 536712",
                "370556 924250",
                "484633 236170",
                "618395 760127",
                "368997 531386",
                "462639 720679",
                "747640 62356",
                "36692 147773",
                "252494 133147",
                "713511 687321",
                "895409 844631",
                "511793 749786",
                "532234 30480",
                "107197 867411",
                "447514 354227",
                "532738 397254",
                "242526 104893",
                "269304 737572",
                "377370 182325",
                "20076 564093",
                "322152 840900",
                "211496 89225",
                "327572 535457",
                "119790 233269",
                "890728 343005",
                "593727 474077",
                "679256 355185",
                "789350 648969",
                "498555 479691",
                "86940 584332",
                "537228 736989",
                "586974 557868",
                "745608 586668",
                "431757 564586",
                "127610 378858",
                "283840 337523",
                "363165 899851",
                "646063 607693",
                "570907 244409",
                "356177 498360",
                "986738 330423",
                "605912 933903",
                "237281 7537",
                "101806 225384",
                "152894 365440",
                "246014 487920",
                "160718 851010",
                "186610 87908",
                "285160 806047",
                "173413 55667",
                "896968 842504",
                "80252 51648",
                "524630 18247",
                "410490 697119",
                "982600 997481",
                "112065 896813",
                "397946 576129",
                "969689 917603",
                "865703 5302",
                "817257 975287",
                "257961 490860",
                "170927 723059",
                "668794 821047",
                "929586 718620",
                "556889 535158",
                "571742 476727",
                "280043 838772",
                "769667 205124",
                "187086 968213",
                "323753 711113",
                "425533 199552",
                "507725 736414",
                "242465 529960",
                "114863 707390",
                "610758 767953",
                "288696 87310",
                "581370 506218",
                "154398 932225",
                "481249 320715",
                "532710 594017",
                "51836 369314",
                "336681 454371",
                "134445 548727"
            };

            return tests.Select(x =>
            {
                var split = x.Split(" ");
                return (int.Parse(split[0]), int.Parse(split[1]));
            }).ToList();
        }
    }
}
