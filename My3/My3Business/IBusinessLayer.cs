namespace My3Business
{
    #region Using
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using My3Common;
    #endregion

    public interface IBusinessLayer
    {
        string DoWeather();

        #region Category
        Category GetCategoryById(int id);

        List<Category> GetCategories();

        void AddCategory(Category newCategory);

        void EditCategory(Category categoryToEdit);

        void DeleteCategory(Category categoryToDelete);
        #endregion

        #region Event
        Event GetEventById(int id);

        List<Event> GetEvents();

        List<Event> GetEventsOfUser(int id);

        void AddEvent(Event newEvent);

        void EditEvent(Event eventToEdit);

        void DeleteEvent(Event eventToDelete);
        #endregion

        #region User
        List<User> GetUsers();

        User GetUserById(int id);

        User GetUserByEmail(string email);

        User GetUserByEmailAndPassword(string email, string password);

        void EditUser(User userToEdit);

        void DeleteUser(User userToDelete);

        void AddNewUser(User newUser);
        #endregion

        #region Role
        List<Role> GetRoles();

        Role GetRoleById(int id);

        void EditRole(Role roleToEdit);

        void DeleteRole(Role roleToDelete);

        void AddNewRole(Role newRole);
        #endregion
    }
}
