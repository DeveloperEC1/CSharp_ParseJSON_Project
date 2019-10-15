using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace TMDBAppJSONNameSpace
{
    class TMDBAppJSONProgram
    {
        static void Main(string[] args)
        {
            TMDBAppParseJSON();
            Console.ReadLine();
            Console.ReadKey();
        }

        public static async void TMDBAppParseJSON()
        {
            string API_KEY = "";
            string baseUrl = "https://api.themoviedb.org/3/search/movie?/&query=Movie&api_key="
                             + API_KEY + 
                             "&language=en-US";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.GetAsync(baseUrl))
                    {
                        using (HttpContent content = res.Content)
                        {
                            var data = await content.ReadAsStringAsync();
                            if (data != null)
                            {
                                for (int i = 0; i < data.Length; i++)
                                {
                                    Console.WriteLine("Title: " + JObject.Parse(data)["results"][i]["title"] +
                                        ".\nOverview: " + JObject.Parse(data)["results"][i]["overview"] + ".\nVote Average: " +
                                        JObject.Parse(data)["results"][i]["vote_average"] + "\n");
                                }
                            }
                            else
                            {
                                Console.WriteLine("NO Data...");
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception Hit...");
                Console.WriteLine(exception);
            }
        }
    }
}
