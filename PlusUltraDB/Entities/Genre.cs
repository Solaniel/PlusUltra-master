using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlusUltraDB.Entities
{
    public class Genre : BaseEntity
    {
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
