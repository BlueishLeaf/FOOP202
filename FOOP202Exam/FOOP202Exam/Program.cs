using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOOP202Exam
{
    internal class Program
    {
        //List containing all products
        private readonly List<Product> _productList = new List<Product>();

        //Instantiates test objects
        public List<Product> CreateTestProducts()
        {
            _productList.Add(new Dvd()
            {
                Title = "Black Panther",
                ProductId = "M001",
                Price = 9.99m,
                ProductImage = "/images/film.png",
                Director = "Ryan Coogler ",
                Cast = new List<string>(){ "Chadwick Boseman", "Michael B. Jordan", "Lupita Nyongo" },
                Genre = "Action"

            });

            _productList.Add(new Book()
            {
                Title = "Operation Trumpsformation",
                Author = "Ross O'Carroll Kelly",
                ProductId = "B002",
                Price = 15.99m,
                ProductImage = "/images/book.png",
                Isbn = "978-0241978016"
            });

            _productList.Add(new Game()
            {
                Title = "FIFA 18",
                ProductId = "G003",
                Price = 49.99m,
                ProductImage = "/images/controller.png",
                Format = "PS4, XBox1, PC, Switch",
                Genre = "Sport"
            });
            return _productList;
        }

        //Filter the products based on the type passed in
        public List<Product> FilterProducts(string filterType)
        {
            var filteredList = new List<Product>();
            switch (filterType)
            {
                case "All":
                    return _productList;
                case "Books":
                    //Loop through the list and if the type is equal to the desired type, then add it to the filtered list
                    foreach (var item in _productList)
                    {
                        if (item.ProductType == "Book")
                        {
                            filteredList.Add(item);
                        }
                    }
                    return filteredList;
                case "DVDs":
                    foreach (var item in _productList)
                    {
                        if (item.ProductType == "Dvd")
                        {
                            filteredList.Add(item);
                        }
                    }
                    return filteredList;
                case "Games":
                    foreach (var item in _productList)
                    {
                        if (item.ProductType == "Game")
                        {
                            filteredList.Add(item);
                        }
                    }
                    return filteredList;
                default:
                    return _productList;
            }
        }
    }
}
