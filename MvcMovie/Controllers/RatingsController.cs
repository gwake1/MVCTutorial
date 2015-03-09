using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using System.Data.Entity;
using MvcMovie.Models;
using Microsoft.AspNet.Identity;

namespace MvcMovie.Controllers
{
    public class RatingsController: Controller
    {
        private RatingContext repo;
        private MovieDBContext repo_Movie;
        public RatingsController(){
        repo = new RatingContext();
        repo.Ratings.Load();
        repo_Movie = new MovieDBContext();
        repo_Movie.Movies.Load();
        }

        public int AverageMovieRating(string MovieTitle)
        {
         var query = (from rating in repo.Ratings
                     where rating.MovieTitle == MovieTitle
                     select rating.Rating).Average();
         return int.Parse(query.ToString());
        }
        public void AddRating(string MovieTitle, int Rating)
        {
            var query = from rating in repo.Ratings
                        where rating.MovieTitle == MovieTitle
                        where rating.User == User.Identity.GetUserId()
                        select rating;
            if (query.First() != null)
	            {
		            rating temp = new rating();
                    temp.User = User.Identity.GetUserId();
                    temp.MovieTitle = MovieTitle;
                    temp.Rating = Rating;
                    repo.Ratings.Add(temp);
                    repo.SaveChanges();
                }
            else
            {
                rating temp = query.First();
                temp.Rating = Rating;
                repo.SaveChanges();
            }
        }
    }

}