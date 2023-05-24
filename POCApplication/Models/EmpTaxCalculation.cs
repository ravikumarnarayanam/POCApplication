namespace POCApplication.Models
{
    public class EmpTaxCalculation
    {

        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DOJ { get; set; }
        public float AnnualSalary { get; set; }
        public float TotalTax { get; set; }
        public float CessAmount { get; set; }


    }
}
