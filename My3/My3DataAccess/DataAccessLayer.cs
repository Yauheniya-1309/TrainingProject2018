using My3Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My3DataAccess
{
    public class DataAccessLayer : IDataAccessLayer
    {
        private SqlConnection myConnection;

        private readonly string ConnectionString = ConfigurationManager.ConnectionStrings["My3EventDataBase"].ConnectionString;

       
        
        //public User GetUserByLogin(string userName, string userPassword)
        //{

        //    User result = null;

        //    using (this.myConnection = new SqlConnection(this.ConnectionString))
        //    {
        //        string sqlCommand = "exec sp_GetUserById @Name, @Password";

        //        SqlCommand cmd = new SqlCommand(sqlCommand, this.myConnection);
        //        cmd.Parameters.AddWithValue("@Name", userName);
        //        cmd.Parameters.AddWithValue("@Password", userPassword);

        //        this.myConnection.Open();

        //        using (SqlDataReader reader = cmd.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                result = new User
        //                {
        //                    Name = (string)reader["Name"],
        //                    ID = (int)reader["UserID"],
        //                    Email = (string)reader["E-mail"]
        //                };
        //            }
        //        }
        //    }
        //    return result;
        //}



        public User GetUserById(int id)
        {

            User res = null;

            using (this.myConnection = new SqlConnection(this.ConnectionString))
            {
                string sqlCommand = "exec sp_GetOrganazerById @Id";

                SqlCommand cmd = new SqlCommand(sqlCommand, this.myConnection);
                cmd.Parameters.AddWithValue("@Id", id);
                myConnection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        res = new User
                        {
                            ID = (int)reader["Id"],
                            Name = (string)reader["Name"],
                            Login = (string)reader["Login"],
                            Email = (string)reader["Email"],
                            Password = (string)reader["Password"],
                            AddedDate = (DateTime)reader["AddedDate"],
                            PhoneNumber = (string)reader["PhoneNumber"],
                            Role = (string)reader["Role"]
                        };

                    }
                }
            }
            myConnection.Close();
            return res;
        }

        public void EditUser(User editUser)
        {
            using (this.myConnection = new SqlConnection(this.ConnectionString))
            {


                SqlCommand cmd1 = new SqlCommand
                {
                    CommandText = "sp_GetIdOfRoleByName",
                    CommandType = CommandType.StoredProcedure,
                    Connection = myConnection
                };
                cmd1.Parameters.AddWithValue("@Name", editUser.Role);
                myConnection.Open();
                int id = (int)cmd1.ExecuteScalar();
                myConnection.Close();


                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "sp_EditOrganizerById",
                    CommandType = CommandType.StoredProcedure,
                    Connection = myConnection
                };

                cmd.Parameters.AddWithValue("@id", editUser.ID);
                cmd.Parameters.AddWithValue("@name", editUser.Name);
                cmd.Parameters.AddWithValue("@email", editUser.Email);
                cmd.Parameters.AddWithValue("@password", editUser.Password);
                cmd.Parameters.AddWithValue("@addedDate", editUser.AddedDate);
                cmd.Parameters.AddWithValue("@phoneNumber", editUser.PhoneNumber);
                cmd.Parameters.AddWithValue("@login", editUser.Login);
                cmd.Parameters.AddWithValue("@roleId", id);

                myConnection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                myConnection.Close();

            }
        }

        public void DeleteUser(User deleteUser)
        {

            using (this.myConnection = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "sp_DeleteUser",
                    CommandType = CommandType.StoredProcedure,
                    Connection = myConnection
                };

                cmd.Parameters.AddWithValue("@id", deleteUser.ID);

                myConnection.Open();
                int roewsaffected = cmd.ExecuteNonQuery();
                myConnection.Close();
            }
        }

        public void AddNewUser(User newUser)
        {
                using (this.myConnection = new SqlConnection(this.ConnectionString))
                {
                    SqlCommand cmd1 = new SqlCommand
                    {
                        CommandText = "sp_GetIdOfRoleByName",
                        CommandType = CommandType.StoredProcedure,
                        Connection = myConnection
                    };
                    cmd1.Parameters.AddWithValue("@Name", newUser.Role);
                    myConnection.Open();
                    int id = (int)cmd1.ExecuteScalar();
                    myConnection.Close();

                    SqlCommand cmd = new SqlCommand
                    {
                        CommandText = "sp_InsertUser",
                        CommandType = CommandType.StoredProcedure,
                        Connection = myConnection
                    };

                    cmd.Parameters.AddWithValue("@name", newUser.Name);
                    cmd.Parameters.AddWithValue("@email", newUser.Email);
                    cmd.Parameters.AddWithValue("@password", newUser.Password);
                    cmd.Parameters.AddWithValue("@addeddate", newUser.AddedDate);
                    cmd.Parameters.AddWithValue("@phone", newUser.PhoneNumber);
                    cmd.Parameters.AddWithValue("@roleid", id);
                    cmd.Parameters.AddWithValue("@login", newUser.Login);

                    myConnection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    myConnection.Close();

                }
            }

        public List<User> GetUsers()
        {
            List<User> result = new List<User>();

            using (this.myConnection = new SqlConnection(this.ConnectionString))
            {
                string sqlCommand = "exec sp_GetOrganizers";

                SqlCommand cmd = new SqlCommand(sqlCommand, this.myConnection);

                this.myConnection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var res = new User();

                        res.ID = (int)reader["Id"];
                        res.Name = (string)reader["Name"];
                        res.Login = (string)reader["Login"];
                        res.Email = (string)reader["Email"];
                        res.Password = (string)reader["Password"];
                        res.AddedDate = (DateTime)reader["AddedDate"];
                        res.PhoneNumber = (string)reader["PhoneNumber"];
                        res.Role = (string)reader["Role"];


                        result.Add(res);
                    }
                }
            }
            return result;
        }




        public List<Event> GetEvents()
        {
            List<Event> result = new List<Event>();

            using (this.myConnection = new SqlConnection(this.ConnectionString))
            {
                string sqlCommand = "exec sp_GetEvent";

                SqlCommand cmd = new SqlCommand(sqlCommand, this.myConnection);

                this.myConnection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var res = new Event();

                        res.Name = (string)reader["Name"];
                        res.ID = (int)reader["Id"];
                        res.Place = (string)reader["Place"];
                        res.UserName = (string)reader["Organizer"];
                        res.Date = (DateTime)reader["Date"];
                        res.Description = (string)reader["Description"];
                        res.Picture = (string)reader["Picture"];
                        res.CategoryID = (int)reader["CategoryID"];
                        res.Categories = GetCategories();
                        result.Add(res);
                    }
                }
            }
            return result;
        }
     
        public Event GetEventById(int id)
        {

            Event result = null;

            using (this.myConnection = new SqlConnection(this.ConnectionString))
            {
                string sqlCommand = "exec sp_GetEventById @id";

                SqlCommand cmd = new SqlCommand(sqlCommand, this.myConnection);
                cmd.Parameters.AddWithValue("@id", id);
                myConnection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result = new Event
                        {
                            Name = (string)reader["Name"],
                            ID = (int)reader["Id"],
                            Place = (string)reader["Place"],
                            UserName = (string)reader["Organizer"],
                            Date = (DateTime)reader["Date"],
                            Description = (string)reader["Description"],
                            Picture = (string)reader["Picture"],
                            CategoryID = (int)reader["CategoryID"],
                            Categories = GetCategories()
                    };
                        
                    }
                }
            }
            myConnection.Close();
            return result;
        }

        public void AddEvent(Event newEvent)
        {
            using (this.myConnection = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd1 = new SqlCommand
                {
                    CommandText = "sp_GetIdOfOrganazerByName",
                    CommandType = CommandType.StoredProcedure,
                    Connection = myConnection
                };
                cmd1.Parameters.AddWithValue("@Name", newEvent.UserName);
                myConnection.Open();
                int id1 = (int)cmd1.ExecuteScalar();
                myConnection.Close();



                SqlCommand cmd2 = new SqlCommand
                {
                    CommandText = "sp_GetIdOfCategoryByName",
                    CommandType = CommandType.StoredProcedure,
                    Connection = myConnection
                };
                cmd2.Parameters.AddWithValue("@Name", newEvent.CategoryID);
                myConnection.Open();
                int id2 = (int)cmd2.ExecuteScalar();
                myConnection.Close();


                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "sp_InsertEvent",
                    CommandType = CommandType.StoredProcedure,
                    Connection = myConnection
                };

                cmd.Parameters.AddWithValue("@name", newEvent.Name);
                cmd.Parameters.AddWithValue("@userId", id1);
                cmd.Parameters.AddWithValue("@data", newEvent.Date);
                cmd.Parameters.AddWithValue("@description", newEvent.Description);
                cmd.Parameters.AddWithValue("@place", newEvent.Place);
                cmd.Parameters.AddWithValue("@picture", newEvent.Picture);
                cmd.Parameters.AddWithValue("@category", id2);
               

                myConnection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                myConnection.Close();

            }
        }

        public void EditEvent(Event editEvent)
        {
            using (this.myConnection = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd1 = new SqlCommand
                {
                    CommandText = "sp_GetIdOfOrganazerByName",
                    CommandType = CommandType.StoredProcedure,
                    Connection = myConnection
                };
                cmd1.Parameters.AddWithValue("@Name", editEvent.UserName);
                myConnection.Open();
                int id1 = (int)cmd1.ExecuteScalar();
                myConnection.Close();



                SqlCommand cmd2 = new SqlCommand
                {
                    CommandText = "sp_GetIdOfCategoryByName",
                    CommandType = CommandType.StoredProcedure,
                    Connection = myConnection
                };
                cmd2.Parameters.AddWithValue("@Name", editEvent.CategoryID);
                myConnection.Open();
                int id2 = (int)cmd2.ExecuteScalar();
                myConnection.Close();

                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "sp_EditEventById",
                    CommandType = CommandType.StoredProcedure,
                    Connection = myConnection
                };

                cmd.Parameters.AddWithValue("@id", editEvent.ID);
                cmd.Parameters.AddWithValue("@name", editEvent.Name);
                cmd.Parameters.AddWithValue("@userID", id1);
                cmd.Parameters.AddWithValue("@data", editEvent.Date);
                cmd.Parameters.AddWithValue("@description", editEvent.Description);
                cmd.Parameters.AddWithValue("@place", editEvent.Place);
                cmd.Parameters.AddWithValue("@picture", editEvent.Picture);
                cmd.Parameters.AddWithValue("@category", id2);
            
                myConnection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                myConnection.Close();

            }
        }

        public void DeleteEvent(Event deleteEvent)
        {
            using (this.myConnection = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "sp_DeleteEvent",
                    CommandType = CommandType.StoredProcedure,
                    Connection = myConnection
                };
                    cmd.Parameters.AddWithValue("@id", deleteEvent.ID);

                myConnection.Open();
                cmd.ExecuteNonQuery();
                myConnection.Close();
                }
            }

            //using (this.myConnection = new SqlConnection(this.ConnectionString))
            //{

            //    SqlCommand cmd = new SqlCommand
            //    {
            //        CommandText = "exec sp_DeleteUser @id",
            //        CommandType = CommandType.StoredProcedure,
            //        Connection = myConnection
            //    };

            //    cmd.Parameters.AddWithValue("@id", id);

            //    cmd.ExecuteNonQuery();

            //}
        




        public Role GetRoleById(int id)
        {
            Role res = null;

            using (this.myConnection = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "sp_GetRoleById",
                    CommandType = CommandType.StoredProcedure,
                    Connection = myConnection
                };
                cmd.Parameters.AddWithValue("@Id", id);
                myConnection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        res = new Role
                        {
                            ID = (int)reader["Id"],
                            Name = (string)reader["Name"],
                            Code = (string)reader["Code"]
                        };

                    }
                }
            }
            myConnection.Close();
                return res;
        }
        
        public void EditRole(Role editRole)
        {
            using (this.myConnection = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "sp_EditRoleById",
                    CommandType = CommandType.StoredProcedure,
                    Connection = myConnection
                };

                cmd.Parameters.AddWithValue("@id", editRole.ID);
                cmd.Parameters.AddWithValue("@name", editRole.Name);
                cmd.Parameters.AddWithValue("@code", editRole.Code);
         

                myConnection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                myConnection.Close();

            }
        }

        public void DeleteRole(Role deleteRole)
        {
            using (this.myConnection = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "sp_DeleteRole",
                    CommandType = CommandType.StoredProcedure,
                    Connection = myConnection
                };

                cmd.Parameters.AddWithValue("@id", deleteRole.ID);

                myConnection.Open();
                int roewsaffected=cmd.ExecuteNonQuery();
                myConnection.Close();
            }
        }

        public void AddNewRole(Role newRole)
        {
            using (this.myConnection = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "sp_InsertRole",
                    CommandType = CommandType.StoredProcedure,
                    Connection = myConnection
                };

                cmd.Parameters.AddWithValue("@name", newRole.Name);
                cmd.Parameters.AddWithValue("@code", newRole.Code);

                myConnection.Open();            
                int rows = cmd.ExecuteNonQuery();
                myConnection.Close();
            }

        }

        public List<Role> GetRoles()
        {
            List<Role> result = new List<Role>();

            using (this.myConnection = new SqlConnection(this.ConnectionString))
            {
                string sqlCommand = "exec sp_getRoles";

                SqlCommand cmd = new SqlCommand(sqlCommand, this.myConnection);
                myConnection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var res = new Role();

                        res.ID = (int)reader["Id"];
                        res.Name = (string)reader["Name"];
                        res.Code = (string)reader["Code"];

                        result.Add(res);
                    }
                }
            }
            myConnection.Close();
            return result;
        }



     
  

        public List<Category> GetCategories()
        {
            List<Category> result = new List<Category>();

            using (this.myConnection = new SqlConnection(this.ConnectionString))
            {
                string sqlCommand = "exec sp_GetCategory";

                SqlCommand cmd = new SqlCommand(sqlCommand, this.myConnection);

                this.myConnection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var res = new Category();

                        res.CategoryID = (int)reader["Id"];
                        res.Name = (string)reader["Name"];


                        result.Add(res);
                    }
                }
            }
            myConnection.Close();
            return result;
        }

        public Category GetCategoryById(int id)
        {
            Category res = null;

            using (this.myConnection = new SqlConnection(this.ConnectionString))
            {
                string sqlCommand = "exec sp_GetCategoryById @Id";

                SqlCommand cmd = new SqlCommand(sqlCommand, this.myConnection);
                cmd.Parameters.AddWithValue("@Id", id);
                myConnection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        res = new Category
                        {
                            CategoryID = (int)reader["Id"],
                            Name = (string)reader["Name"]
                        };

                    }
                }
            }
            myConnection.Close();
            return res;
        }

        public void AddCategory(Category newCategory)
        {
            using (this.myConnection = new SqlConnection(this.ConnectionString))
            {
                
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "sp_InsertCategory",
                    CommandType = CommandType.StoredProcedure,
                    Connection = myConnection
                };

                cmd.Parameters.AddWithValue("@name", newCategory.Name);

                myConnection.Open();
                int rows=cmd.ExecuteNonQuery();
                myConnection.Close();
            }
        }

        public void EditCategory(Category editCategory)
        {
            using (this.myConnection = new SqlConnection(this.ConnectionString))
            {
                //myConnection.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "sp_EditCategoryById",
                    CommandType = CommandType.StoredProcedure,
                    Connection = myConnection
                };

                cmd.Parameters.AddWithValue("@id", editCategory.CategoryID);
                cmd.Parameters.AddWithValue("@name", editCategory.Name);

                myConnection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                myConnection.Close();
            }
        }

        public void DeleteCategory(Category deleteCategory)
        {
            using (this.myConnection = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "sp_DeleteCategory",
                    CommandType = CommandType.StoredProcedure,
                    Connection = myConnection
                };

                cmd.Parameters.AddWithValue("@id", deleteCategory.CategoryID);

                myConnection.Open();
                int roewsaffected = cmd.ExecuteNonQuery();
                myConnection.Close();
            }
        }

    }
}

