using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AutoService.Models
{
    public class UsersRoles
    {
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public Users Users { get; set; }
        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public Roles Roles { get; set; }

    }
}
