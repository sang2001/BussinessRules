using BussinessRules.Models;
using BussinessRules.Services.OrderProcessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessRules.Services.OrderProcessingService
{
    public class BookService : OrderProcessing<BookModel>
    {
        protected override PaymentStatus ProcessOrder(BookModel model)
        {
            // logic for Royalty calculation has to be done here
            model.RoyaltyAmount = model.Quantity * model.Price * model.Commission;

            if (!string.IsNullOrEmpty(model.BookName))
            {
                return new PaymentStatus { 
                    IsOrderProcessed = true, 
                    Message = "Royalty slip created with Amount - " + model.RoyaltyAmount,
                    IsNotificationSent=true
                };
            }

            return new PaymentStatus { IsOrderProcessed = false, Message = "No Royalty" }; ;
        }
    }
}
