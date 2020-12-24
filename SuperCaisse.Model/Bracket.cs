using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperCaisse.Model
{
    public class Bracket : ArticleContainer
    {
        public void AddArticle(Article article)
        {
            Articles.Add(article);
        }
        
        public double GetTotalPrice()
        {
            return Articles.Sum(
                article => article.Price
            );
        }
    }
}
