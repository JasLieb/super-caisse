using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperCaisse.Model;

namespace SuperCaisse.Services.Tests
{
    public class ScanServiceTest{

        private ScanService _scanService = new ScanService();

        [TestMethod]
        public void ScanArticle_AddItem_and_Delete()
        {
            Article article = _scanService.getArticle("0102030405");
            Assert.AreEqual(article.Name, "vis");
            Assert.AreEqual(article.Price, 1.25);
        }
           
    }

}
