using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EventApp.Data;
using EventApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace EventApp.Pages
{
    [Authorize]
    public class MyEventsModel : PageModel
    {
        private readonly EventApp.Data.EventContext _context;
        private readonly UserManager<MyUser> _userManager;

        public MyEventsModel(EventApp.Data.EventContext context, UserManager<MyUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public MyUser MyUser { get; set; }

        public IList<Event> Events { get;set; }

        public async Task OnGetAsync()
        {
            MyUser = await _userManager.GetUserAsync(User);
            var UserEvent = await _context.MyUsers.Include(e => e.Events).FirstOrDefaultAsync(u => u.UserName == MyUser.UserName);
            Events = UserEvent.Events;
        }
    }
}
