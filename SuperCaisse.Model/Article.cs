using System;
using System.Collections.Generic;
using System.Text;

namespace SuperCaisse.Model
{
    public enum ArticleCategories
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
        public ArticleCategories Category { get; }
        public double Price { get; }

        // TODO : How to measure an article follow these dimensions or this weigth 
        // public float Weigth { get; }
        // public float Size { get; }
        // public float Other { get; }

        public Article(
            string name,
            string barCode,
            ArticleCategories category,
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