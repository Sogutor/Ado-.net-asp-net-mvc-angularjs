using System;
using System.Collections.Generic;
using WebApplication15.Models.Entities;

namespace WebApplication15.Models
{
    public class CarAttribute
    {
        public int MarkId { get; set; }
        public string MarkName { get; set; }
        public List<CarType> Models { get; set; }
    }
}