using My3Common;
using My3DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace My3Business
{
    public class BusinessLayer : IBusinessLayer
    {
        private DataAccessLayer dataAccessLayer;

        public Category GetCategoryById(int id)
        {
            return this.dataAccessLayer.GetCategory(id);
        }

        public User GetUserById(int id)
        {
            return this.dataAccessLayer.GetUser(id);
        }
    }
}
