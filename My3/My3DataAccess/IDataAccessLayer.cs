using My3Common;
using System;
using System.Collections.Generic;

namespace My3DataAccess
{
    public interface IDataAccessLayer
    {
      
        Category GetCategoryById(int id);

        List<Category> GetCategories();

        void AddCategory(Category newCategory);

        void EditCategory(Category editCategory);

        void DeleteCategory(Category deleteCetgory);



        void AddEvent(Event createEvent); 

        Event GetEventById(int id);

        List<Event> GetEvents();

        void EditEvent(Event editEvent);

        void DeleteEvent(Event deleteEvent);




        List<Role> GetRoles();

        void EditRole(Role editRole);

        Role GetRoleById(int id);

        void DeleteRole(Role deleteRole);

        void AddNewRole(Role newRole);



        //        User GetUserByLogin(string userName, string userPassword);  

        User GetUserById(int Id);

        List<User> GetUsers();

        void EditUser(User editUser);

        void DeleteUser(User deleteUser);

        void AddNewUser(User newUser);
    }
}