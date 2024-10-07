
using Microsoft.Extensions.Options;
using System.Text.Json;
using TeamDev360.Models;

namespace TeamDev360.Service
{
    public class TicketMasterService : ITicketMasterService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly TicketMasterConfig _ticketMasterConfig;
        private string[] types = ["events", "attractions", "venues", "classfications"];
        //Bind the value coming from appsettings.json to the TicketMasterConfig object
        public TicketMasterService(IOptions<TicketMasterConfig> ticketMasterConfig, IHttpClientFactory httpClientFactory)
        {
            _ticketMasterConfig = ticketMasterConfig.Value;
            _httpClientFactory = httpClientFactory;
        }

        //Get the event by id
        public async Task<Event> GetEventById(string id)
        {
            foreach (var type in types)
            {
                var request = new HttpRequestMessage(HttpMethod.Get,
                        $"{_ticketMasterConfig.TicketMasterBaseUrl}{type}/{id}?apikey={_ticketMasterConfig.TicketMasterApiKey}");
                var client = _httpClientFactory.CreateClient();
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var data = JsonSerializer.Deserialize<Event>(jsonResponse, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    if (data?.Embedded != null)
                    {
                        return data;
                    }
                }
            }

            return null;
        }

        //Get event by type
        public async Task<List<Event>> GetEvents(string value)
        {
            List<Event> dataList = new List<Event>();

            foreach (var type in types)
            {
                var request = new HttpRequestMessage(HttpMethod.Get,
                        $"{_ticketMasterConfig.TicketMasterBaseUrl}{type}?keyword={value}&apikey={_ticketMasterConfig.TicketMasterApiKey}");
                var client = _httpClientFactory.CreateClient();
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var data = JsonSerializer.Deserialize<Event>(jsonResponse, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    // Assuming `Data.Embedded` is the object of the `Embedded` class
                    if (data?.Embedded != null)
                    {
                        // Combine all non-empty properties (events, attractions, venues) into a single list
                        var nonEmptyProperties = new List<List<Event>>
                        {
                            data.Embedded.Events,
                            data.Embedded.Attractions,
                            data.Embedded.Venues,
                            data.Embedded.Classifications
                        };

                        // Flatten non-empty lists into a single list
                        var combinedResults = nonEmptyProperties
                            .Where(p => p != null && p.Count > 0)  // Filter non-empty lists
                            .SelectMany(p => p)  // Flatten into one list of Result objects
                            .ToList();

                        // Add all combined results to DataList
                        dataList.AddRange(combinedResults);
                    }
                }
            }

            return dataList;
        }
    }
}
