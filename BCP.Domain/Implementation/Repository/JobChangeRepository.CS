using BCP.Domain.Edmx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.Domain
{
    /// <summary>
    /// JobChange 基于EF的仓储实现
    /// </summary>
    public class JobChangeRepository : EFRepository<JobChange, Int32>,IJobChangeRepository
    {
    }
}
