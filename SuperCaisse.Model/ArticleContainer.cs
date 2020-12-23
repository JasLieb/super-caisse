using System;
using System.Collections.Generic;
using System.Text;

namespace SuperCaisse.Model
{
    public abstract class ArticleContainer
    {
        protected IEnumerable<Article> Articles { get; }
    }
}
