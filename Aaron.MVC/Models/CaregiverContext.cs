using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Aaron.MVC.Models
{
    public class CaregiverContext : DbContext
    {
        public IDbSet<Caregiver> Caregivers { get; set; }
    }
}