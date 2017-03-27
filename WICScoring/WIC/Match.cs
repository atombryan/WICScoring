using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WICScoring.WIC
{
    /// <summary>
    /// An individual match, defined on a per-robot basis
    /// </summary>
    public class Match
    {
        public List<ScoringAction> scoredValues { get; set; }
        public int allianceScore { get; set; }
        /// <summary>
        /// AllianceScore - OppositeAllianceScore
        /// </summary>
        public int competetiveScore { get; set; }
        public string notes { get; set; }
        public int givenDeductor { get; set; }
        public int scoreIndex { get; set; }
        public DateTime date { get; set; }
    }
}