using BussinessRules.Models;
using BussinessRules.Services.OrderProcessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessRules.Services.OrderProcessingService
{
    public class VideoService : OrderProcessing<VideoModel>
    {

        protected override PaymentStatus ProcessOrder(VideoModel model)
        {
            // logic to add First Aid video to the packing slip
            if (!string.IsNullOrEmpty(model.Details))
            {
                return new PaymentStatus { 
                    IsOrderProcessed = true, 
                    Message = "Added First Aid video to the packing slip."
                };
            }

            return new PaymentStatus { 
                IsOrderProcessed = false, 
                Message = string.Empty 
            }; ;
        }
    }
}
