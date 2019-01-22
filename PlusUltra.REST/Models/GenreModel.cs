using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PlusUltraDB.Entities;

namespace PlusUltra.REST.Models
{
    public class GenreModel
    {
            public int Id { get; set; }

            public int GenreNumber { get; set; }

            public string GName { get; set; }

            public string Description { get; set; }

        public GenreModel()
        {

        }

        /// <summary>
        /// A constructor that uses the Entity Genre and the variable genre to set the
        /// model's variable to the same values as the entity's variables
        /// </summary>
        /// <param name="genre">The variable that is called when we get use this constructor
        /// to be used later when we call the CopyToEntity method
        /// </param>
        public GenreModel(Genre genre)
        {
            this.Id = genre.Id;
            this.GenreNumber = genre.GenreNumber;
            this.GName = genre.GName;
            this.Description = genre.Description;
        }

        /// <summary>
        /// A method that copies the values from the variables from the model to a new object in the Entity
        /// </summary>
        /// <param name="dbGenre">The paramater that will have the same values as the model one </param>
        public void CopyToEntity(Genre dbGenre)
        {
            dbGenre.GenreNumber = this.GenreNumber;
            dbGenre.GName = this.GName;
            dbGenre.Description = this.Description;
        }
    }
}