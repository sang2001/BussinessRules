using BussinessRules.Models;
using BussinessRules.Services.OrderProcessing;
using BussinessRules.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessRules.Services.OrderProcessingService
{
    public class MembershipService : OrderProcessing<MembershipModel>
    {
        protected override PaymentStatus ProcessOrder(MembershipModel model)
        {

            // logic implementation
            // If Payment is done then activate the membership and sent a mail to user.
            if (!string.IsNullOrEmpty(model.MembershipName))
            {
                model.Status = true;

                return new PaymentStatus {
                    IsOrderProcessed = true,
                    Message = "Membership Activated",
                    IsNotificationSent = true
                };
            }

            return new PaymentStatus
            {
                IsOrderProcessed = false,
                Message = "Membership Not Activated",
                IsNotificationSent = false
            };
        }
    }
}
