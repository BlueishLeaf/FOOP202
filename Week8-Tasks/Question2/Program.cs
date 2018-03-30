using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question2
{
    class Program
    {
        private readonly AdventureLiteEntities _db = new AdventureLiteEntities();
        public IEnumerable GetCustomers()
        {
            var validCustomers = _db.SalesOrderHeaders.Select(i => i.CustomerID).Distinct();
            return _db.Customers.Where(i => validCustomers.Contains(i.CustomerID)).Select(c => c.CompanyName).ToList();
        }

        public IEnumerable GetOrders(string customer)
        {
            var query = from so in _db.SalesOrderHeaders
                where so.Customer.CompanyName == customer
                select new
                {
                    Desc = $"{so.OrderDate.ToShortDateString()}{so.SalesOrderID}{so.TotalDue:C}"
                };
            return query.ToList();
        }
    }
}
