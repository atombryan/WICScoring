using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WICScoring.WIC
{
    /// <summary>
    /// Each individual action that can be performed to get points in a match
    /// </summary>
    public class ScoringAction
    {
        public int scorePer { get; set; }
        public string name { get; set; }
    }
}