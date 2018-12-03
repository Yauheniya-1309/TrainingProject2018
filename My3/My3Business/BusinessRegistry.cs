using StructureMap;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My3Business
{
    public class BusinessRegistry : Registry
    {
        public BusinessRegistry()
        {
            Scan(
                scan => {
                    scan.TheCallingAssembly();
                });

            For<IBusinessLayer>().Use<BusinessLayer>();
        }
    }
}
