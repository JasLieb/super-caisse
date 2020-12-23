using System;
using System.Collections.Generic;
using System.Text;

namespace SuperCaisse.Model
{
    public class Bracket : ArticleContainer
    {
        public void AddArticle(Article article)
        {
            Articles.Add(article);
        }
    }
}
