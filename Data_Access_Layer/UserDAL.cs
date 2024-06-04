using LoginAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace Data_Access_Layer
{
    public class UserDAL
    {

        public List<User> GetAllUsers()
        {
            var db = new UserContext();
            return db.Users.ToList();
        }

        public User GetUser(int id)
        {
            var db = new UserContext();
            User user = db.Users.FirstOrDefault(x => x.Id == id);
            return user;
        }
        public void PostUser(User user)
        {
            var db = new UserContext();
            db.Add(user);
            db.SaveChanges();
        }

        public User UpdateUser(User user)
        {
            var db = new UserContext();
            User currentuser = db.Users.FirstOrDefault(x => x.Id == user.Id);
            if (currentuser != null) 
            {
                currentuser.Username = user.Username;
                currentuser.PasswordHash = user.PasswordHash;
            } 
            
            db.SaveChanges();
            return user;

        }
        public void deleteUser(int id)
        {
            var db = new UserContext();
            User user = db.Users.Find(id);
            db.Remove(user);
            db.SaveChanges();
        }
    }
}
