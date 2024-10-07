namespace TeamDev360.Models
{
    public class ComponentState
    {
        public bool IsVisible { get; set; }
        public string HeaderBackgroundColor = "#182F40";
        public string BackgroundColor = "#182F40";
        public event Action OnChange;
        public void NotifyStateChanged() => OnChange?.Invoke();
    }
}
