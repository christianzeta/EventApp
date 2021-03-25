﻿using EventApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventApp.Data
{
    public class DbInitializer
    {
            public static void Initialize(EventContext context)
            {
                context.Database.EnsureCreated();
                
                // Look for any students.
                if (context.Attendees.Any())
                {
                    return;   // DB has been seeded
                }

                var Attendees = new Attendee[]
                {
                new Attendee{Name="Christian",Email="Christian@gmail.com",PhoneNumber="0737471900"}
                };

                context.Attendees.AddRange(Attendees);
                context.SaveChanges();

                var Organizers = new Organizer[]
                {
                    new Organizer{Name="ZetaEvents",Email="ZEvents@gmail.com",PhoneNumber="0737471910"}
                };

                context.Organizers.AddRange(Organizers);
                context.SaveChanges();
                

                var Events = new Event[]
                {
                new Event{
                    Title="LightShow",
                    Description="Light Show", 
                    Place="The Sky",
                    Address="1134 The Sky City",
                    SpotsAvailable=20,
                    Date= DateTime.Parse("2021-09-10"),
                    OrganizerID=1
                },

                };

                context.Events.AddRange(Events);
                context.SaveChanges();
            }
        }
}
