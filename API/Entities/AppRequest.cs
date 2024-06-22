using System;
using System.ComponentModel.DataAnnotations;
using API.Validators;
namespace API.Entities
{
    public class AppRequest
    {
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 100)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Request Due Date")]
        [FutureDate]
        public DateTime DueDate { get; set; }

    }
}