using My3Business;
using My3DataAccess;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My3DependencyInjection
{
    public class MainRegistry : Registry
    {
        public MainRegistry()
        {
            Scan(
                scan => {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                    scan.AssemblyContainingType<BusinessRegistry>();
                    scan.AssemblyContainingType<DARegistry>();
                    scan.LookForRegistries();
                });

        }
    }
}
