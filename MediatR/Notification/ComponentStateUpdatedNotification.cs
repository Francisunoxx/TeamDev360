using MediatR;
using TeamDev360.Models;

namespace TeamDev360.MediatR.Notification
{
    //Notification used to observe changes in the state of a component
    public class ComponentStateUpdatedNotification : ComponentState, INotification
    {
    }
}