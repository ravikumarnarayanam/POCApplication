using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using POCApplication.DatabaseContext;
using POCApplication.Models;
using System.Collections;
using System.Reflection.Metadata;
using System.Reflection;
using System;

namespace POCApplication.Repository
{
    public class TaxRepository : ITaxDetails
    {
        private readonly ApplicationDbContext _appDBContext;
        public TaxRepository(ApplicationDbContext context)
        {
            _appDBContext = context ??
                throw new ArgumentNullException(nameof(context));
        }
        public bool DeleteTaxDetails(int id)
        {
            bool result = false;
            var taxdetails = _appDBContext.TaxDetails.Find(id);
            if (taxdetails != null)
            {
                _appDBContext.Entry(taxdetails).State = EntityState.Deleted;
                _appDBContext.SaveChanges();
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        public IEnumerable<TaxDetails> GetAllTaxDetails()
        {
            return _appDBContext.TaxDetails.ToList();
        }

        public IEnumerable<TaxDetails> GetTaxDetailsByFY(string FinanYear)
        {
            return _appDBContext.TaxDetails.Where(x => x.FinancialYear == FinanYear).ToList();
        }

        public async Task<TaxDetails> InsertTaxDetails(TaxDetails td)
        {
            _appDBContext.TaxDetails.Add(td);
            await _appDBContext.SaveChangesAsync();
            return td;
        }

        //public EmpTaxCalculation TaxCalculation(int EmpId)
        //{

        //    Employee emp = _appDBContext.Employee.Where(x => x.EmployeeId == EmpId).FirstOrDefault();

        //    int EmpSalary = emp.SalaryPerMonth;

        //    DateTime DOJ = emp.DOJ;

        //    DateTime endDate = new DateTime(2023, 03, 31);

        //    TimeSpan duration = endDate.Subtract(DOJ);

        //    int months = duration.Days / 30;
        //    float AnnualSalary = (months / 12) * EmpSalary;

        //    float totalTax = CalculateIncomeTax(AnnualSalary);

        //    EmpTaxCalculation ET = new EmpTaxCalculation();

        //    ET.FirstName = emp.FirstName;
        //    ET.LastName = emp.LastName;
        //    ET.DOJ = DOJ;
        //    ET.AnnualSalary = AnnualSalary;
        //    ET.TotalTax = totalTax;
        //    ET.CessAmount = CalculateCessAmount(AnnualSalary, totalTax);


        //    return ET;


        //}

        public float CalculateCessAmount(float AnnualSalary, float totalTax)
        {
            float cessTax = 0;

            if (AnnualSalary > 2500000)
            {
                cessTax = (AnnualSalary - 2500000) * 2 / 100;
                // return cessTax;
            }
            return cessTax;
        }

        public float CalculateIncomeTax(float taxableIncome)
        {
            float taxAmount = 0;

            if (taxableIncome <= 250000)
            {
                // No tax
                return taxAmount;
            }
            else if (taxableIncome > 250000 & taxableIncome <= 50000)
            {
                // Apply 5 % tax rate for income up to 50,000
                taxAmount = (taxableIncome - 250000) * (5/100);
            }
            else if (taxableIncome > 500000 & taxableIncome <= 1000000)
            {
                // Apply 10% tax rate for income between 2.5 to 5 lakhs
                // taxAmount = (250000 * (5/100)) + (taxableIncome-500000) * (10/100);

                float t1 = (250000 * 5) / 100;
                float t2 = (taxableIncome - 500000);
                float t3= t2 * 10/100;

                taxAmount = t1 + t3;


            }
            else if (taxableIncome > 1000000)
            {
                // Apply 30% tax rate for income above $100,000
                //taxAmount = (250000 * (5 / 100)) + (500000 * (10 / 100)) + ((taxableIncome - 750000) * (20 / 100));

                float t1 = (250000 * 5) / 100;
                float t2 = (500000 * 10) / 100;
                float t3 = taxableIncome - 750000;

                float t4 = t3 * 20 / 100;

                taxAmount = t1 +t2+ t4;
            }

            return taxAmount;
        }



        public async Task<TaxDetails> UpdateTaxDetails(TaxDetails td)
        {
            _appDBContext.Entry(td).State = EntityState.Modified;
            await _appDBContext.SaveChangesAsync();
            return td;
        }

       public  EmpTaxCalculation TaxCalculation(int EmpId)
        {
            Employee emp = _appDBContext.Employee.Where(x => x.EmployeeId == EmpId).FirstOrDefault();

            int EmpSalary = emp.SalaryPerMonth;
            float AnnualSal = 0;
            DateTime DOJ = emp.DOJ;
            DateTime endDate = new DateTime(2023, 03, 31);
            TimeSpan duration = endDate.Subtract(DOJ);

            int months = duration.Days / 30;

            if (months <= 12)
            {
                AnnualSal = months * EmpSalary;
            }
            else { 
                AnnualSal = 12 * EmpSalary;
            }

            float totalTax = CalculateIncomeTax(AnnualSal);

            EmpTaxCalculation ET = new EmpTaxCalculation();

            ET.FirstName = emp.FirstName;
            ET.LastName = emp.LastName;
            ET.DOJ = emp.DOJ;
            ET.EmployeeId= emp.EmployeeId;
            ET.Email = emp.Email;
            ET.AnnualSalary = AnnualSal;
            ET.TotalTax = totalTax;
            ET.CessAmount = CalculateCessAmount(AnnualSal, totalTax);


            return ET;
        }
    }
}
