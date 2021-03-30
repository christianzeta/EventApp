using EventApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventApp.Data
{
    public class EventContext : IdentityDbContext<MyUser>
    {
        public EventContext(DbContextOptions<EventContext> options) 
            :base(options)
        { 
        }

        public  DbSet<Event> Events { get; set; }
        public DbSet<MyUser> MyUsers { get; set; }
    }
}
