using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EventApp.Data;

namespace EventApp.Pages
{
    public class JoinEventModel : PageModel
    {
        private readonly Data.EventContext _context;

        public JoinEventModel(Data.EventContext context)
        {
            _context = context;
          
        }

        public Event Event { get; set; }
        public Attendee Attendee { get; set; }
        public Organizer Organizer { get; set; }
        public string req { get; set; }

        public async Task OnGetAsync(string id)
        {
           // Event = await _context.Events.FirstOrDefaultAsync(e => e.ID == Int32.Parse(id));
            Event = await _context.Events.Include(s => s.Organizer).FirstOrDefaultAsync(m => m.ID == Int32.Parse(id));
            req = "get";
        }

        public async Task OnPostAsync(string id)
        {
            Attendee = await _context.Attendees.FirstOrDefaultAsync();
            Event = await _context.Events.Include(s => s.Organizer).FirstOrDefaultAsync(m => m.ID == Int32.Parse(id));
            RegisterToEvent.Register(_context, Attendee.ID, Event.ID);
            req = "post";
        }
    }
}
