﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalCenter.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public County County { get; set; }
    }
}
