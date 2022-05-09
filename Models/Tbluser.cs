using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace practicleassignment4.Models
{
    public partial class Tbluser
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public decimal Contact { get; set; }
        public string EmailId { get; set; }
    }
}
