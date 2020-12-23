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
        public string Name { get; }
        public string BarCode { get; }
        public Categories Category { get; }
        public double Price { get; }

        // TODO : How to measure an article follow these dimensions or this weigth 
        // public float Weigth { get; }
        // public float Size { get; }
        // public float Other { get; }

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
    }
}