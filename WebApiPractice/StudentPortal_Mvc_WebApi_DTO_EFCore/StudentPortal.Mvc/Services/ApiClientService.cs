using System.Net.Http.Json;
using System.Text.Json;
namespace StudentPortal.Mvc.Services;
public class ApiClientService
{
    private readonly HttpClient _httpClient;
    private static readonly JsonSerializerOptions Opt = new() { PropertyNameCaseInsensitive = true };
    public ApiClientService(HttpClient httpClient) => _httpClient = httpClient;
    public Task<List<T>?> GetListAsync<T>(string endpoint) => _httpClient.GetFromJsonAsync<List<T>>(endpoint, Opt);
    public Task<T?> GetAsync<T>(string endpoint) => _httpClient.GetFromJsonAsync<T>(endpoint, Opt);
    public async Task<(bool Success, string Message)> PostAsync<T>(string endpoint, T data) { var r = await _httpClient.PostAsJsonAsync(endpoint, data); var c = await r.Content.ReadAsStringAsync(); return (r.IsSuccessStatusCode, string.IsNullOrWhiteSpace(c) ? r.ReasonPhrase ?? "Done" : c.Trim('"')); }
    public async Task<(bool Success, string Message)> PutAsync<T>(string endpoint, T data) { var r = await _httpClient.PutAsJsonAsync(endpoint, data); var c = await r.Content.ReadAsStringAsync(); return (r.IsSuccessStatusCode, string.IsNullOrWhiteSpace(c) ? r.ReasonPhrase ?? "Done" : c.Trim('"')); }
    public async Task<(bool Success, string Message)> DeleteAsync(string endpoint) { var r = await _httpClient.DeleteAsync(endpoint); var c = await r.Content.ReadAsStringAsync(); return (r.IsSuccessStatusCode, string.IsNullOrWhiteSpace(c) ? r.ReasonPhrase ?? "Done" : c.Trim('"')); }
}