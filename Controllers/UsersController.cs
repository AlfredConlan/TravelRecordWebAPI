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
    [RoutePrefix("api/Users")]

    public class UsersController : ApiController
    {
        //This method will return All Users' list
        public IEnumerable<User> Get()
        {
            using (TravelRecordWebAPI_dbEntities entities = new TravelRecordWebAPI_dbEntities())
            {
                return entities.Users.ToList();
            }
        }

        //This method will return a single User against id 
        public User Get(int id)
        {
            using (TravelRecordWebAPI_dbEntities entities = new TravelRecordWebAPI_dbEntities())
            {
                return entities.Users.FirstOrDefault(e => e.Id == id);
            }
        }

        //This method will add a new User  
        public void POST(User user)
        {
            using (TravelRecordWebAPI_dbEntities entities = new TravelRecordWebAPI_dbEntities())
            {
                entities.Users.Add(user);
                entities.SaveChanges();
            }

        }

        //This method to Update a User  
        public void PUT(int id, User user)
        {
            using (TravelRecordWebAPI_dbEntities entities = new TravelRecordWebAPI_dbEntities())
            {
                var User1 = entities.Users.Find(id);
                User1.Email = user.Email;
                User1.Password = user.Password;
                entities.Entry(User1).State = System.Data.Entity.EntityState.Modified;
                entities.SaveChanges();
            }
        }

        //This method will delete a User  
        public string Delete(int id)
        {
            using (TravelRecordWebAPI_dbEntities entities = new TravelRecordWebAPI_dbEntities())
            {
                User user = entities.Users.Find(id);
                entities.Users.Remove(user);
                entities.SaveChanges();
                return "Customer Deleted";
            }

        }

    }
}
