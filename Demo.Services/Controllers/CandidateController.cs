using Demo.Entities;
using Demo.Repository;
using Demo.Services.Infrastructure;
using Demo.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Demo.Services.Controllers
{
    [CustomExceptionFilter]
    [CustomActionFilter]
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/v1/candidate")]
    public class CandidateController : ApiController
    {
        ICandidateRepository candidateRepository;
        /// <summary>
        /// Create new instance of <see cref="CandidateController"/>
        /// </summary>
        /// <param name="repository">the candidate repository.</param>
        public CandidateController(ICandidateRepository repository)
        {
            if (repository == null)
                throw new ArgumentNullException(nameof(repository));

            this.candidateRepository = repository;
        }

        /// <summary>
        /// Get Candidate by Given ID
        /// </summary>
        /// <param name="id">the ID.</param>
        /// <returns>return the candidate.</returns>
        [Route("{id}")]
        [HttpGet]
        public Candidate GetById(int id)
        {
            return this.candidateRepository.GetById(id);
        }

        /// <summary>
        /// Get all Candidates
        /// </summary>
        /// <returns>list of all Candidates</returns>
        [Route("items")]
        [HttpGet]
        public ResponseModel GetAll()
        {
            var result = this.candidateRepository
                             .GetAllEntities()
                             .Select(d=> new
                             {
                                 Id = d.Id,
                                 Name = d.Name,
                                 Salary = d.Salary,
                                 MostRecentEmployment = d.MostRecentEmployment,
                                 CurrentLocation = d.CurrentLocation,
                             }).ToList();
           
            ResponseModel response = new ResponseModel(result);
            response.Total = result.Count();
            return response;
        }
    }

   
}