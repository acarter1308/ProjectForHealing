using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectForHealing.ViewModels
{
    public class AddEditorViewModel
    {
        public string UserName { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public string Pnumber { get; set; }
        public string EditorPassWord { get; set; }
        public byte[] ProfilePicUrl { get; set; }
    }
}
