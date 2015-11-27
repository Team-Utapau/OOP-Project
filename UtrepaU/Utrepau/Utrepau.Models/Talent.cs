using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utrepau
{
    public class Talent
    {
        [Key]
        public int Id { get; set; }
        public TalentType TalentType { get; set; }
    }
}
