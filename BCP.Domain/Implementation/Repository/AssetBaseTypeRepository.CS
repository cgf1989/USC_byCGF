using BCP.Domain.Edmx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.Domain
{
    /// <summary>
    /// AssetBaseType 基于EF的仓储实现
    /// </summary>
    public class AssetBaseTypeRepository : EFRepository<AssetBaseType, Int32>,IAssetBaseTypeRepository
    {
    }
}
