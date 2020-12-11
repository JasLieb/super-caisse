using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperCaisse.Services.Tests.Class1
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
