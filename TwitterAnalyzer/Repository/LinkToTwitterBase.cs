using LinqToTwitter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace TwitterAnalyzer.Repository
{
    public class LinkToTwitterBase     {

        internal const string MyTwitterId = "14473601";
        internal const string MyTwitterName = "jefferydalton";

        internal SingleUserAuthorizer GetAuthKey()
        {
            return new SingleUserAuthorizer
            {
                Credentials = new SingleUserInMemoryCredentials() {
                        ConsumerKey = ConfigurationManager.AppSettings["consumerKey"],
                        ConsumerSecret = ConfigurationManager.AppSettings["consumerSecret"],
                        TwitterAccessToken = ConfigurationManager.AppSettings["twitterAccessToken"],
                        TwitterAccessTokenSecret = ConfigurationManager.AppSettings["twitterAccessSecret"]
                }
            };
        }

        public List<RateLimits> RateLimits()
        {
            using (var twitterCtx = new TwitterContext(this.GetAuthKey()))
            {
                return
                   (from help in twitterCtx.Help
                    where help.Type == HelpType.RateLimits
                    select help).SingleOrDefault()
                    .RateLimits.SelectMany(x => x.Value.Select(y => y)).ToList();
            }
        }

    }
}
