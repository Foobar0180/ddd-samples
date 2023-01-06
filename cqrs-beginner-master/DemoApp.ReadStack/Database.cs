using System;
using System.Linq;
using DemoApp.QueryStack.Model;

namespace DemoApp.QueryStack
{
    public class Database : IDisposable
    {
        private readonly QueryDbContext _context = new QueryDbContext();

        public IQueryable<Match> Matches => _context.Matches;

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}