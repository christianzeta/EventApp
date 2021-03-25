using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventApp.Models;

namespace EventApp.Data
{
    public class RegisterToEvent
    {
        public static void Register(EventContext context, int attendeeId, int eventId)
        {
            context.Database.EnsureCreated();

            var AttendeeEvent = new AttendeeEvent
            {
               AttendeeId=attendeeId,
               EventId=eventId
            };

            context.AttendeeEvent.Add(AttendeeEvent);
            context.SaveChanges();
        }
    }
}

