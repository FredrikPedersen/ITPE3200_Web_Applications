using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VyCustomerSupport.Models.DbModels
{
    public class DbCategory
    {
        [Key]
        public int Id { get; set; }
        
        public string CategoryName { get; set; }
        
        public virtual  IList<DbQa> CategoryItems { get; set; }
    }
}