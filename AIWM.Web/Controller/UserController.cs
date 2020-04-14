using System;
using System.Collections.Generic;
using AIWM.Database;
using AIWM.Model;
using Microsoft.AspNetCore.Mvc;

namespace AIWM.Web.Controller
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {

            return new string[] { "user1", "user2" };
        }

        // GET: api/User/5
        [HttpGet("id/{id}")]
        public string GetUserById(int id)
        {
            System.Diagnostics.Debug.WriteLine("controller");
            return "5";
           // return id.ToString();
        }
        
        
        [HttpGet("name/{name}")]
        public User GetUserByName(String name)
        {
            UserDao userDao = new UserDao();
            User foundUser = userDao.FindUserByName(name);
            return foundUser;
        }

        [HttpPost("login")]
        public bool LoginUser([FromBody] User user)
        {
            bool logIn = false;

            UserDao userDao = new UserDao();
            User foundUser = userDao.FindUserByName(user.Login);

            if (foundUser.Password.Equals(user.Password))
            {
                logIn = true;
            }

            return logIn;
        }
        /*
        // POST: api/User/5
        [HttpPost("add")]
        public String AddUser([FromBody] User newUser)
        {
            UserDao userDao = new UserDao();
            userDao.addUser(newUser);
            return "ok buy";
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}