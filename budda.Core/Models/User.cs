using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace budda.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string mail { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; } = string.Empty;
        
    }
}
