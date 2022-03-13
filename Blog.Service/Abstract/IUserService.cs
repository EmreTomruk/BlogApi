using Blog.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Abstract
{
    public interface IUserService 
    {
        Task<bool> IsUniqueUser(string userName);
        User Authenticate(string userName, string password);
        Task<User> Register(string userName, string password);
    }
}
