using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoService.Models
{
    public class Cars
    {
        [Key]
        public int Id { get; set; }
        public string mark { get; set; }
        public string model { get; set; }
        public int year { get; set; }
        public ICollection<Autoparts> Autoparts { get; set; }

    }
}
