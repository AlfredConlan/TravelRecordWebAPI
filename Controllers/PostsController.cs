using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TravelRecordDataAccess;

namespace AzureWebAPI.Controllers
{
    //[Authorize]
    [RoutePrefix("api/Posts")]

    public class PostsController : ApiController
    {
        //This method will return All Posts' list
        public IEnumerable<Post> Get()
        {
            using (TravelRecordWebAPI_dbEntities entities = new TravelRecordWebAPI_dbEntities())
            {
                return entities.Posts.ToList();
            }
        }

        //This method will return a single Post against id 
        public Post Get(int id)
        {
            using (TravelRecordWebAPI_dbEntities entities = new TravelRecordWebAPI_dbEntities())
            {
                return entities.Posts.FirstOrDefault(e => e.Id == id);
            }
        }

        //This method will add a new Post  
        public void POST(Post post)
        {
            using (TravelRecordWebAPI_dbEntities entities = new TravelRecordWebAPI_dbEntities())
            {
                entities.Posts.Add(post);
                entities.SaveChanges();
            }

        }

        //This method to Update a Post  
        public void PUT(int id, Post post)
        {
            using (TravelRecordWebAPI_dbEntities entities = new TravelRecordWebAPI_dbEntities())
            {
                var Post1 = entities.Posts.Find(id);


                Post1.Experience = post.Experience;
                Post1.VenueName = post.VenueName;
                Post1.CategoryId = post.CategoryId;
                Post1.CategoryName = post.CategoryName;
                Post1.Latitude = post.Latitude;
                Post1.Longitude = post.Longitude;
                Post1.Address = post.Address;
                Post1.Distance = post.Distance;


                entities.Entry(Post1).State = System.Data.Entity.EntityState.Modified;
                entities.SaveChanges();
            }
        }

        //This method will delete a Post  
        public string Delete(int id)
        {
            using (TravelRecordWebAPI_dbEntities entities = new TravelRecordWebAPI_dbEntities())
            {
                Post post = entities.Posts.Find(id);
                entities.Posts.Remove(post);
                entities.SaveChanges();
                return "Customer Deleted";
            }

        }

    }
}