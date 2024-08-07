﻿using Models.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IUserBLL
    {
        User SignUp(User user);
        User Login(User user);
        IEnumerable<User> GetAllUser();
        User GetById(int id);
        User GetByEmail(string email);
    }
}
