using BCP.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.Domain
{
    public interface IEFUnitOfWork : IUnitOfWork
    {
        DbContext DbContext { get; }
    }
}
