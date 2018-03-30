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
        private readonly NORTHWNDEntities _db = new NORTHWNDEntities();

        public IEnumerable GetSuppliers() => _db.Suppliers.Select(s => s.CompanyName).ToList();

        public IEnumerable GetCountries() => _db.Suppliers.Select(s => s.Country).ToList();

        public IEnumerable GetProducts() => _db.Products.Select(p => p.ProductName).ToList();

        public IEnumerable FilterByStock(StockLevel level)
        {
            switch (level)
            {
                case StockLevel.Low:
                    return _db.Products.Where(u=>u.UnitsInStock < 50 ).Select(p => p.ProductName).ToList();
                case StockLevel.Normal:
                    return _db.Products.Where(u => u.UnitsInStock >= 50 && u.UnitsInStock <= 100).Select(p => p.ProductName).ToList();
                case StockLevel.Overstocked:
                    return _db.Products.Where(u => u.UnitsInStock > 100).Select(p => p.ProductName).ToList();
                default:
                    return null;
            }
            
        }

        public IEnumerable FilterBySupplier(string supplier)
        {
            var supplierId = _db.Suppliers.Where(s => s.CompanyName.Equals(supplier)).Select(i => i.SupplierID).First();
            return _db.Products.Where(s => s.SupplierID == supplierId).Select(p => p.ProductName).ToList();
        }

        public IEnumerable FilterByCountry(string country)
        {
            var supplierId = _db.Suppliers.Where(s => s.Country.Equals(country)).Select(i => i.SupplierID).First();
            return _db.Products.Where(s => s.SupplierID == supplierId).Select(p => p.ProductName).ToList();
        }
    }
}
