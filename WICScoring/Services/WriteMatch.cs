using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using WICScoring.Repositories;
using WICScoring.WIC;

namespace WICScoring.Services
{
    public class WriteMatch : Service
    {
        public WicInfoRepository WicInfoRepository { get; set; }
        public object Any (WriteMatchEntry entry)
        {
            if (entry.teamNumber.Equals(null))
                return new WriteMatchResponse { responseCode = 2 };
            if (entry.teamNumber < 0 || entry.teamNumber >= 1000000)
                return new WriteMatchResponse { responseCode = 1 };

            int a = WicInfoRepository.WriteMatch(entry.teamNumber, entry.match);
            if (a > 0)
                return new WriteMatchResponse { responseCode = 1 };
            return 0;
        }
    }
    public class WriteMatchEntry : IReturn<WriteMatchResponse>
    {
        public int teamNumber { get; set; }
        public Match match { get; set; }
    }
    
    public class WriteMatchResponse
    {
        public int responseCode { get; set; }
    }
    
}