using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperCaisse.Model
{
    public abstract class ArticleContainer
    {
        public Guid Id { get; }
        public IList<Article> Articles { get; }

        protected ArticleContainer()
        {
            Id = Guid.NewGuid();
            Articles = new List<Article>();
        }
    }
}
