using SuperCaisse.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperCaisse.Services
{
    public class StockOrderService
    {
        // TODO Extract value as new class
        public (Article[] articles, double totalPrice) AddStockOrder(params Article[] articles)
        {
            return (
                articles,
                articles.Sum(article => article.Price)
            );
        }
    }
}
