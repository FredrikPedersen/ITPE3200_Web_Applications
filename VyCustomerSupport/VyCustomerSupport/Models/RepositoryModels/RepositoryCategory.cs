using System.ComponentModel.DataAnnotations;

namespace VyCustomerSupport.Models.RepositoryModels
{
    public class RepositoryCategory
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string CategoryName { get; set; }
    }
}