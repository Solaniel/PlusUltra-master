using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PlusUltraDB.Entities;

namespace PlusUltra.SOAP.Models
{   
    /// <summary>
    /// A class model that returns all fields of the game 
    /// and has a parameterless constructor + a constructor that sets a new
    /// entity from this model with the same values from the main entity
    /// </summary>
    public class GameReturnModel
    {
        public int Id { get; set; }
        public string GameName { get; set; }
        public int GameNumber { get; set; }
        public int OrganizationId { get; set; }
        public string ErrorMessage { get; set; }

        public GameReturnModel() { }

        public GameReturnModel(Game game)
        {
            this.Id = game.Id;
            this.GameName = game.GameName;
            this.GameNumber = game.GameNumber;
            this.OrganizationId = game.OrganizationId;
        }

    }
}