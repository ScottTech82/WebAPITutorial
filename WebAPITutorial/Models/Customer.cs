using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;

namespace WebAPITutorial.Models
{
    [Index("Code", IsUnique = true, Name = "UIDX_Code")]
    public class Customer
    {

        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(4)]
        public string Code { get; set; }

        [Column(TypeName ="decimal(11,2)")]
        public decimal Sales { get; set; }

        [StringLength (255)]
        public string? Notes { get; set; }

        [JsonIgnore]
        public virtual IEnumerable<Order> Orders { get; set; }


    }
}
