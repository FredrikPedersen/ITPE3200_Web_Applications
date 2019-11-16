using Microsoft.EntityFrameworkCore;
using VyCustomerSupport.Models.DbModels;

namespace VyCustomerSupport.DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            
        }
        
        public DbSet<DbQa> QandAs { get; set; }
        public DbSet<DbCategory> Categories { get; set; }
        public DbSet<DbUserQuestion> UserQuestions { get; set; }
    }
}