using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace M33.Models.DB
{

    public class Tag : ITrackable
    {
        public int Id { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }
        [MaxLength(4096)]
        public string Description { get; set; }

        [MaxLength(255)]
        public string ImageUrl { get; set; }
        [MaxLength(32)]
        public string Slug { get; set; }

        public string ApplicationUserID { get;set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public ICollection<ItemTag> ItemTags { get; set; }

        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public string LastUpdatedBy { get; set; }

    }

}