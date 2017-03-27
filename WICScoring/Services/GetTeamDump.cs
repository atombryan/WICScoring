using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using WICScoring.WIC;
using WICScoring.Repositories;

namespace WICScoring.Services
{
    public class GetTeamDump : Service
    {
        public WicInfoRepository WicInfoRepository { get; set; }
        public object Any (GetTeamDumpEntry entry)
        {
            if (entry.teamNumber.Equals(null))
                return new GetTeamDumpResponse { returnCode = 2 };
            else if (entry.compareToTeamNumber.Equals(null))
            {
                TeamDump dump = WicInfoRepository.GetDump(entry.teamNumber);
                if (dump.returnCode.Equals(1))
                    return new GetTeamDumpResponse { returnCode = 1 };
            }
            else
            {
                TeamDump dump = WicInfoRepository.GetDump(entry.teamNumber, entry.compareToTeamNumber);
                if (dump.returnCode.Equals(4))
                    return new GetTeamDumpResponse { dump = dump, returnCode = 4 };
                return new GetTeamDumpResponse { dump = dump, returnCode = 0 };
            }
            return new GetTeamDumpResponse { returnCode = 3 };
        }
    }
    public class GetTeamDumpEntry : IReturn<GetTeamDumpResponse>
    {
        public int teamNumber { get; set; }
        public int compareToTeamNumber { get; set; }
    }
    public class GetTeamDumpResponse
    {
        public TeamDump dump { get; set; }
        public int returnCode { get; set; }
    }
}