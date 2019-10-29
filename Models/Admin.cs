using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectForHealing.Models
{
    public partial class Admin
    {

        [Key]
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public string Pnumber { get; set; }
        public string AdminPassWord { get; set; }
        public byte[] ProfilePic { get; set; }
    }
}
