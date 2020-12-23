using SuperCaisse.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperCaisse.Services
{
    public class ArticlesService
    {
        private IEnumerable<Article> _articles;

        public ArticlesService()
        {
            _articles = new List<Article>()
            {
                new Article(
                    "vis",
                    "0102030405",
                    Categories.Tools,
                    1.25
                ),
                new Article(
                    "marteau",
                    "0203040506",
                    Categories.Tools,
                    8.25
                )
            };
        }
        public IEnumerable<Article> GetArticles(string barCode)
        {
            return _articles.Where(
                article =>
                    article.BarCode == barCode
            );
        }

        public IEnumerable<Article> Search(string query)
        {
            return _articles.Where(
                article => 
                    article.Name.ToLower().Contains(query.ToLower())
                    || article.BarCode.ToLower().Contains(query.ToLower())
            );
        }
    }
}
