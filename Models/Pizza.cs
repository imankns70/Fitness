﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness.Models
{
    public class Pizza
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<PizzaTopping> Toopings { get; set; }
    }
}
