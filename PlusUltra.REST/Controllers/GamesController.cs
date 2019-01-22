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
    public class GamesController : ApiController
    {
        private readonly PlusUltraDbContext db = new PlusUltraDbContext();
        private readonly UnitOfWork uow;
        



        public GamesController()
        {
            uow = new UnitOfWork(new PlusUltraDbContext());
        }
        

        /// <summary>
        /// Calls an HTTP Get method that uses a list of all games, accessed by the GameModel
        /// creates a new list with every game in it
        /// </summary>
        /// <returns>A list with all games on the database</returns>
        [HttpGet]      
        public List<GameModel> Get()
        { 
            var allGames = uow.GameRepository.GetAll()
                .Select(c => new GameModel(c))
                .ToList();
            return allGames;
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

            Game game = uow.GameRepository.GetById(id);
            if (game == null)
                return BadRequest($"Could not find book with ID:{id}");

            GameModel apiGame = new GameModel(game);
            return Ok(apiGame);

        }

        /// <summary>
        /// Calls an HTTP Post method that creates a new entity in the database
        /// </summary>
        /// <param name="game"></param>
        /// <returns>Returns an http result(OK) with the new game created</returns>
        [HttpPost]
        public IHttpActionResult Post(GameModel game)
        {
            try
            {
                Game dbGame = new Game();
                game.CopyToEntity(dbGame);

                GameModel newGame = new GameModel(dbGame);
                uow.GameRepository.Save(dbGame);
                return Ok(newGame);


            }
            catch(Exception ex)
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
        public IHttpActionResult Put(GameModel game)
        {
            Game dbGame = uow.GameRepository.GetById(game.Id);

            game.CopyToEntity(dbGame);
            uow.GameRepository.PromoteOrDemote(dbGame);
            uow.GameRepository.Save(dbGame);

            return Ok(dbGame);
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

                Game dbGame = uow.GameRepository.GetById(id);
                if (dbGame == null)
                    return NotFound();

                uow.GameRepository.DeleteByID(id);


                return StatusCode(HttpStatusCode.NoContent);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

       

    }
}
