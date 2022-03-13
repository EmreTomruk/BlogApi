using Blog.Data.Repository.Abstract;
using Blog.Models.Entities;
using Blog.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IUserRepository _repository;

        public UserService(IUnitOfWork unitOfWork, IUserRepository repository)
        { 
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public User Authenticate(string userName, string password)
        {
            var user = _repository.Authenticate(userName, password);

            return user;
        }

        public async Task<bool> IsUniqueUser(string userName)
        {
            return await _repository.IsUniqueUser(userName);
        }

        public async Task<User> Register(string userName, string password)
        {
            var user = await _repository.Register(userName, password);
            await _unitOfWork.SaveAsync();

            return user;
        }
    }
}
