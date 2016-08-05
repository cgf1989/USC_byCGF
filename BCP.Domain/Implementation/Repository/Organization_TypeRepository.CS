using BCP.Domain.Edmx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.Domain
{
    /// <summary>
    /// Organization_Type 基于EF的仓储实现
    /// </summary>
    public class Organization_TypeRepository : EFRepository<Organization_Type, Int32>,IOrganization_TypeRepository
    {
    }
}
