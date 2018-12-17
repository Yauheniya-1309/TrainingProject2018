using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My3Common
{
    public class Role:IRole
    {
        [Key]
        public int ID { get; }

        public string Code { get; set; }

        public string Name { get; set; }
    }
}
