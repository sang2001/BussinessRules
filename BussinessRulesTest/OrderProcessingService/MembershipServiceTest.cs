using BussinessRules.Models;
using BussinessRules.Services.OrderProcessingService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
namespace BussinessRulesTest.OrderProcessingService
{
    [TestClass]
  public  class MembershipServiceTest
    {
        MembershipService membershipService;

        [TestInitialize]
        public void Init()
        {
            membershipService = new MembershipService();
        }

        [TestMethod]
        public void ProcessOrder_Success_Test()
        {
            //arrange
            MembershipModel model = new MembershipModel() 
            { 
                MembershipName = "Sandeep",
                EndDate=DateTime.Today.AddDays(365),
                StartDate=DateTime.Today 
            };
            
            var result = membershipService.ProcessOrder<MembershipModel>(model);
            Assert.IsTrue(result.IsOrderProcessed);
            Assert.AreEqual("Membership Activated",result.Message);
        }

        [TestMethod]
        public void ProcessOrder_BookName_Empty_Test()
        {
            
            MembershipModel model = new MembershipModel() 
            { 
                MembershipName = "", 
                EndDate = DateTime.Today.AddDays(365),
                StartDate = DateTime.Today };         
            var result = membershipService.ProcessOrder<MembershipModel>(model);          
            Assert.IsFalse(result.IsOrderProcessed);
        }

    }
}
