using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPITutorial.Models
{
    public class Product
    {

        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [Column(TypeName = ("decimal(7,2)"))]
        public decimal Price { get; set; }

        

    }
}
