using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AutoService.Models
{
    public class Orders
    {
        [Key]
        public int Id { get; set; }
        
        public int autoparts_id { get; set; }
        [ForeignKey("autoparts_id")]
        public Autoparts Autopart { get; set; }
        
        public int client_id { get; set; }
        [ForeignKey("client_id")]
        public Users Client { get; set; }
        
        public int manager_id { get; set; }
        [ForeignKey("manager_id")]
        public Users Manager { get; set; }
        
        public DateTime date { get; set; }
        public double total { get; set; }

    }
}
