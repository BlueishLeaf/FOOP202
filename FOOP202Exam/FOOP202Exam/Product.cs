using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOOP202Exam
{
    internal class Product
    {
        public string ProductId { get; set; }
        public decimal Price { get; set; }
        public string Title { get; set; }
        public string ProductImage { get; set; }
        public string ProductType { get; set; }

    }

    internal class Game : Product
    {
        public string Format { get; set; }
        public string Genre { get; set; }


        public Game()
        {
            //Get class name
            ProductType = GetType().Name;
        }
        public override string ToString()
        {
            //String formatting
            return $"{Title} \t €{Price} \n Type:{ProductType} \t ID:{ProductId} \n Format:{Format} \t Genre:{Genre}";
        }
    }

    internal class Dvd : Product
    {
        public string Director { get; set; }
        public List<string> Cast { get; set; }
        public string Genre { get; set; }
        public Dvd()
        {
            ProductType = GetType().Name;
        }
        public override string ToString()
        {
            //Get a string with all the cast members
            string fullCast = null;
            foreach (var member in Cast)
            {
                fullCast += member + ',';
            }
            return $"{Title} \t €{Price} \n Type:{ProductType} \t ID:{ProductId} \n Director:{Director} \t Genre:{Genre} \n Cast:{fullCast}";
        }


    }

    internal class Book : Product
    {
        public string Author { get; set; }
        public string Isbn { get; set; }
        public Book()
        {
            ProductType = GetType().Name;
        }
        public override string ToString()
        {
            return $"{Title} \t €{Price} \n Type:{ProductType} \t ID:{ProductId} \n Author:{Author} \t ISBN:{Isbn}";
        }


    }
}
