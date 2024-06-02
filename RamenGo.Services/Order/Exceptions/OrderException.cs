using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RamenGo.Services.Order.Exceptions
{
    public class OrderException : Exception
    {
        public OrderException(string? message) : base(message)
        {
        }
    }
}
