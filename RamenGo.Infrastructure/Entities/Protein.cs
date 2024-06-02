using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RamenGo.Infrastructure.Entities
{
    public class Protein
    {
        public int Id { get; set; }
        public string ImageInactive { get; set; }
        public string ImageActive { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public ICollection<Meal> Meals { get; set; }

    }
}
