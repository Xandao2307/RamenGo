using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RamenGo.Communication.Responses
{
    public class OrderResponse
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
