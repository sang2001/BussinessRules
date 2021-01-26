using BussinessRules.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessRules.Interfaces
{
    public interface IOrderProcessing
    {
        PaymentStatus ProcessOrder<T>(T model);
    }
}
