using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Repository.Exceptions
{
    public class DataNotFoundException : Exception
    {
        public DataNotFoundException(string id)
            : base($"Data not found with the following ID:{id}")
        { }
    }
}
