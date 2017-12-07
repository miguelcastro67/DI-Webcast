using DI.Tutorial.Stage2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;

namespace DI.Tutorial.Stage_2
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestCustomerProcessorUpdate()
        {
            Mock<ICustomerRepository> mockCustomerRepository = new Mock<ICustomerRepository>();
            Mock<IProductRepository> mockProductRepository = new Mock<IProductRepository>();

            mockCustomerRepository.Setup(obj => obj.Save()).Callback(() => Console.WriteLine("Mock save in Customer Repository called."));
            mockProductRepository.Setup(obj => obj.Save()).Callback(() => Console.WriteLine("Mock save in Product Repository called."));

            ICustomerProcessor customerProcessor = new CustomerProcessor(mockCustomerRepository.Object, mockProductRepository.Object);

            customerProcessor.UpdateCustomerOrder("CUST101", "PROD400");

            Assert.IsTrue(1 == 1);
        }
    }
}
