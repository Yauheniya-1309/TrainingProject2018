using StructureMap;
using StructureMap.Configuration.DSL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My3DataAccess
{
    public class DARegistry : Registry
    {
        public DARegistry()
        {

            For<IDataAccessLayer>().Use<DataAccessLayer>();
        }
    }
}
