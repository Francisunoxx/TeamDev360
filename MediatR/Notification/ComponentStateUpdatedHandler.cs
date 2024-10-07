using MediatR;
using TeamDev360.Models;

namespace TeamDev360.MediatR.Notification
{
    //Handler that updates the state of a component
    public class ComponentStateUpdatedHandler : INotificationHandler<ComponentStateUpdatedNotification>
    {
        private readonly ComponentState _componentState;

        public ComponentStateUpdatedHandler(ComponentState componentState)
        {
            _componentState = componentState;
        }

        public Task Handle(ComponentStateUpdatedNotification notification, CancellationToken cancellationToken)
        {
            _componentState.BackgroundColor = notification.BackgroundColor;
            _componentState.IsVisible = notification.IsVisible;
            return Task.CompletedTask;
        }
    }

}