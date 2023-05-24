using POCApplication.Models;

namespace POCApplication.Repository
{
    public interface ITaxDetails
    {
        IEnumerable<TaxDetails> GetAllTaxDetails();

        IEnumerable<TaxDetails> GetTaxDetailsByFY(string FinYear);

        Task<TaxDetails> InsertTaxDetails(TaxDetails td);

        Task<TaxDetails> UpdateTaxDetails(TaxDetails td);

       bool DeleteTaxDetails(int id);

       EmpTaxCalculation TaxCalculation(int EmpId);

    }
}
