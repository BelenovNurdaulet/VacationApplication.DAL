using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using VacationApplication.DAL.Models;

public class VacationService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<VacationService> _logger;

    public VacationService(HttpClient httpClient, ILogger<VacationService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<VacationApplicationResponse> CreateVacationAsync(CreateVacationApplicationRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync("api/vacations", request);
        
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<VacationApplicationResponse>();
        }

        _logger.LogError("Failed to create vacation application: {StatusCode}", response.StatusCode);
        return null;
    }

    public async Task<IEnumerable<VacationApplicationResponse>> GetVacationsByCreateByAsync(int createBy)
    {
        var response = await _httpClient.GetAsync($"api/vacations/CreateBy?CreateBy={createBy}");

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<IEnumerable<VacationApplicationResponse>>();
        }

        _logger.LogError("Failed to fetch vacation applications: {StatusCode}", response.StatusCode);
        return new List<VacationApplicationResponse>();
    }
}