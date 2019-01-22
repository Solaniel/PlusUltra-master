using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PlusUltraDB.Entities;

namespace PlusUltra.REST.Models
{
    public class GameModel
    {
        public int Id { get; set; }

        public int OrganizationId { get; set; }

        public int GameNumber { get; set; }

        public string GameName { get; set; }

        public GameModel()
        {

        }

        /// <summary>
        /// A constructor that uses the Entity Game and the variable game to set the
        /// model's variable to the same values as the entity's variables
        /// </summary>
        /// <param name="game">The variable that is called when we get use this constructor
        /// to be used later when we call the CopyToEntity method
        /// </param>
        public GameModel(Game game)
        {
            this.Id = game.Id;
            this.OrganizationId = game.OrganizationId;
            this.GameNumber = game.GameNumber;
            this.GameName = game.GameName;
        }

        /// <summary>
        /// A method that copies the values from the variables from the model to a new object in the Entity
        /// </summary>
        /// <param name="dbGame">The paramater that will have the same values as the model one </param>
        public void CopyToEntity(Game dbGame)
        {
            dbGame.OrganizationId = this.OrganizationId;
            dbGame.GameNumber = this.GameNumber;
            dbGame.GameName = this.GameName;
        }
    }
}