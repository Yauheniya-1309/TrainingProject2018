namespace My3Business
{
    #region Using

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using StructureMap;
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;

    #endregion

    public class BusinessRegistry : Registry
    {
        public BusinessRegistry()
        {
            For<IBusinessLayer>().Use<BusinessLayer>();
        }
    }
}
