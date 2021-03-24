﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone_Project.Models
{
    public class GoalModel
    {
        [Key]
        public int Id { get; set; }
        public string Goal { get; set; }
        public string Date { get; set; }
        public double Amount { get; set; }
        public double Monthly { get; set; }
        

    }
}
