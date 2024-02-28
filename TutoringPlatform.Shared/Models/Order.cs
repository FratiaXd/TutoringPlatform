using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutoringPlatform.Shared.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        //Foreign keys
        public string UserId { get; set; }
        public int CourseId { get; set; }
        //Properties
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string? Image {  get; set; }
        public decimal SubTotal => Quantity * Price;
        public DateTime OrderTime { get; set; }
        //Relationships
        public TutoringPlatformUser? User { get; set; }
        public Course? Course { get; set;}
    }
}
