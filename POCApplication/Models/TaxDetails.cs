using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace POCApplication.Models
{
  
    public class TaxDetails
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Financial Year")]
        public string FinancialYear { get; set; }

        [Required]
        [Display(Name = "Tax Slab")]
        public string TaxSlab { get; set; }

        [Required]
        [Display(Name = "Tax Rate")]
        public int ?TaxRate { get; set;}



    }
}
