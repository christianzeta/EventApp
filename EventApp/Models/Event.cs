using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventApp.Models
{
    public class Event
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int OrganizerID { get; set; }
        public string Description { get; set; }
        public string Place { get; set; }
        public string Address { get; set; }
        public string Date { get; set; }
        public int SpotsAvailable { get; set; }
        public List<Attendee> Attendees { get; set; }

    }
}
