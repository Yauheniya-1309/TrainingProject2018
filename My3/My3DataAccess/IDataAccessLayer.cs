using My3Common;

namespace My3DataAccess
{
    public interface IDataAccessLayer
    {
        User GetUser(int id);
        Category GetCategory(int id);
    }
}