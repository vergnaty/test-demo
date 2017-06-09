using Demo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Repository
{
    public interface ICandidateRepository : IRepository<Candidate,int>
    {
        //custom additional signatur 
    }
}
