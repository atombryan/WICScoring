using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using ServiceStack;
using ServiceStack.Auth;
using ServiceStack.Caching;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Sqlite;
using ServiceStack.MiniProfiler.Data;
using ServiceStack.MiniProfiler;
using ServiceStack.Data;
using Funq;
using WICScoring.Repositories;
using WICScoring.Services;
using ServiceStack.Configuration;

namespace WICScoring
{
    
    public class Global : System.Web.HttpApplication
    {
        public class WicSelfStart : AppSelfHostBase
        {
            public WicSelfStart() : base("WicScoring", typeof(RegisterTeam).Assembly)
            {

            }
            public override void Configure(Container container)
            {
                Plugins.Add(new AuthFeature(
                      () => new AuthUserSession(),
                      new IAuthProvider[] { new BasicAuthProvider(), }));

                container.Register<ICacheClient>(new MemoryCacheClient());
                var userRepo = new InMemoryAuthRepository();
                container.Register<IUserAuthRepository>(userRepo);
                string salt;
                string hash;
                string password = "bk,^{X).Q3q2CFW_";
                new SaltedHash().GetHashAndSaltString(password, out hash, out salt);
                userRepo.CreateUserAuth(new UserAuth
                {
                    Id = 0,
                    PasswordHash = hash,
                    Salt = salt,
                    DisplayName = "Admin",
                    UserName = "Admin",
                    Roles = new List<string> { "Basic", RoleNames.Admin },
                    Permissions = new List<string> { }
                }, password);
                var wicConnectionFactory = new OrmLiteConnectionFactory(UniversalProperties.databaseDirectory, SqliteDialect.Provider) { ConnectionFilter = x => new ProfiledDbConnection(x, Profiler.Current) };
                container.Register<IDbConnectionFactory>(wicConnectionFactory);
                container.RegisterAutoWired<WicInfoRepository>();

            }
        }

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}