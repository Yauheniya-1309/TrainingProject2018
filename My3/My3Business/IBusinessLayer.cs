using My3Common;
using System.Linq;

namespace My3Business
{
    public interface IBusinessLayer
    {
        Category GetCategoryById(int id);
        User GetUserById(int id);
        string DoWeather();

        IQueryable<Role> Roles { get; }

        bool CreateRole(Role instance);

        bool UpdateRole(Role instance);

        bool RemoveRole(int idRole);

        Event GetEventById(int id);

        User GetUserById(string userName, string userPassword);
    }
}
