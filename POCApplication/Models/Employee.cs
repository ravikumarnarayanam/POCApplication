using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace POCApplication.Models
{
   
    public class Employee
    {
        [Required]
        [Display(Name = "EmployeeID")]
        public int EmployeeId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Date of Join")]
        public DateTime DOJ { get; set; }

        [Required]
        [Display(Name = "Salary Per Month")]
        public int SalaryPerMonth { get; set; }

    }
      

}

