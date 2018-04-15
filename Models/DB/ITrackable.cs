using System;
using Microsoft.EntityFrameworkCore;

namespace M33.Models.DB
{
    public interface ITrackable
    {
        DateTime CreatedAt { get; set; }
        string CreatedBy { get; set; }
        DateTime LastUpdatedAt { get; set; }
        string LastUpdatedBy { get; set; }
    }
}