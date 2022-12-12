using System;
using System.Net.Http.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Questao2.ApiClient
{
    public class TeamClientApi
    {
        public TeamClientApi()
        {
        }
        private static string apiUrl = "https://jsonmock.hackerrank.com/api/football_matches";

        private static HttpClient client = new HttpClient();
           
              
        public static async Task<Entidade.Root> GetTeamAsync(int ano, string Team)
        {
           Entidade.Root teamRoot = null;
            HttpResponseMessage response = await client.GetAsync(apiUrl + "?year="+ ano + "&team1="+ Team);
            if (response.IsSuccessStatusCode)
            {
                teamRoot = await response.Content.ReadFromJsonAsync<Entidade.Root>();
            }
            return teamRoot;
        }
    }
}

