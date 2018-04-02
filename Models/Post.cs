using System;
using Microsoft.EntityFrameworkCore;
namespace M33.Models
{

    public class Post : ITrackable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }

        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public string LastUpdatedBy { get; set; }

    }

}