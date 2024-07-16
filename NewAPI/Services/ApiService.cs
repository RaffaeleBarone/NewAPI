using Newtonsoft.Json;

namespace NewAPI.Services;
public class ApiService
{
    private readonly HttpClient _client;

    public ApiService(HttpClient client)
    {
        _client = client;
    }

    public async Task<string> GetDataFromApi(string path)
    {
        HttpResponseMessage response = await _client.GetAsync(path);
        response.EnsureSuccessStatusCode();
        string data = await response.Content.ReadAsStringAsync();
        return data;
    }

    //public async Task<Dictionary<string, object>> GetDataFromApi(string path)
    //{
    //    HttpResponseMessage response = await _client.GetAsync(path);
    //    response.EnsureSuccessStatusCode();
    //    string data = await response.Content.ReadAsStringAsync();
    //    var settings = new JsonSerializerSettings
    //    {
    //        TypeNameHandling = TypeNameHandling.Auto,
    //        NullValueHandling = NullValueHandling.Ignore,
    //        MissingMemberHandling = MissingMemberHandling.Ignore
    //    };
    //    var result = JsonConvert.DeserializeObject<Dictionary<string, object>>(data, settings);
    //    return result;
    //}
}
