using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace M33.Models.DB
{

    public class Item : ITrackable
    {
        [Column(Order = 1)]
        public int Id { get; set; }
        [Column(Order = 2)]
        [MaxLength(255)]
        public string Title { get; set; }
        [Column(Order = 3)]
        [MaxLength(4096)]
        public string Description { get; set; }

        [Column(Order = 4)]
        public string Images { get; set; }
        [MaxLength(32)]
        [Column(Order = 5)]
        public string Slug { get; set; }

        [Column(Order = 6)]
        public string ApplicationUserID { get;set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public ICollection<ItemTag> ItemTags { get; set; }

        [Column(Order = 7)]
        public DateTime CreatedAt { get; set; }
        [Column(Order = 8)]
        public string CreatedBy { get; set; }
        [Column(Order = 9)]
        public DateTime LastUpdatedAt { get; set; }
        [Column(Order = 10)]
        public string LastUpdatedBy { get; set; }

    }

    public class ItemTag
    {
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }

}
