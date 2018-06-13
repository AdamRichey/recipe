using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Plate.Models
{
    public class Personvm : BaseEntity
    {
        [Required]
        public string First { get; set; }
        [Required]
        public string Last { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
        [Required]
        [CompareAttribute("Password")]
        public string CPassword { get; set; }
    }
}