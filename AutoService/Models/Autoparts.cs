using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AutoService.Models
{
    public class Autoparts
    {
        [Key]
        public int Id { get; set; }
        public int car_id { get; set; }
        [ForeignKey("car_id")]
        public Cars Cars { get; set; }
        public int typesautopart_id { get; set; }
        [ForeignKey("typesautopart_id")]
        public TypesAutopart TypesAutopart { get; set; }

        public string name { get; set; }
        public double price { get; set; }

        public ICollection<Orders> Order { get; set; }
        public Warehouse Warehouse { get; set; }

    }
}
