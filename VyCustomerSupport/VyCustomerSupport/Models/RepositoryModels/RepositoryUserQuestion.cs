using System.ComponentModel.DataAnnotations;

namespace VyCustomerSupport.Models.RepositoryModels
{
    public class RepositoryUserQuestion
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string Username { get; set; }
        
        [Required]
        public string Email { get; set; }

        [Required]
        public string Question { get; set; }
    }
}