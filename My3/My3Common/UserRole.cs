using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My3Common
{
    public class UserRole:IUserRole
    {
        public int ID { get; }
        public int UserID { get; set; }
        public string RoleID { get; set; }
    }
}
