using BCP.Domain.Edmx;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.Domain
{
    public class EFUnitOfWork : IEFUnitOfWork, IDisposable
    {
        private DbContext _dbContext = new DataContext();

        public DbContext DbContext
        {
            get { return _dbContext; }
        }

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public void RollBack()
        {
            _dbContext.ChangeTracker.Entries().ToList().ForEach(it => it.State = EntityState.Unchanged);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
