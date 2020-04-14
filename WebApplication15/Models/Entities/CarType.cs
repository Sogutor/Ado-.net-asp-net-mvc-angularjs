
using System.Collections.Generic;
using WebApplication15.Models.Entities.Base;

namespace WebApplication15.Models.Entities
{
    public class CarType : BaseEntity
    {
        public string Name { get; set; }
        public int MarkId { get; set; }
        public string MarkName { get; set; }
    }

    
}