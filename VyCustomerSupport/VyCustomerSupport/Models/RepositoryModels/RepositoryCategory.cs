using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VyCustomerSupport.Models.DbModels;

namespace VyCustomerSupport.Models.RepositoryModels
{
    public class RepositoryCategory
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string CategoryName { get; set; }
        
        public List<DbQa> CategoryItems { get; set; }
    }
}