using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Web.Http;
using Newtonsoft.Json.Linq;

namespace TrabalhoFinal_FA7_WP
{
    class GitHubRepositories
    {
        public async Task<List<string>> GetRepositories(string usuario)
        {
            var repositories = new List<string>();

            string url = "https://api.github.com/users/" + usuario + "/repos";
            Uri uri = new Uri(url, UriKind.Absolute);

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Other");
            var response = await httpClient.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var jsonRepositories = JArray.Parse(await response.Content.ReadAsStringAsync());

                foreach (var repository in jsonRepositories)
                {
                    repositories.Add(
                        repository.Value<string>("name") + " - " +
                        repository.Value<string>("language"));
                }
            }
            else
            {
                repositories.Add("Não foram encontrado projetos");
            }

            return repositories;
        }

        internal Task<List<string>> GetRepositories()
        {
            throw new NotImplementedException();
        }
    }
}
