using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace WebAPITutorial.Models
{
    public class Order
    {

        public int Id { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        [Column(TypeName = "decimal(11,2)")]
        public decimal Total { get; set; }

        [StringLength(10)]
        public string Status { get; set; }

        public DateTime Date { get; set; }

       
        public int CustomerId { get; set; } //FK to Customer
        public virtual Customer? Customer { get; set; }

        public virtual IEnumerable<OrderLine>? OrderLines { get; set; }
    }
}
