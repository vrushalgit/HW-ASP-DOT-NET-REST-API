using System.ComponentModel.DataAnnotations;

namespace HWRESTAPIS.Models
{
    public class CustomerModel
{
    [Key]
    public int Id { get; set; }
    [Required] public string? CustFullName { get; set; }

    [Phone]
    public long Contact { get; set; }

    [EmailAddress]
    public string? Email { get; set; }

}
}
