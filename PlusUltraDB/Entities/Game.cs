using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlusUltraDB.Entities
{
    public class Game : BaseEntity
    {

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

