using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SuperCaisse.Services.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private Class1 _dummy = new Class1();
        
        [TestMethod]
        public void Class1_SayHelloWorld()
        {
            Assert.AreEqual(_dummy.HelloSentence, "Hello World !");
        }
    }
}
