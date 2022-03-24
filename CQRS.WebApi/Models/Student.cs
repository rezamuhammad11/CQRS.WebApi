﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.WebApi.Models
{
    public class Student
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public int Roll { get; set; }
        public string Name { get; set; }
        public int Class { get; set; }
        public string Section { get; set; }
    }
}
