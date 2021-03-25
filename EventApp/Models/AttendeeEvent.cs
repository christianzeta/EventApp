﻿using EventApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventApp
{
    public class AttendeeEvent
    { 
        public int AttendeeId { get; set; }
        public Attendee Attendee { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        
    }
}
