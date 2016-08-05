using BCP.Domain.Edmx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.Domain
{
    /// <summary>
    /// User_ContacTable 基于EF的仓储实现
    /// </summary>
    public class User_ContacTableRepository : EFRepository<User_ContacTable, Int32>,IUser_ContacTableRepository
    {
    }
}
