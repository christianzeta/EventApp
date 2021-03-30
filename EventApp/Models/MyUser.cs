using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventApp.Models
{
    public class MyUser : IdentityUser
    {
        public List<Event> Events { get; set; }
    }
}
