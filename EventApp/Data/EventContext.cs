using EventApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventApp.Data
{
    public class EventContext : DbContext
    {
        public EventContext(DbContextOptions<EventContext> options) 
            :base(options)
        { 
        }

        public DbSet<Attendee> Attendees { get; set; }
        public  DbSet<Event> Events { get; set; }
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<AttendeeEvent> AttendeeEvent { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AttendeeEvent>()
                .HasKey(bc => new { bc.AttendeeId, bc.EventId });

            modelBuilder.Entity<AttendeeEvent>()
                .HasOne(bc => bc.Attendee)
                .WithMany(b => b.AttendeeEvent)
                .HasForeignKey(bc => bc.AttendeeId);

            modelBuilder.Entity<AttendeeEvent>()
                .HasOne(bc => bc.Event)
                .WithMany(c => c.AttendeeEvent)
                .HasForeignKey(bc => bc.EventId);
        }

    }
}
