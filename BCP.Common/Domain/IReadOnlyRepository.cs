using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.Common
{
    public interface IReadOnlyRepository<TEntity,TId>
    {
        /// <summary>
        /// 返回实体的IQueryable集合
        /// </summary>
        /// <returns>返回实体的IQueryable集合</returns>
        IQueryable<TEntity> GetAll();
        /// <summary>
        /// 返回对应Id的实体,或者空值
        /// </summary>
        /// <returns>返回对应Id的实体,或者空值</returns>
        TEntity GetByKey(TId key);
        /// <summary>
        /// 
        /// </summary>
        IUnitOfWork UnitOfWork { get; set; }
    }
}
