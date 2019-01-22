namespace PlusUltra.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Genre
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Genre number is required")]
        [Display(Name = "Genre number")]
        public int GenreNumber { get; set; }

        [Required(ErrorMessage = "Game name must be specified"),
            StringLength(50)
            ]
        [Display(Name = "Game name")]
        public string GName { get; set; }

        [StringLength(100)]
        [Display(Name = "Description")]
        public string Description { get; set; }

    }
}