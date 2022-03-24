using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Model;

namespace API.Data.ValueObjects
{
    public class EventsVO
    {
        public string? Name { get; set; }
        public string? Category { get; set; }
        public string? Date { get; set; }
        public string? State { get; set; }
        public int? PersonId {get; set; }
    }
}
