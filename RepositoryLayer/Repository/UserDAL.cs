using Models.Models.Entity;
using RepositoryLayer.Contexts;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository
{
    public class UserDAL : IUserDAL
    {
        private readonly UserContext _context;

        public UserDAL(UserContext context)
        {
            //_context = _context ?? throw new ArgumentNullException("");
            _context = context;
        }
        public User SignUp(User user) 
        {
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            _context.Users.Add(user);
         
            return user;
        }
        public User Login(User user)
        {
            var currentUser = _context.Users.FirstOrDefault(u => u.Email.Equals(user.Email));
            bool isValidPassword = BCrypt.Net.BCrypt.Verify(user.Password,currentUser.Password);
            if (isValidPassword)
            {
                return user;
            }
            return null;
        }

        public IEnumerable<User> GetAllUser()
        {
            return _context.Users.ToList();
        }

        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(user=>user.Id.Equals(id));
        }

        public User GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(user => user.Email.Equals(email));
        }
    }
}
