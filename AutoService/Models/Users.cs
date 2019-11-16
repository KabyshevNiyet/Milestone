using AutoService.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AutoService.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        [ValidLogin]
        public string name { get; set; }
        [ValidLogin]
        public string surname { get; set; }

        [ValidLogin]
        [Remote(action: "Create", controller: "UsersController")]
        public string email { get; set; }
        public string phone { get; set; }
        public List<UsersRoles> UsersRoles { get; set; }
        public ICollection<Orders> OrdersManager { get; set; }
        public ICollection<Orders> OrdersClient { get; set; }

    }
}
