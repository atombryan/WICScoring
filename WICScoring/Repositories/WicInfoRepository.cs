using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using ServiceStack.Data;
using WICScoring.WIC;
using ServiceStack.OrmLite;

namespace WICScoring.Repositories
{
    /// <summary>
    /// This class interacts with the WIC database. All database calls should be through the functions in this class
    /// </summary>
    public class WicInfoRepository
    {
        public IDbConnectionFactory wicConnectionFactory { get; set; }

        public int RegisterTeam (Team team)
        {
            using (var connection = wicConnectionFactory.OpenDbConnection())
            {
                connection.CreateTable<Team>();
                if (connection.Select<Team>(e => e.teamNumber.Equals(team.teamNumber)).Count <= 0)
                {
                    connection.Insert(team);
                    if (connection.Select<Team>(e => e.teamNumber.Equals(team.teamNumber)).Count > 0)
                    {
                        return 0;
                    }
                    return 2;
                }
                return 1;
            }
        }
        
        public int WriteMatch (int teamNumber, Match match)
        {
            using (var connection = wicConnectionFactory.OpenDbConnection())
            {
                List<Team> team = connection.Select<Team>(e => e.teamNumber.Equals(teamNumber));
                if (team.Count > 0)
                {
                    Team t = team[0];
                    t.allMatcheEntries.Add(match);
                    t.findAverages();
                    connection.Delete<Team>(e => e.teamNumber.Equals(teamNumber));
                    connection.Insert(t);
                    return 0;
                }
                return 1;
            }
        }

        public TeamDump GetDump(int teamNumber)
        {
            using (var connection = wicConnectionFactory.OpenDbConnection())
            {
                List<Team> team = connection.Select<Team>(e => e.teamNumber.Equals(teamNumber));
                if (team.Count > 0)
                    return new TeamDump { team = team[0], WICScore = -1, returnCode = 0 };
                else
                    return new TeamDump { returnCode = 1 };
            }
        }
        public TeamDump GetDump (int teamNumber, int compareToTeamNumber)
        {
            using (var connection = wicConnectionFactory.OpenDbConnection())
            {
                List<Team> teamA = connection.Select<Team>(e => e.teamNumber.Equals(teamNumber));
                List<Team> teamB = connection.Select<Team>(e => e.teamNumber.Equals(compareToTeamNumber));
                if (teamB.Count > 0 && teamA.Count > 0)
                {
                    float wicScore = Competition.GetWicScore(teamA[0], teamB[0]);
                    return new TeamDump { team = teamA[0], WICScore = wicScore, returnCode = 0 };
                }
                else if (teamA.Count > 0)
                    return new TeamDump { team = teamA[0], WICScore = -1, returnCode = 4 };
                else
                    return new TeamDump { returnCode = 1 };
            }
        }

    }
}