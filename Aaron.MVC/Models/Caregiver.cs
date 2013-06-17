using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Aaron.MVC.Models
{
    public class Caregiver
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(25)]
        public string Phone { get; set; }
        public bool AuthorizationRequested { get; set; }
        public bool Authorized { get; set; }
    }
}
