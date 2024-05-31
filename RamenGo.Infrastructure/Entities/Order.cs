using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RamenGo.Infrastructure.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int MealId { get; set; }
        public Meal Meal { get; set; }
    }
}
