using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using M33.Models.DB;

namespace M33.Models.DB
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser, ITrackable
    {
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public string LastUpdatedBy { get; set; }
    }
}
