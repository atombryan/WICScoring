using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WICScoring.WIC
{
    /// <summary>
    /// Updated at the begining of each season and stores all of the data for the given seasons game
    /// </summary>
    public class Competition
    {
        public string competitionName { get; set; }
        public List<ScoringAction> pointValues { get; set; }
        public string gameDescrition { get; set; }

        public static float GetWicScore (Team a, Team b)
        {
            throw new MissingMethodException("Implement GetWicScore algorithm in WICScoring.WIC.Competition!");
        }

    }
}