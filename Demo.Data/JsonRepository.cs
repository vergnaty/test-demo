using Demo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.IO;
using Demo.Entities;
using Demo.Repository.Exceptions;
using System.Web;
using System.Net;

namespace Demo.Data
{
    public class JsonRepository<TEntity> : IRepository<TEntity, int>
         where TEntity : BaseEntity
    {
        /// <summary>
        /// Get Entities
        /// </summary>
        public IEnumerable<TEntity> Entities { get; private set; }

        /// <summary>
        /// Create new instance <see cref="JsonRepository"/>
        /// </summary>
        /// <param name="filePath"></param>
        public JsonRepository(string jsonFilepath)
        {
            if (string.IsNullOrEmpty(jsonFilepath))
                throw new ArgumentNullException(nameof(jsonFilepath));

            this.LoadData(jsonFilepath);
        }

        public virtual IEnumerable<TEntity> GetAllEntities()
        {
            return this.Entities;
        }

        public virtual TEntity GetById(int id)
        {
            var result = this.Entities.FirstOrDefault(d => d.Id == id);
            if (result == null)
                throw new DataNotFoundException(id.ToString());
            return result;
        }

        /// <summary>
        /// Load data by given json file path.
        /// </summary>
        /// <param name="fullPath">the file path.</param>
        private void LoadData(string fullPath)
        {
            if (!File.Exists(fullPath))
                throw new FileNotFoundException($"json file not found in the following path {fullPath}");

            string json = File.ReadAllText(fullPath);
            
            this.Entities = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<TEntity>>(json);
        }
    }
}
