using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EventApp.Data;
using EventApp.Models;

namespace EventApp.Pages
{
    public class MyEventsModel : PageModel
    {
        private readonly EventApp.Data.EventContext _context;

        public MyEventsModel(EventApp.Data.EventContext context)
        {
            _context = context;
        }
        public Attendee User { get; set; }

        public IList<AttendeeEvent> Events { get;set; }

        public async Task OnGetAsync()
        {
            User = await _context.Attendees.FirstOrDefaultAsync();
            Events = await _context.AttendeeEvent.Include(s => s.Event).ThenInclude(o => o.Organizer).Where(a => a.AttendeeId == User.ID).ToListAsync();
        }
    }
}
