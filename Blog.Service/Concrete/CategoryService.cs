using Blog.Data.Repository.Abstract;
using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Service.Abstract;

namespace Blog.Service.Concrete
{
    public class CategoryService : Services<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork, IRepository<Category> repository) : base(unitOfWork, repository)
        {

        }
    }
}
