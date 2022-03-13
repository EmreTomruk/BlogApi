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
    public class ArticleService : Services<Article>, IArticleService
    {
        public ArticleService(IUnitOfWork unitOfWork, IRepository<Article> repository) : base(unitOfWork, repository)
        {

        }
    }
}
