using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class RatingsController
    {
        private RatingContext repo;
        public RatingsController(){
        repo = new RatingContext();
            repo.Ratings.Load();

        }

        public int AverageMovieRating(string MovieTitle)
        {
         var query = (from rating in repo.Ratings
                     where rating.MovieTitle == MovieTitle
                     select rating.Rating).Average();
         return int.Parse(query.ToString());
        }
    }

}