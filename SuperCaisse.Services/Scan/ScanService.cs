using SuperCaisse.Model;
using System.Linq;

namespace SuperCaisse.Services
    
{
    public class ScanService
    {
        private Article[] _article;
        private string BarCode1 = "0102030405";
        private string BarCode2 = "0203040506";

        public ScanService()
        {
            _article = new Article[]
            {
            new Article("vis",BarCode1,new Categories(),1.25),
            new Article("marteau",BarCode2,new Categories(),8.25)
            };
        }
            public Article getArticle(string BarCode)
            {
            return (Article)_article
                .Where(
                    article =>
                        article.BarCode == BarCode
                )
;

        }
        
    }
}