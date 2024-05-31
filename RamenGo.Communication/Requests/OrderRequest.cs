using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RamenGo.Communication.Requests
{
    public class OrderRequest
    {
        public int BrothId { get; set; }
        public int ProteinId { get; set; }
    }
}
