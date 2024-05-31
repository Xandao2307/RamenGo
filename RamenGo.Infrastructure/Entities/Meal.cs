using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RamenGo.Infrastructure.Entities
{
    public class Meal
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public int BrothId { get; set; }
        public int ProteinId { get; set; }
        public Broth Broth { get; set; }
        public Protein Protein { get; set; }

        public List<Order> Orders { get; set; }
    }
}
