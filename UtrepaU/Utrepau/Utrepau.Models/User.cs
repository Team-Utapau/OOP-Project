using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Utrepau
{
    public class User
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]

        public string Password { get; set; }
       
        public int CharacterId { get; set; }
        public virtual Character Character { get; set; }

    }
}
