namespace My3Business
{
    #region Using
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using My3Business.ServiceReference1;
    using My3Common;
    using My3DataAccess;
    #endregion

    public class BusinessLayer : IBusinessLayer
    {
        public IDataAccessLayer dataAccessLayer;

        public WeatherWebServiceClient client = new WeatherWebServiceClient();

        public BusinessLayer(IDataAccessLayer dataAccessLayer)
        {
            this.dataAccessLayer = dataAccessLayer;
        }

        public string DoWeather()
        {
            return this.client.DoWork();
        }

        #region Category
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

        public void EditCategory(Category categoryToEdit)
        {
            this.dataAccessLayer.EditCategory(categoryToEdit);
        }

        public void DeleteCategory(Category categoryToDelete)
        {
            this.dataAccessLayer.DeleteCategory(categoryToDelete);
        }

        #endregion

        #region Event
        public Event GetEventById(int id)
        {
            return this.dataAccessLayer.GetEventById(id);
        }

        public List<Event> GetEvents()
        {
            return this.dataAccessLayer.GetEvents();
        }

        public List<Event> GetEventsOfUser(int id)
        {
            return this.dataAccessLayer.GetEventsOfUser(id);
        }

        public void AddEvent(Event newEvent)
        {
            this.dataAccessLayer.AddEvent(newEvent);
        }

        public void EditEvent(Event eventToEdit)
        {
            this.dataAccessLayer.EditEvent(eventToEdit);
        }

        public void DeleteEvent(Event eventToDelete)
        {
            this.dataAccessLayer.DeleteEvent(eventToDelete);
        }
        #endregion

        #region User
        public User GetUserById(int id)
        {
            return this.dataAccessLayer.GetUserById(id);
        }

        public List<User> GetUsers()
        {
            return this.dataAccessLayer.GetUsers();
        }

        public void EditUser(User userToEdit)
        {
            this.dataAccessLayer.EditUser(userToEdit);
        }

        public void DeleteUser(User userToDelete)
        {
            this.dataAccessLayer.DeleteUser(userToDelete);
        }

        public void AddNewUser(User newUser)
        {
            this.dataAccessLayer.AddNewUser(newUser);
        }
        #endregion

        #region Role
        public List<Role> GetRoles()
        {
            return this.dataAccessLayer.GetRoles();
        }

        public Role GetRoleById(int id)
        {
            return this.dataAccessLayer.GetRoleById(id);
        }

        public void EditRole(Role roleToEdit)
        {
            this.dataAccessLayer.EditRole(roleToEdit);
        }

        public void DeleteRole(Role roleToDelete)
        {
            this.dataAccessLayer.DeleteRole(roleToDelete);
        }

        public void AddNewRole(Role newRole)
        {
            this.dataAccessLayer.AddNewRole(newRole);
        }
        #endregion

        public User GetUserByEmail(string email)
        {
            return this.dataAccessLayer.GetUserByEmail(email);
        }

        public User GetUserByEmailAndPassword(string email, string password)
        {
            return this.dataAccessLayer.GetUserByEmailAndPassword(email, password);
        }
    }
}
