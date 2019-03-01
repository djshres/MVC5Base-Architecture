using MVC5Base.Database;
using System;

namespace MVC5Base.Helper
{
    public partial class DbHelper : IDisposable
    {
        private readonly ApplicationDbContext _context;

        public DbHelper()
        {
            _context = new ApplicationDbContext();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
