using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using PlusUltraDB.Entities;
using PlusUltra.SOAP.Models;
using PlusUltra.DataAccess;
using PlusUltra.DataAccess.Repositories;

namespace PlusUltra.SOAP
{
    /// <summary>
    /// Summary description for PlusUltra
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class PlusUltra : System.Web.Services.WebService
    {
        private readonly PlusUltraDbContext db = new PlusUltraDbContext();
        private readonly UnitOfWork uow;

        /// <summary>
        /// This constructor creates a new instance of unit of work when the web app is loaded
        /// </summary>
        public PlusUltra()
        {
            uow = new UnitOfWork(new PlusUltraDbContext());
        }

        /// <summary>
        /// Gets all games and sets them to a list
        /// </summary>
        /// <returns>All games in a list</returns>
        [WebMethod]
        public List<GameReturnModel> GetAllGames()
        {
            List<GameReturnModel> result = uow.GameRepository.GetAll()
                .Select(b => new GameReturnModel(b))
                .ToList();

            return result;
        }


        /// <summary>
        /// A web method that finds a game by ID and display it
        /// </summary>
        /// <param name="gameId">The ID we are searching by</param>
        /// <returns>The game found by the ID</returns>
        [WebMethod]
        public GameReturnModel GetGameById(int gameId)
        {
            Game dbGame = uow.GameRepository.GetById(gameId);
            if (dbGame == null)
                throw new Exception($"Couldn't find game with ID:{gameId}");
            GameReturnModel result = new GameReturnModel(dbGame);
            return result;
        }

        /// <summary>
        /// A web method that adds a game
        /// </summary>
        /// <param name="game"></param>
        /// <returns>A string that says the game is created</returns>
        [WebMethod]
        public string AddGame(GameAddModel game)
        {
            Game newGame = new Game();

            newGame.GameName = game.GameName;
            newGame.GameNumber = game.GameNumber;
            newGame.OrganizationId = game.OrganizationId;

            uow.GameRepository.Create(newGame);
            return "Game is created";
        }

        /// <summary>
        /// A web method that finds a game by ID and then deletes the found game
        /// </summary>
        /// <param name="gameId">The ID we are finding the game</param>
        /// <returns></returns>
        [WebMethod]
        public string DeleteGame(int gameId)
        {
            try
            {
                Game dbGame = uow.GameRepository.GetById(gameId);
                if (dbGame == null)
                    throw new Exception($"Couldn't find game with ID:{gameId}");

                uow.GameRepository.DeleteByID(gameId);
                return "Game was deleted";
                
            }
            catch (Exception ex)
            {
                return $"Failed to delete game with id={gameId}. Error: {ex.GetBaseException().Message}";
            }
        }
    }
}
