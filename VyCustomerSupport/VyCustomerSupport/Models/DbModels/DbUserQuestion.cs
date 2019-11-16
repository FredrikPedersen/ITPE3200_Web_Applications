using System.ComponentModel.DataAnnotations;

namespace VyCustomerSupport.Models.DbModels
{
    public class DbUserQuestion
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        
        public string Email { get; set; }
        public string Question { get; set; }
    }
}