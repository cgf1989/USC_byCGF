using BCP.Domain.Edmx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.Domain
{
    /// <summary>
    /// Organization_ContacTable 基于EF的仓储实现
    /// </summary>
    public class Organization_ContacTableRepository : EFRepository<Organization_ContacTable, Int32>,IOrganization_ContacTableRepository
    {
    }
}
