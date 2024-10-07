using TeamDev360.Models;

namespace TeamDev360.Service
{
    public interface ITicketMasterService
    {
        Task<List<Event>> GetEvents(string value);
        Task<Event> GetEventById(string id);
    }
}
