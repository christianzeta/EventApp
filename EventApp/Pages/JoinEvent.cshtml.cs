using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EventApp.Data;
using Microsoft.AspNetCore.Identity;

namespace EventApp.Pages
{
    public class JoinEventModel : PageModel
    {
        private readonly Data.EventContext _context;
        private readonly UserManager<MyUser> _userManager;

        public JoinEventModel(Data.EventContext context, UserManager<MyUser> userManager)
        {
            _context = context;
            _userManager = userManager;
          
        }

        public Event Event { get; set; }
        public string req { get; set; }

        public async Task OnGetAsync(string id)
        {
            Event = await _context.Events.FirstOrDefaultAsync(m => m.ID == Int32.Parse(id));
            req = "get";
        }

        public async Task OnPostAsync(string id)
        {
            var user = await _userManager.GetUserAsync(User);
            Event = await _context.Events.Include(s => s.MyUsers).FirstOrDefaultAsync(m => m.ID == Int32.Parse(id));
            Event.MyUsers.Add(user);
            _context.SaveChanges();
            
            req = "post";
        }
    }
}
