using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlusUltraDB.Entities
{
    public class Organization : BaseEntity
    {
        [Required(ErrorMessage = "OrganizationId is required")]
        [Display(Name = "Organization ID")]
        public int OrganizationId { get; set; }

        [Required(ErrorMessage = "Organization name is required")]
        [Display(Name = "Organization name")]
        public string Name { get; set; }
    }
}
