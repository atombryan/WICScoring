using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using WICScoring.WIC;
using WICScoring.Repositories;

namespace WICScoring.Services
{
    /// <summary>
    /// Called to register a new team with the database. Will not do so if team already exists
    /// </summary>
    public class RegisterTeam : Service
    {
        public WicInfoRepository WicInfoRepository { get; set; }
        public object Any (RegisterTeamEntry entry)
        {
            if (entry.team.teamNumber < 0 || entry.team.teamNumber >= 1000000)
                return new RegisterTeamResponse { responseCode = 1 };
            if (entry.team.teamNumber.Equals(null))
                return new RegisterTeamResponse { responseCode = 2 };

            int response = WicInfoRepository.RegisterTeam(entry.team);
            if (response > 0)
                return new RegisterTeamResponse { responseCode = 3 };
            return new RegisterTeamResponse { responseCode = 0 };
        }
    }

    [Route("/RegTeam")]
    public class RegisterTeamEntry : IReturn<RegisterTeamResponse>
    {
        public Team team { get; set; }
    }
    
    public class RegisterTeamResponse
    {
        public int responseCode { get; set; }
    }
}