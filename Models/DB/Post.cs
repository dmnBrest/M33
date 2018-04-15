using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace M33.Models.DB
{

    public class Post : ITrackable
    {
        [Column(Order = 1)]
        public int Id { get; set; }
        [Column(Order = 2)]
        public string Title { get; set; }
        [Column(Order = 3)]
        public string Body { get; set; }
        [Column(Order = 4)]
        public string BodyHtml { get; set; }

        [Column(Order = 5)]
        public string ApplicationUserID { get;set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Column(Order = 6)]
        public DateTime CreatedAt { get; set; }
        [Column(Order = 7)]
        public string CreatedBy { get; set; }
        [Column(Order = 8)]
        public DateTime LastUpdatedAt { get; set; }
        [Column(Order = 9)]
        public string LastUpdatedBy { get; set; }

    }

}