using MediatR;
using TeamDev360.Models;

namespace TeamDev360.MediatR.Request
{
    public class EventStateRequest : Event, IRequest<Event>
    {
    }
}
