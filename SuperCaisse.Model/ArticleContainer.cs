using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperCaisse.Model
{
    public abstract class ArticleContainer
    {
        protected IList<Article> Articles { get; }

        protected ArticleContainer()
        {
            Articles = new List<Article>();
        }

        public double GetTotalPrice()
        {
            return Articles.Sum(
                article => article.Price
            );
        }
    }
}
