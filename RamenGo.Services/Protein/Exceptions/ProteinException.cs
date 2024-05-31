using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RamenGo.Services.Protein.Exceptions
{
    public class ProteinException : Exception
    {
        public ProteinException(string? message) : base(message)
        {
        }
    }
}
