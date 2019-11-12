using System.ComponentModel.DataAnnotations;

namespace VyCustomerSupport.Models.RepositoryModels
{
    public class RepositoryQuestion
    {
        [Required]
        public string Question { get; set; }
        
        [Required]
        public string Username { get; set; }
    }
}