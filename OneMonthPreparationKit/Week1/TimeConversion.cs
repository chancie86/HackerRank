using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace HackerRank.OneMonthPreparationKit.Week1
{
    public class TimeConversion
        : Challenge<string, string>
    {
        protected override string Run(string s)
        {
            var regexPattern = @"(?<hour>\d{2}):(?<minutes>\d{2}):(?<seconds>\d{2})(?<meridiem>AM|PM)";
            var matches = (Regex.Matches(s, regexPattern))[0];

            var isMorning = matches.Groups["meridiem"].Value == "AM";
            var hour = int.Parse(matches.Groups["hour"].Value);
            var minutes = matches.Groups["minutes"].Value;
            var seconds = matches.Groups["seconds"].Value;

            if (isMorning)
            {
                if (hour == 12)
                {
                    hour = 0;
                }
            }
            else
            {
                if (hour != 12)
                {
                    hour = (hour + 12) % 24;
                }
            }

            var hourText = string.Format("{0:D2}", hour);

            return $"{hourText}:{minutes}:{seconds}";
        }

        public override IEnumerable<(string, string)> TestCases()
        {
            return new[]
            {
                ("07:05:45PM", "19:05:45")
            };
        }
    }
}
