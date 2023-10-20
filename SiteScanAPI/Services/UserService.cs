using Microsoft.AspNetCore.Mvc;
using SiteScanAPI.Model;

namespace SiteScanAPI.Services
{
    public interface IUserService
    {
        /// <summary>
        /// get list of all users
        /// </summary>
        /// <returns></returns>
        List<User> GetUsersList();

        /// <summary>
        /// get employee details by employee id
        /// </summary>
        /// <param name="empId"></param>
        /// <returns></returns>
        User GetUserDetailsById(string userEmail);

        /// <summary>
        ///  add edit employee
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        bool SaveUser(User userModel);


        /// <summary>
        /// delete users
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        bool DeleteUser(string userEmail);
    }

    public class UserService : IUserService
    {
        private SiteScanDBContext _context;
        public UserService(SiteScanDBContext context)
        {
            _context = context;
        }
        public bool DeleteUser(string userEmail)
        {

            var user = _context.Users.FirstOrDefault(x => x.Email == userEmail);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges(); // Call SaveChanges to persist the deletion to the database
                return true;
            }
            else
            {
                return false; // User not found, no deletion occurred
            }
        }

        public User GetUserDetailsById(string userEmail)
        {
            User user;
            try
            {
                user = _context.Users.FirstOrDefault(x => x.Email == userEmail);
            }
            catch (Exception)
            {
                throw;
            }
            return user;
        }

        public List<User> GetUsersList()
        {
            List<User> userList;
            try
            {
                userList = _context.Set<User>().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return userList;
        }

        public bool SaveUser(User userModel)
        {
            if (userModel != null)
            {
                _context.Add(userModel);
                _context.SaveChanges(); // Call SaveChanges to persist the deletion to the database
                return true;
            }
            else
            {
                return false; // User not found, no deletion occurred
            }
        }
    }
}
