using System.Linq;

namespace SuperCaisse.Model
{
    public class BillBuilder : IReceiptBuilder
    {
        public string Build(Bracket bracket)
        {
            return string.Join(
                "\n",
                "Bill",
                string.Join(
                    "\n",
                    bracket.Articles
                        .GroupBy(
                            article => article.Name,
                            article => article,
                            (baseArticle, articles) => new
                            {
                                Key = baseArticle,
                                Quantity = articles.Count(),
                                TotalPrice = articles.Sum(article => article.Price)
                            }
                        )
                        .Select(
                            groupedArticles => 
                                $"{groupedArticles.Key} - {groupedArticles.Quantity} - {groupedArticles.TotalPrice}€"
                        )
                ),
                string.Join(
                    "\n",
                    bracket.Transactions
                        .Select(
                            transaction => 
                                $"{transaction.Type} : {transaction.Amount}€"
                        )
                )
            );
        }
    }
}