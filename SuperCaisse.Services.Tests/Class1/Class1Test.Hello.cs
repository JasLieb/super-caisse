using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SuperCaisse.Services.Tests
{
    public partial class Class1Test
    {
        [TestMethod]
        public void Class1_SayHelloWorld()
        {
            Assert.AreEqual(_dummy.HelloSentence, "Hello World !");
        }
    }
}
