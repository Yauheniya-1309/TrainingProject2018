namespace My3DataAccess
{
    #region Usings

    using System.Collections.Generic;
    using My3Common;
    
    #endregion

    public interface IDataAccessLayer
    {
        #region Category

        Category GetCategoryById(int id);

        List<Category> GetCategories();

        void AddCategory(Category newCategory);

        void EditCategory(Category categoryToEdit);

        void DeleteCategory(Category ctaegoryToDelete);

        #endregion

        #region Event

        void AddEvent(Event newEvent);

        Event GetEventById(int id);

        List<Event> GetEventsOfUser(int id);

        List<Event> GetEvents();

        void EditEvent(Event eventToEdit);

        void DeleteEvent(Event eventToDelete);

        #endregion

        #region Role
        List<Role> GetRoles();

        void EditRole(Role roleToEdit);

        Role GetRoleById(int id);

        void DeleteRole(Role roleToDelete);

        void AddNewRole(Role newRole);

        #endregion

        #region User

        User GetUserById(int id);

        User GetUserByEmail(string email);

        User GetUserByEmailAndPassword(string email, string password);

        List<User> GetUsers();

        void EditUser(User userToEdit);

        void DeleteUser(User userToDelete);

        void AddNewUser(User newUser);

        #endregion
    }
}