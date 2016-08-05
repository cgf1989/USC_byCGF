using BCP.Domain.Edmx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.Domain
{
    /// <summary>
    /// WorkSpaceBaseType 基于EF的仓储实现
    /// </summary>
    public class WorkSpaceBaseTypeRepository : EFRepository<WorkSpaceBaseType, Int32>,IWorkSpaceBaseTypeRepository
    {
    }
}
