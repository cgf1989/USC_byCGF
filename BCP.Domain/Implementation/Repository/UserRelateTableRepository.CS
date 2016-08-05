using BCP.Domain.Edmx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.Domain
{
    /// <summary>
    /// UserRelateTable 基于EF的仓储实现
    /// </summary>
    public class UserRelateTableRepository : EFRepository<UserRelateTable, Int32>,IUserRelateTableRepository
    {
    }
}
