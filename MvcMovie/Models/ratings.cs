using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcMovie.Models
{
    public class rating
    {
        public String MovieTitle { get; set; }
        public String User { get; set; }

        [Range(1,5)]
        public int Rating { get; set; }
    }
    public class RatingContext : DbContext
    {
        public DbSet<rating> Ratings
        { get; set; }
    }
    
}