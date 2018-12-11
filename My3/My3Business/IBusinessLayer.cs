using My3Common;

namespace My3Business
{
    public interface IBusinessLayer
    {
        Category GetCategoryById(int id);
        User GetUserById(int id);
        string Weather();
    }
}
