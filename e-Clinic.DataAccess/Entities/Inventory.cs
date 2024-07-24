using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_Clinic.DataAccess.Entities
{
    public class Inventory
    {
        public int Id { get; set; }

        [Required]
        public string? ItemName { get; set; }

        public int? Quantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Price { get; set; }

        public string? Supplier { get; set; }

        public DateTime? ExpiryDate { get; set; }
    }
}
