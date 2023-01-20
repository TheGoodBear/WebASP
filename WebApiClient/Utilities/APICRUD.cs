using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace WebApiClient.Utilities;

public static class APICRUD<T>
{

    // properties
    private static string APIURL = "http://localhost:5090/api/";


    // methods
    public static async Task<IEnumerable<T>> ReadAllData()
    {
        IEnumerable<T> Entities = null;

        using (HttpClient Client = new HttpClient())
        {
            Client.BaseAddress = new Uri($"{APIURL}{typeof(T).Name}");
            //HTTP GET
            var responseTask = Client.GetAsync(typeof(T).Name);
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<T>>();
                readTask.Wait();

                Entities = readTask.Result;
            }
            else //web api sent error response 
            {
                //log response status here..

                Entities = Enumerable.Empty<T>();

                string ErrorMessage = "Server error. Please contact administrator.";
            }
        }

        return Entities;

    }


    public static async Task CreateData(T Entity)
    {

        using (HttpClient Client = new HttpClient())
        {
            Client.BaseAddress = new Uri($"{APIURL}{typeof(T).Name}");

            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var JSon = JsonConvert.SerializeObject(Entity);

            var Content = new StringContent(JSon, Encoding.UTF8, "application/json");

            HttpResponseMessage Response = await Client.PostAsync(
                Client.BaseAddress,
                Content);
        }

    }


    public static async Task EditData(T Entity, int ID)
    {

        using (HttpClient Client = new HttpClient())
        {
            Client.BaseAddress = new Uri($"{APIURL}{typeof(T).Name}/{ID}");

            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var JSon = JsonConvert.SerializeObject(Entity);

            var Content = new StringContent(JSon, Encoding.UTF8, "application/json");

            HttpResponseMessage Response = await Client.PutAsync(
                Client.BaseAddress,
                Content);
        }

    }


    public static async Task DeleteData(int ID)
    {

        using (HttpClient Client = new HttpClient())
        {
            Client.BaseAddress = new Uri($"{APIURL}{typeof(T).Name}/{ID}");

            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage Response = await Client.DeleteAsync(
                Client.BaseAddress);
        }

    }


}
