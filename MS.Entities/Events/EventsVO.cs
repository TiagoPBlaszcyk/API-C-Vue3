namespace MS.Entities.Events
{
    public class EventsVO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string? Category { get; set; }
        public DateTime? StartDay { get; set; }
        public string State { get; set; }
        public int? PersonId {get; set; }
    }
}
