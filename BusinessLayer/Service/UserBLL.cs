using BusinessLayer.Interface;
using Models.Models.Entity;
using RepositoryLayer.Interface;
using RepositoryLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
    public class UserBLL : IUserBLL
    {
        private readonly IUserDAL _userDAL;
        public UserBLL(IUserDAL userDAL)
        {
            _userDAL = userDAL;
        }
        public IEnumerable<User> GetAllUser()
        {
            return _userDAL.GetAllUser();
        }

        public User GetByEmail(string email)
        {
            return _userDAL.GetByEmail(email);
        }

        public User GetById(int id)
        {
            return _userDAL.GetById(id);
        }

        public User Login(User user)
        {
            var currentUser = _userDAL.Login(user);
            if (currentUser == null) 
            {
                try
                {
                    throw new Exception("invalid user credentials");
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return currentUser;
        }

        public User SignUp(User user)
        {
            return _userDAL.SignUp(user);
        }
    }
}
