using MediatR;
using TeamDev360.Models;

namespace TeamDev360.MediatR.Request
{
    public class QueryStateRequest : Query, IRequest<List<Event>>
    {
    }
}
