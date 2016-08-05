using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.Common
{
    public interface IRepository<TEntity, Tld> : IReadOnlyRepository<TEntity, Tld>
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        void Add(TEntity entity);

        /// <summary>
        /// 删除聚合
        /// </summary>
        /// <param name="entity"></param>
        void RemoveCascaded(TEntity entity);

        /// <summary>
        /// 非级联删除
        /// </summary>
        /// <param name="entity"></param>
        void RemoveNonCascaded(TEntity entity);

        /// <summary>
        /// 删除聚合
        /// </summary>
        /// <param name="t"></param>
        void RemoveCascaded(Tld t);

        /// <summary>
        /// 非级联删除
        /// </summary>
        /// <param name="t"></param>
        void RemoveNonCascaded(Tld t);

        /// <summary>
        /// 修改聚合
        /// </summary>
        /// <param name="entity"></param>
        void Save(TEntity entity);

        /// <summary>
        /// 获取聚合（包括导航属性）
        /// </summary>
        /// <param name="includes">导航属性 Position/Position.Department</param>
        /// <returns></returns>
        IQueryable<TEntity> GetAllWithNavigationalProperty(params String[] includes);
    }
}
