using System.ComponentModel.DataAnnotations;

namespace DTOs
{
    public class OrderDto
    {
        [Required]
        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; }

        [Required]
        public int OrderSum { get; set; }
        [Required]
        public int? UserId { get; set; }

        public List<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();

    }
}
