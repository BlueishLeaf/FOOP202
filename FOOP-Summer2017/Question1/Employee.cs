using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question1
{
    public abstract class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PPS { get; set; }
        public Employee()
        {

        }
        public virtual decimal GetMonthlyPay()
        {
            return 0;
        }

        public virtual void GetPayslip()
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }
    }

    public class PartTimeEmployee : Employee
    {
        public double HourlyRate { get; set; }
        public double HoursWorked { get; set; }
        public override decimal GetMonthlyPay()
        {
            return Convert.ToDecimal(HoursWorked * HourlyRate);
        }

        public override void GetPayslip()
        {
            
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}",FirstName, LastName, "PT");
        }
    }

    public class FullTimeEmployee : Employee
    {
        public DateTime ReviewDate { get; set; }
        public decimal Salary { get; set; }
        public FullTimeEmployee()
        {

        }

        public override decimal GetMonthlyPay()
        {
            return Salary/12;
        }

        public override void GetPayslip()
        {

        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", FirstName, LastName, "FT");
        }
    }
}
