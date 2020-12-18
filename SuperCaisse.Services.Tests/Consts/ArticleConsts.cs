using SuperCaisse.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperCaisse.Services.Tests.Utils
{
    public class ArticleConsts
    {
        public static Article Screwdriver => 
            new Article()
            {
                BarCode = "01010",
                Category = Categories.Tools,
                Name = "Tournevis",
                Price = 14.99
            };

        public static Article Probe =>
            new Article()
            {
                BarCode = "10101",
                Category = Categories.Tools,
                Name = "Sonde",
                Price = 49.99
            };

        public static Article WoodenGardenChair =>
            new Article()
            {
                BarCode = "11111",
                Category = Categories.Garden,
                Name = "Chaise en bois de jardin",
                Price = 25
            };

        public static Article RJ45Cable3Meters =>
            new Article()
            {
                BarCode = "11001",
                Category = Categories.Electronic,
                Name = "Cable RJ45 3m",
                Price = 7.50
            };
    }
}
