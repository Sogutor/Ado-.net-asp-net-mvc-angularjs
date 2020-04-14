using WebApplication15.Models.Entities.Base;

namespace WebApplication15.Models.Entities
{
    public class Car : BaseEntity
    {
        public string CustomerName { get; set; }
        public string CarNumber { get; set; }
        public string MobilePhone { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
    }
}