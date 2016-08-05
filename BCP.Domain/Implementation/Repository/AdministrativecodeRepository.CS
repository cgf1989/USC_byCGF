using BCP.Domain.Edmx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.Domain
{
    /// <summary>
    /// Administrativecode 基于EF的仓储实现
    /// </summary>
    public class AdministrativecodeRepository : EFRepository<Administrativecode, Int32>,IAdministrativecodeRepository
    {
    }
}
