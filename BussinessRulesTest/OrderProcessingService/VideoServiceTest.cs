using BussinessRules.Models;
using BussinessRules.Services.OrderProcessingService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
namespace BussinessRulesTest.OrderProcessingService
{
    [TestClass]
  public  class VideoServiceTest
    {
        VideoService videoService;

        [TestInitialize]
        public void Init()
        {
            videoService = new VideoService();
        }

        [TestMethod]
        public void ProcessOrder_Success_Test()
        {
            //arrange
            VideoModel model = new VideoModel() { Details= "First Aid video to the packing slip", PackingDate=DateTime.Today };
            //act
            var result = videoService.ProcessOrder<VideoModel>(model);
            //assert
            Assert.IsTrue(result.IsOrderProcessed);
            Assert.AreEqual("Added First Aid video to the packing slip.", result.Message);
        }

        [TestMethod]
        public void ProcessOrder_BookName_Empty_Test()
        {
            //arrange
            VideoModel model = new VideoModel() { Details = "", PackingDate = DateTime.Today };
            //act
            var result = videoService.ProcessOrder<VideoModel>(model);
            //assert
            Assert.IsFalse(result.IsOrderProcessed);
        }
    }
}
