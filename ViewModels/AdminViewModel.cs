using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectForHealing.ViewModels
{
    public class AdminViewModel
    {
        public string UserName { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public string Pnumber { get; set; }
        public string AdminPassWord { get; set; }
        public byte[] ProfilePic { get; set; }
        public bool? SuperUser { get; set; }
    }
}
