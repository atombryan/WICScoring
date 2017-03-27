using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WICScoring.WIC
{
    /// <summary>
    /// A team competing in the FTC competition
    /// </summary>
    public class Team
    {
        public int teamNumber { get; set; }
        public string teamName { get; set; }
        public int WAIScore { get; set; }
        public List<Match> allMatcheEntries { get; set; }
        public int averageScore { get; set; }
        public int speedIndex { get; set; }

        public void findAverages ()
        {
            int sum = 0;
            int sumSpeed = 0;
            foreach (Match m in allMatcheEntries)
            {
                foreach (ScoringAction a in m.scoredValues)
                {
                    sum += a.scorePer;
                }
                sumSpeed += m.scoreIndex;
            }
            speedIndex = sumSpeed / allMatcheEntries.Count;
            averageScore = sum / allMatcheEntries.Count;
        }
    }
}