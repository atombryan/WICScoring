using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WICScoring.WIC; 
using ServiceStack;
using WICScoring.Repositories;

namespace WICScoring.Services
{
    public class GetTeamList : Service
    {
        public WicInfoRepository WicInfoRepository { get; set; }
        public object Any (GetTeamListEntry entry)
        {
            if (entry.getVal)
            {
                return new GetTeamResponse { teamList = WicInfoRepository.getTeamList() };
            }
            return new GetTeamDumpResponse();
        }

    }
    public class GetTeamListEntry : IReturn<GetTeamResponse>
    {
        public bool getVal { get; set; }
    }
    public class GetTeamResponse
    {
        public List<Team> teamList { get; set; }
    }
}