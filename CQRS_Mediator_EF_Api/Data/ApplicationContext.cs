using CQRS_Mediator_EF_Api.Model;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Mediator_EF_Api.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> User { get; set; }
    }
}
