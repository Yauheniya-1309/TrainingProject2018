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





        public Category GetCategoryById(int id)
        {
            return this.dataAccessLayer.GetCategoryById(id);
        }

        public List<Category> GetCategories()
        {
            return this.dataAccessLayer.GetCategories();
        }

        public void AddCategory(Category newCategory)
        {
            this.dataAccessLayer.AddCategory(newCategory);
        }

        public void EditCategory(Category editCategory)
        {
            this.dataAccessLayer.EditCategory(editCategory);
        }

        public void DeleteCategory(Category deleteCategory)
        {
            this.dataAccessLayer.DeleteCategory(deleteCategory);
        }




        public Event GetEventById(int id)
        {
            return this.dataAccessLayer.GetEventById(id);
        }

        public List<Event> GetEvents()
        {
            return this.dataAccessLayer.GetEvents();
        }

        public void AddEvent(Event newEvent)
        {
            this.dataAccessLayer.AddEvent(newEvent);
        }

        public void EditEvent(Event editEvent)
        {
            this.dataAccessLayer.EditEvent(editEvent);
        }

        public void DeleteEvent(Event deleteEvent)
        {
            this.dataAccessLayer.DeleteEvent(deleteEvent);
        }



        public User GetUserById(int id)
        {
            return this.dataAccessLayer.GetUserById(id);
        }

        public List<User> GetUsers()
        {
            return this.dataAccessLayer.GetUsers();
        }

        public void EditUser(User editUser)
        {
            this.dataAccessLayer.EditUser(editUser);
        }

        public void DeleteUser(User DeleteUser)
        {
            this.dataAccessLayer.DeleteUser(DeleteUser);
        }

        public void AddNewUser(User newUser)
        {
            this.dataAccessLayer.AddNewUser(newUser);
        }



        public List<Role> GetRoles()
        {
            return this.dataAccessLayer.GetRoles();
        }

        public Role GetRoleById(int id)
        {
           return this.dataAccessLayer.GetRoleById(id);
        }

        public void EditRole(Role editeRole)
        {
            this.dataAccessLayer.EditRole(editeRole);
        }

        public void DeleteRole(Role deleteRole)
        {
            this.dataAccessLayer.DeleteRole(deleteRole);
        }

        public void AddNewRole(Role newRole)
        {
            this.dataAccessLayer.AddNewRole(newRole);
        }
    }
}
