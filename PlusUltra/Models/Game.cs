namespace PlusUltra.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Game
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "OrganizationId is required")]
        [Display(Name = "Organization ID")]
        public int OrganizationId { get; set; }

        [Required(ErrorMessage = "Game number is required")]
        [Display(Name = "Game number")]
        public int GameNumber { get; set; }

        [Required(ErrorMessage = "Game name must be specified"),
            StringLength(50)]
        [Display(Name = "Game name")]
        public string GameName { get; set; }

    }
}