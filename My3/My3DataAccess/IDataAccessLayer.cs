using My3Common;

namespace My3DataAccess
{
    public interface IDataAccessLayer
    {
        User GetUser(int id);
        Category GetCategory(int id);
        void AddCategory(string category);
        User GetUserByLogin(string userName, string userPassword);
        Event GetEventById(int id);

    }
}