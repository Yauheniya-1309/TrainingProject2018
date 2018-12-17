//using My3Business.ServiceReference1;
using My3Business.ServiceReference1;
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
        public IDataAccessLayer dataAccessLayer;

        public  WeatherWebServiceClient client = new WeatherWebServiceClient();

        public BusinessLayer(IDataAccessLayer dataAccessLayer)
        {
            this.dataAccessLayer = dataAccessLayer;
        }

        public string DoWeather()
        {
         return this.client.DoWork();
        }

        public IQueryable<Role> Roles
        {
            get { throw new NotImplementedException(); }
        }

        public bool CreateRole(Role instance)
        {
            throw new NotImplementedException();
        }

        public bool UpdateRole(Role instance)
        {
            throw new NotImplementedException();
        }

        public bool RemoveRole(int idRole)
        {
            throw new NotImplementedException();
        }


        public Category GetCategoryById(int id)
        {
            return this.dataAccessLayer.GetCategory(id);
        }

        public Event GetEventById(int id)
        {
            return this.dataAccessLayer.GetEventById(id);
        }

        public User GetUserById(string userName, string userPassword)
        {
            return this.dataAccessLayer.GetUserByLogin(userName, userPassword);
        }

        public User GetUserById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
