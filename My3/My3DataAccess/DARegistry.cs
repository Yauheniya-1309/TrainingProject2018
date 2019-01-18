namespace My3DataAccess
{
    #region Using
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using StructureMap;
    using StructureMap.Configuration.DSL;
    #endregion

    public class DARegistry : Registry
    {
        public DARegistry()
        {
            For<IDataAccessLayer>().Use<DataAccessLayer>();
        }
    }
}
