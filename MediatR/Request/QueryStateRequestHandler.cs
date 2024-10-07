using MediatR;
using TeamDev360.Models;
using TeamDev360.Service;

namespace TeamDev360.MediatR.Request
{
    // Send Request to this handler and get back the new state
    public class QueryStateRequestHandler : IRequestHandler<QueryStateRequest, List<Event>>, IRequestHandler<EventStateRequest, Event>
    {
        private readonly ITicketMasterService _ticketMasterService;
        public QueryStateRequestHandler(TicketMasterService ticketMasterService)
        {
            _ticketMasterService = ticketMasterService;
        }

        // This will handle the request for a specific type
        public async Task<List<Event>> Handle(QueryStateRequest request, CancellationToken cancellationToken)
        {
            // Handle the request and return the new state
            List<Event> newQueryState = await _ticketMasterService.GetEvents(request.Value);
            return newQueryState;
        }

        // This will handle the request for a specific id
        public async Task<Event> Handle(EventStateRequest request, CancellationToken cancellationToken)
        {
            Event newEvent = await _ticketMasterService.GetEventById(request.Id);
            return newEvent;
        }
    }
}