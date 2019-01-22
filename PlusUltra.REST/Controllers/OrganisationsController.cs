using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PlusUltraDB.Entities;
using PlusUltra.DataAccess;
using PlusUltra.DataAccess.Repositories;
using PlusUltra.REST.Models;

namespace PlusUltra.REST.Controllers
{
    public class OrganisationsController : ApiController
    {
        private readonly PlusUltraDbContext db = new PlusUltraDbContext();
        private readonly UnitOfWork uow;




        public OrganisationsController()
        {
            uow = new UnitOfWork(new PlusUltraDbContext());
        }

        /// <summary>
        /// Calls an HTTP Get method that uses a list of all organisations, accessed by the GenreModel
        /// creates a new list with every organisation in it
        /// </summary>
        /// <returns>A list with all genre on the database</returns>
        [HttpGet]
        public List<OrganisationModel> Get()
        {
            var allOrgs = uow.OrganizationRepository.GetAll()
                .Select(c => new OrganisationModel(c))
                .ToList();
            return allOrgs;
        }

        /// <summary>
        /// Calls an HTTP Get method that searches by ID through all entities and finds the right one
        /// returns a Bad Request when the searched ID is not in the database
        /// </summary>
        /// <param name="id">The ID that we use to search by</param>
        /// <returns>An object with the same ID as the parameter</returns>
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            if (id == null)
                return BadRequest("The parameter id is empty");

            Organization org = uow.OrganizationRepository.GetById(id);
            if (org == null)
                return BadRequest($"Could not find book with ID:{id}");

            OrganisationModel apiOrg= new OrganisationModel(org);
            return Ok(apiOrg);

        }

        /// <summary>
        /// Calls an HTTP Post method that creates a new entity in the database
        /// </summary>
        /// <param name="genre"></param>
        /// <returns>Returns an http result(OK) with the new organisation created</returns>
        [HttpPost]
        public IHttpActionResult Post(OrganisationModel org)
        {
            try
            {
                Organization dbOrg = new Organization();
                org.CopyToEntity(dbOrg);

                OrganisationModel newOrg= new OrganisationModel(dbOrg);
                uow.OrganizationRepository.Save(dbOrg);
                return Ok(newOrg);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Calls an HTTP Put method that edits an entity, searching it by ID
        /// </summary>
        /// <param name="org"></param>
        /// <returns>Returns an http result(OK) with the current object edited </returns>
        [HttpPut]
        public IHttpActionResult Put(OrganisationModel org)
        {
            Organization dbOrg= uow.OrganizationRepository.GetById(org.Id);

            org.CopyToEntity(dbOrg);
            uow.OrganizationRepository.PromoteOrDemote(dbOrg);
            uow.OrganizationRepository.Save(dbOrg);

            return Ok(dbOrg);
        }

        /// <summary>
        /// Calls an HTTP Delete method that searches an entity in the database by ID
        /// and then deletes it
        /// </summary>
        /// <param name="id">The ID that we use to search by</param>
        /// <returns>A status code (204 No content)</returns>
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {

                Organization dbOrg= uow.OrganizationRepository.GetById(id);
                if (dbOrg == null)
                    return NotFound();

                uow.OrganizationRepository.DeleteByID(id);


                return StatusCode(HttpStatusCode.NoContent);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
