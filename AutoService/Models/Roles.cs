using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoService.Models
{
    public class Roles
    {
        [Key]
        public int Id { get; set; }
        public String name { get; set; }
        public List<UsersRoles> UsersRoles { get; set; }

    }
}
