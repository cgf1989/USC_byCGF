using BCP.Domain.Edmx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.Domain
{
    /// <summary>
    /// WorkMessage 基于EF的仓储实现
    /// </summary>
    public class WorkMessageRepository : EFRepository<WorkMessage, Int32>,IWorkMessageRepository
    {
    }
}
