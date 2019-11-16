using Microsoft.EntityFrameworkCore;
using VyCustomerSupport.Models.DbModels;

namespace VyCustomerSupport.DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            
        }
        
        public DbSet<DbQa> QandA { get; set; }
        public DbSet<DbUserQuestion> UserQuestions { get; set; }
    }
}