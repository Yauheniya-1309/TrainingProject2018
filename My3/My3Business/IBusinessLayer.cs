using My3Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace My3Business
{
    public interface IBusinessLayer
    {
        string DoWeather();


        Category GetCategoryById(int id);

        List<Category> GetCategories();

        void AddCategory(Category newCategory);

        void EditCategory(Category editCategory);

        void DeleteCategory(Category deleteCategory);



        Event GetEventById(int id);

        List<Event> GetEvents();

        void AddEvent(Event newEvent);

        void EditEvent(Event editeEvent);

        void DeleteEvent(Event deleteEvent);



        List<User> GetUsers();

        User GetUserById(int id);

        void EditUser(User editeUser);

        void DeleteUser(User deleteUser);

        void AddNewUser(User newUser);


        List<Role> GetRoles();

        Role GetRoleById(int id);

        void EditRole(Role editeRole);

        void DeleteRole(Role deleteRole);

        void AddNewRole(Role newRole);
    }
}
