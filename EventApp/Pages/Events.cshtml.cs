﻿using System;
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
    public class EventsModel : PageModel
    {
        private readonly EventApp.Data.EventContext _context;

        public EventsModel(EventApp.Data.EventContext context)
        {
            _context = context;
        }

        public IList<Event> Event { get;set; }

        public async Task OnGetAsync()
        {
            Event = await _context.Events.ToListAsync();
        }
    }
}
