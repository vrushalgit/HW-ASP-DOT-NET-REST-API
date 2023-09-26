using HWRESTAPIS.Models;
using Microsoft.EntityFrameworkCore;

namespace HWRESTAPIS.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) { }
       
        public DbSet<CustomerModel> Customers { get; set; }
       
      
    }
}
