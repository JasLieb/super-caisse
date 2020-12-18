using System;
using System.Collections.Generic;
using System.Text;

namespace SuperCaisse.Model
{
    public enum Categories
    {
        Garden,
        Bathroom,
        Carpenty,
        Tools,
        Electronic,
        Kitchen,
        Dressing,
        Materials
    }

    public class Article
    {
        public Article(
            string name,
            string barCode,
            Categories category,
            double price
        )
        {
            Name = name;
            BarCode = barCode;
            Category = category;
            Price = price;
        }
        public string Name { get; set; }
        public string BarCode { get; set; }
        public Categories Category { get; set; }
        public double Price { get; set; }

        // TODO : How to measure an article follow these dimensions or this weigth 
        // public float Weigth { get; set; }
        // public float Size { get; set; }
        // public float Other { get; set; }

        public string GetBarCode()
        {
            return BarCode;
        }
    }
}