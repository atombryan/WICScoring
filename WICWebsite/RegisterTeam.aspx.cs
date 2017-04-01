using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServiceStack;
using WICScoring.WIC;
using WICScoring.Services;

namespace WICWebsite
{
    public partial class RegisterTeam : System.Web.UI.Page
    {
        public JsonServiceClient client = new JsonServiceClient(WICScoring.UniversalProperties.connectionURI);

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            RegisterTeamResponse response = client.Send(new RegisterTeamEntry
            {
                team = new Team
                {
                    teamName = teamName.Text,
                    teamNumber = Int32.Parse(teamNumber.Text),
                    WAIScore = Int32.Parse(waiScore.Text),
                    allMatchEntries = new List<Match>(),
                    averageScore = 0,
                    speedIndex = 0
                }
            });

            returningCode.Text = response.responseCode.ToString();


        }
    }
}