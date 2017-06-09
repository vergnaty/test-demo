using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Repository
{
    /// <summary>
    /// This interface rappresent the common access layer 
    /// </summary>
    /// <typeparam name="TEntity">the Entity</typeparam>
    /// <typeparam name="TKey">the Key of the Entity</typeparam>
    public interface IRepository<TEntity,TKey>
        where TEntity:class
    {
        /// <summary>
        /// Get all entities
        /// </summary>
        /// <returns>type of <see cref="IEnumerable{TEntity}"/></returns>
        IEnumerable<TEntity> GetAllEntities();

        /// <summary>
        /// Get Entity by given ID.
        /// </summary>
        /// <param name="id">the Id</param>
        /// <returns></returns>
        TEntity GetById(TKey id);
    }
}
