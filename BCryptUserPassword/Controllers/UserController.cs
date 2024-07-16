using BusinessLayer.Interface;
using BusinessLayer.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Models.Entity;
using RepositoryLayer.Interface;
using RepositoryLayer.Repository;

namespace BCryptUserPassword.Controllers
{
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserBLL _userBLL;
        public UserController(IUserBLL userBLL)
        {
            _userBLL=userBLL;
        }
        [HttpPost]
        [Route("SignUp")]
        public User SignUp([FromBody]User user)
        {
            return _userBLL.SignUp(user);
        }
        [HttpPost]
        [Route("Login")]
        public User Login([FromBody] User user)
        {
            return _userBLL.Login(user);
        }
        [HttpGet]
        [Route("GetAllUser")]
        public IEnumerable<User> GetAllUser()
        {
            return _userBLL.GetAllUser();
        }
        [HttpPost]
        [Route("GetByEmail/{email}")]
        public User GetByEmail(string email)
        {
            return _userBLL.GetByEmail(email);
        }
        [HttpPost]
        [Route("GetById/{id}")]
        public User GetById(int id)
        {
            return _userBLL.GetById(id);
        }
    }
}
