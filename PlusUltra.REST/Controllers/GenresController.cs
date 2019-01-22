using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PlusUltraDB.Entities;
using PlusUltra.DataAccess.Repositories;
using PlusUltra.DataAccess;
using PlusUltra.REST.Models;

namespace PlusUltra.REST.Controllers
{
    public class GenresController : ApiController
    {
        private readonly PlusUltraDbContext db = new PlusUltraDbContext();
        private readonly UnitOfWork uow;




        public GenresController()
        {
            uow = new UnitOfWork(new PlusUltraDbContext());
        }


        /// <summary>
        /// Calls an HTTP Get method that uses a list of all genres, accessed by the GenreModel
        /// creates a new list with every genre in it
        /// </summary>
        /// <returns>A list with all genre on the database</returns>
        [HttpGet]
        public List<GenreModel> Get()
        {
            var allGenres = uow.GenreRepository.GetAll()
                .Select(c => new GenreModel(c))
                .ToList();
            return allGenres;
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

            Genre genre = uow.GenreRepository.GetById(id);
            if (genre == null)
                return BadRequest($"Could not find book with ID:{id}");

            GenreModel apiGenre= new GenreModel(genre);
            return Ok(apiGenre);

        }

        /// <summary>
        /// Calls an HTTP Post method that creates a new entity in the database
        /// </summary>
        /// <param name="genre"></param>
        /// <returns>Returns an http result(OK) with the new genre created</returns>
        [HttpPost]
        public IHttpActionResult Post(GenreModel genre)
        {
            try
            {
                Genre dbGenre = new Genre();
                genre.CopyToEntity(dbGenre);

                GenreModel newGenre = new GenreModel(dbGenre);
                uow.GenreRepository.Save(dbGenre);
                return Ok(newGenre);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Calls an HTTP Put method that edits an entity, searching it by ID
        /// </summary>
        /// <param name="game"></param>
        /// <returns>Returns an http result(OK) with the current object edited </returns>
        [HttpPut]
        public IHttpActionResult Put(GenreModel genre)
        {
            Genre dbGenre= uow.GenreRepository.GetById(genre.Id);

            genre.CopyToEntity(dbGenre);
            uow.GenreRepository.PromoteOrDemote(dbGenre);
            uow.GenreRepository.Save(dbGenre);

            return Ok(dbGenre);
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

                Genre dbGenre = uow.GenreRepository.GetById(id);
                if (dbGenre == null)
                    return NotFound();

                uow.GenreRepository.DeleteByID(id);


                return StatusCode(HttpStatusCode.NoContent);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}