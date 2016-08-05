using BCP.Domain.Edmx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.Domain
{
    /// <summary>
    /// Post 基于EF的仓储实现
    /// </summary>
    public class PostRepository : EFRepository<Post, Int32>,IPostRepository
    {
    }
}
