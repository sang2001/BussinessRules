using BussinessRules.Interfaces;
using BussinessRules.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessRules.Services.OrderProcessing
{
    public abstract class OrderProcessing<TModel> : IOrderProcessing
    {
        public PaymentStatus ProcessOrder<T>(T model)
        {
            return ProcessOrder((TModel)(object)model);
        }

        protected abstract PaymentStatus ProcessOrder(TModel model);


    }
}
