using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace M33.Models.DB
{
    public class Image : ITrackable
    {
        [Column(Order = 1)]
        public int Id { get; set; }
        [Column(Order = 2)]
        [MaxLength(255)]
        public string Name { get; set; }
        [Column(Order = 3)]
        [MaxLength(255)]
        public string Filename { get; set; }

        [Column(Order = 4)]
        public string ApplicationUserID { get;set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Column(Order = 5)]
        public DateTime CreatedAt { get; set; }
        [Column(Order = 6)]
        public string CreatedBy { get; set; }
        [Column(Order = 7)]
        public DateTime LastUpdatedAt { get; set; }
        [Column(Order = 8)]
        public string LastUpdatedBy { get; set; }
    }
}