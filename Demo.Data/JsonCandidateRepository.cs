using Demo.Entities;
using Demo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data
{
    public class JsonCandidateRepository : JsonRepository<Candidate>, ICandidateRepository
    {
        /// <summary>
        /// Create new instance <see cref="JsonCandidateRepository"/>
        /// </summary>
        /// <param name="path">the json path.</param>
        public JsonCandidateRepository(string jsonFilepath)
            :base(jsonFilepath)
        {
        }
        //for a moment we dont need to implement nothing, unless there are new custom functionality to be implemented
    }
}
