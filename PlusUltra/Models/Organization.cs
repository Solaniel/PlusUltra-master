namespace PlusUltra.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Organization
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "OrganizationId is required")]
        [Display(Name = "Organization ID")]
        public int OrganizationId { get; set; }

        [Required(ErrorMessage = "Organization name is required")]
        [Display(Name = "Organization name")]
        public string Name { get; set; }

    }
}