using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoService.Models
{
    public class TypesAutopart
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }

        public ICollection<Autoparts> Autoparts { get; set; }
    }
}
