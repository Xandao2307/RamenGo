﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RamenGo.Communication.Responses
{
    public class BrothResponse
    {
        public int Id { get; set; }
        public string ImageInactive { get; set; }
        public string ImageActive { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
