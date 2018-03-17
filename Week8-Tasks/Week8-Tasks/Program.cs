using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week8_Tasks
{
    class Program
    {
        public enum StockLevel { Low, Normal, Overstocked }
        private NORTHWNDEntities _db = new NORTHWNDEntities();

        public IEnumerable GetSuppliers() => _db.Suppliers.Select(s => s.CompanyName).ToList();

        public IEnumerable GetCountries() => _db.Suppliers.Select(s => s.Country).ToList();

        public IEnumerable GetProducts() => _db.Products.Select(p => p.ProductName).ToList();
    }
}
