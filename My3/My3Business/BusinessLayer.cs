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
        public WeatherWebServiceClient client = new WeatherWebServiceClient();

        public IDataAccessLayer dataAccessLayer;

        public string Weather()
        {
          return this.client.Weather();
        }

        public BusinessLayer(IDataAccessLayer dataAccessLayer)
        {
            this.dataAccessLayer = dataAccessLayer;
        }

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
