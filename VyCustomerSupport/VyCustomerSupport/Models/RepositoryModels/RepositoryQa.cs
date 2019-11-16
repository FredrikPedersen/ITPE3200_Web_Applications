using System.ComponentModel.DataAnnotations;

namespace VyCustomerSupport.Models.RepositoryModels
{
    public class RepositoryQa
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Question { get; set; }
        [Required]
        public string Answer { get; set; }
        [Required]
        public int UpVotes { get; set; }
        [Required]
        public int DownVotes { get; set; }
        
        public RepositoryCategory Category { get; set; }
    }
}