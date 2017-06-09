using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Entities
{
    public class Candidate : BaseEntity
    {
        /// <summary>
        /// Get or Set the Fullname
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Get or Set the Salary with the currency
        /// </summary>
        public string Salary { get; set; }
        /// <summary>
        /// Get or Set the Most Recent Employment
        /// </summary>
        public string MostRecentEmployment { get; set; }
        /// <summary>
        /// Get or Set Current Location
        /// </summary>
        public string CurrentLocation { get; set; }
        /// <summary>
        /// Get or Set the Skills 
        /// </summary>
        public string[] Skills { get; set; }
    }  
}
