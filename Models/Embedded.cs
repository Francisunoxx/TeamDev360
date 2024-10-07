namespace TeamDev360.Models
{
    public class Embedded
    {
        public List<Event> Events { get; set; }
        public List<Event> Attractions { get; set; }
        public List<Event> Venues { get; set; }
        public List<Event> Classifications { get; set; }

        public List<Event> GetNonEmptyItems()
        {
            // Combine and return a single list of all non-empty items, or an empty list if all are null/empty
            return new List<List<Event>> { Events, Attractions, Venues, Classifications }
                .Where(list => list != null && list.Count > 0) // Filter non-empty lists
                .SelectMany(list => list)                      // Flatten into a single list
                .ToList() ?? new List<Event>();                // Return an empty list if the result is null
        }

    }
}
