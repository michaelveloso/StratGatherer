using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using StratGatherer.Models;
using StratGatherer.MySportsFeeds.Response;

namespace StratGatherer.MySportsFeeds
{
    /// <summary>
    /// The client for communicating with MySportsFeeds.
    /// </summary>
    public class MySportsFeedsClient
    {
        private const string MY_SPORTS_FEEDS_BASE_URL = "https://api.mysportsfeeds.com/v1.1/pull/mlb/2017-regular/cumulative_player_stats.json";
        private const string USERNAME_ENV_VARIABLE = "MY_SPORTS_FEEDS_USERNAME";
        private const string PASSWORD_ENV_VARIABLE = "MY_SPORTS_FEEDS_PASSWORD";

        private IRestRequest _request;

        /// <summary>
        /// Gets the response from MySportsFeeds for a given collection of players.
        /// </summary>
        /// <param name="playersToQuery">The players to get stats for.</param>
        /// <returns>The response from MySportsFeeds.</returns>
        public static MySportsFeedsResponse Query()
        {
            return new MySportsFeedsClient().GetResponse();
        }

        private MySportsFeedsClient()
        {
            _request = new RestRequest();
        }

        private MySportsFeedsResponse GetResponse()
        {
            RestClient httpClient = new RestClient(MY_SPORTS_FEEDS_BASE_URL);

            BuildRequest();
            IRestResponse response = httpClient.Get(_request);
            MySportsFeedsResponse result = JsonConvert.DeserializeObject<MySportsFeedsResponse>(response.Content);
            return result;
        }

        private void BuildRequest()
        {
            AddHeaders();  
        }
        
        private void AddHeaders()
        {
            _request.AddHeader("Authorization", BuildAuthorization());
        }

        private string BuildAuthorization()
        {
            string username = Environment.GetEnvironmentVariable(USERNAME_ENV_VARIABLE);
            string password = Environment.GetEnvironmentVariable(PASSWORD_ENV_VARIABLE);
            string encodedAuth = EncodeUsernameAndPassword(username, password);
            string authorization = string.Format("Basic {0}", encodedAuth);
            return authorization;
        }

        private string EncodeUsernameAndPassword(string username, string password)
        {
            string stringToEncode = string.Format("{0}:{1}", username, password);
            byte[] plainTextBytes = System.Text.Encoding.UTF8.GetBytes(stringToEncode);
            string encodedUsernameAndPassword = System.Convert.ToBase64String(plainTextBytes);
            return encodedUsernameAndPassword;
        }
    }
}
