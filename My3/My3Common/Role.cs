using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My3Common
{
    public class Role:IRole
    {
        public int ID { get; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
