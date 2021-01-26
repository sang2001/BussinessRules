using BussinessRules.Models;
using BussinessRules.Services.OrderProcessingService;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BussinessRulesTest.OrderProcessingService
{
    [TestClass]
   public class BookServiceTest
    {
        BookService bookService;

        [TestInitialize]
        public void Init()
        {
            bookService = new BookService();
        }

        [TestMethod]
        public void ProcessOrder_Success_Test()
        {          
            BookModel model = new BookModel() { BookName="English", Price=220,Quantity=5};
            double royaltyAmount = model.Price * model.Quantity * model.Commission;
            string message = "Royalty slip created with Amount - " + royaltyAmount;       
            var result=bookService.ProcessOrder<BookModel>(model);
         
            Assert.IsTrue( result.IsOrderProcessed);
            Assert.AreEqual(message, result.Message);


        }

        [TestMethod]
        public void ProcessOrder_BookName_Empty_Test()
        {
            //arrange
            BookModel model = new BookModel() { BookName = "", Price = 220, Quantity = 5 };
            //act
            var result = bookService.ProcessOrder<BookModel>(model);
            //assert
            Assert.IsFalse( result.IsOrderProcessed);
        }


    }
}
