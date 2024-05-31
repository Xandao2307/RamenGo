using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RamenGo.Services.Responses.Exceptions
{
    public class BrothException : Exception
    {
        public BrothException(string? message) : base(message)
        {
        }
    }
}
