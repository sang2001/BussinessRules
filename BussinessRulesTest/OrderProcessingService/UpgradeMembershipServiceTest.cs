using BussinessRules.Models;
using BussinessRules.Services.OrderProcessingService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
namespace BussinessRulesTest.OrderProcessingService
{
    [TestClass]
   public class UpgradeMembershipServiceTest
    {
        UpgradeMembershipService upgradeMembershipService;

        [TestInitialize]
        public void Init()
        {

            upgradeMembershipService = new UpgradeMembershipService();
        }

        [TestMethod]
        public void ProcessOrder_Success_Test()
        {
            //arrange
            UpgradeMembershipModel model = new UpgradeMembershipModel() {MembershipName="Study",UpgradeStartDate=DateTime.Today,UpgradeEndDate=DateTime.Today.AddDays(365) };
            //act
            var result = upgradeMembershipService.ProcessOrder<UpgradeMembershipModel>(model);
            //assert
            Assert.IsTrue(result.IsOrderProcessed);
            Assert.AreEqual("Membership upgraded", result.Message);
        }

        [TestMethod]
        public void ProcessOrder_BookName_Empty_Test()
        {
            //arrange
            UpgradeMembershipModel model = new UpgradeMembershipModel() { MembershipName = "", UpgradeStartDate = DateTime.Today, UpgradeEndDate = DateTime.Today.AddDays(365) };
            //act
            var result = upgradeMembershipService.ProcessOrder<UpgradeMembershipModel>(model);
            //assert
            Assert.IsFalse(result.IsOrderProcessed);
        }
    }
}
