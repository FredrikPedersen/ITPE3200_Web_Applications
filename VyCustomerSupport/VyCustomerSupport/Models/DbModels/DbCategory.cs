using System.ComponentModel.DataAnnotations;

namespace VyCustomerSupport.Models.DbModels
{
    public class DbCategory
    {
        [Key]
        public int Id { get; set; }
        
        public string CategoryName { get; set; }
    }
}