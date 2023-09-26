using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace HWRESTAPIS.Models {
    public class CustomerModel {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(70)]
        [Required]
        public string? CustFullName { get; set; }

        [Phone]
        [StringLength(15)]
        public string? Contact { get; set; }


        [Required]
        [EmailAddress]
        [StringLength(70)]
        public string? Email { get; set; }

    }
}
