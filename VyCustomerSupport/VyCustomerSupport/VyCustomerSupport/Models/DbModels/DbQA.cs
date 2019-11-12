using System.ComponentModel.DataAnnotations;

namespace VyCustomerSupport.Models.DbModels
{
    public class DbQA
    {
        [Key]
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}