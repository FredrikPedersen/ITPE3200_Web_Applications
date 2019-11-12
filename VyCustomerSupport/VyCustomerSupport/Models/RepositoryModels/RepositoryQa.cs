using System.ComponentModel.DataAnnotations;

namespace VyCustomerSupport.Models.RepositoryModels
{
    public class RepositoryQa
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public int UpVotes { get; set; }
        public int DownVotes { get; set; }
    }
}