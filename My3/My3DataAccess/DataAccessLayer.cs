using My3Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My3DataAccess
{
    public class DataAccessLayer : IDataAccessLayer
    {
        public Category GetCategory(int id)
        {
            // Get data from DataBase

            // Mapping from DB entity to category

            // Exception handling

            return new Category { MyProperty = 5 };
        }

        public User GetUser(int id)
        {
            // Get data from DataBase

            // Mapping from DB entity to category

            // Exception handling

            return new User { ID=1, Email="email", AddedDate=DateTime.Today, Address="address", Name="name", Password="password", PhoneNumber="phonenumber" };
        }
    }
}

