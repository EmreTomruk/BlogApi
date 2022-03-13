using Blog.Data.Repository.Abstract;
using Blog.SharedTools;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Repository.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly IOptions<AppSettings> _appSettings;

        public UnitOfWork(ApplicationDbContext context, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings;
        }

        public ICategoryRepository Category => new CategoryRepository(_context);
        public IArticleRepository Article => new ArticleRepository(_context);
        public IUserRepository User => new UserRepository(_context/*, _appSettings*/);

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
