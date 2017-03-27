using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WICScoring.WIC
{
    public class TeamDump
    {
        public Team team { get; set; }
        public float WICScore { get; set; }
        public int returnCode { get; set; }
    }
}