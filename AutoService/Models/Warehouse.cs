using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AutoService.Models
{
    public class Warehouse  : IValidatableObject
    {
        [Key]
        public int Id { get; set; }
        public int count { get; set; }
        public string address { get; set; }
        public int phone { get; set; }
        public ICollection<Autoparts> Autoparts { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (count>100)
            {
                yield return new ValidationResult("Max count must less than to 100 !!!.");
            }
            if(count < 1)
            {
                yield return new ValidationResult("Min count must be more than 1!!! {Max}.");
            }
        }
    }
}
