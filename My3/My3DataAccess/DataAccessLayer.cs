namespace My3DataAccess
{
    #region User
 
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using My3Common;
    
    #endregion

    public class DataAccessLayer : IDataAccessLayer
    {
        private readonly string ConnectionString = ConfigurationManager.ConnectionStrings["My3EventDataBase"].ConnectionString;
        private SqlConnection myConnection;
        
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
                            Role = (string)reader["Role"],
                            ConfirmPassword= (string)reader["Password"]
                        };
                    }
       
                    myConnection.Close();
                }   
            }

            return res;
        }

        public User GetUserByEmail(string email)
        {
            User res = null;
        
            using (this.myConnection = new SqlConnection(this.ConnectionString))
            {
                string sqlCommand = "exec sp_GetOrganazerByEmail @Email";

                SqlCommand cmd = new SqlCommand(sqlCommand, this.myConnection);

                cmd.Parameters.AddWithValue("@Email", email);

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
                            Role = (string)reader["Role"],
                            ConfirmPassword= (string)reader["Password"]
                        };
                    }
                }
                myConnection.Close();
            }
          
            return res;
        }

        public User GetUserByEmailAndPassword(string email, string password)
        {
            User res = null;

            using (this.myConnection = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "sp_GetOrganazerByEmailAndPassword",
                    CommandType = CommandType.StoredProcedure,
                    Connection = myConnection
                };
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);

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
                            Role = (string)reader["Role"],
                            ConfirmPassword = (string)reader["Password"]
                        };

                    }
                   
                }

                myConnection.Close();
            }

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

        public void DeleteUser(User userToDelete)
        {

            SqlConnection myConnection = new SqlConnection(this.ConnectionString);

            this.DeleteEventsOfUser(userToDelete.ID);

            SqlCommand cmd = new SqlCommand
                {
                    CommandText = "sp_DeleteUser",
                    CommandType = CommandType.StoredProcedure,
                    Connection = myConnection
                };

                cmd.Parameters.AddWithValue("@id", userToDelete.ID);

                myConnection.Open();

                int roewsaffected = cmd.ExecuteNonQuery();

                myConnection.Close();
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
                        res.ConfirmPassword = res.Password;
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
                        res.Category = (string)reader["Category"];
                        res.Status = ((res.Date < DateTime.Now) ? "Completed" : (res.Date > DateTime.Now) ? "Planned" : "In progress");
                        result.Add(res);
                    }
                }
            }

            return result;
        }

        public List<Event> GetEventsOfUser(int id)
        {
            List<Event> result = new List<Event>();

            using (this.myConnection = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "sp_GetEventsOfUser",
                    CommandType = CommandType.StoredProcedure,
                    Connection = myConnection
                };

                cmd.Parameters.AddWithValue("@id", id);

                myConnection.Open();

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
                        res.Category = (string)reader["Category"];
                        res.Status = ((res.Date < DateTime.Now) ? "Completed" : (res.Date > DateTime.Now) ? "Planned" : "In progress");
                        result.Add(res);
                    }
                }

                myConnection.Close();
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
                            Category = (string)reader["Category"]
                        };

                        result.Status = ((result.Date < DateTime.Now) ? "Completed" : (result.Date > DateTime.Now) ? "Planned" : "In progress");
                    }
                }

                myConnection.Close();
            }
            
            return result;
        }

        public void AddEvent(Event newEvent)
        {
            int id1, id2;

            using (this.myConnection = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd1 = new SqlCommand
                {
                    CommandText = "sp_GetIdOfOrganazerByEmail",
                    CommandType = CommandType.StoredProcedure,
                    Connection = myConnection
                };

                cmd1.Parameters.AddWithValue("@Email", newEvent.UserName);

                SqlCommand cmd2 = new SqlCommand
                {
                    CommandText = "sp_GetIdOfCategoryByName",
                    CommandType = CommandType.StoredProcedure,
                    Connection = myConnection
                };

                cmd2.Parameters.AddWithValue("@Name", newEvent.Category);

                myConnection.Open();

                id1 = (int)cmd1.ExecuteScalar();

                id2 = (int)cmd2.ExecuteScalar();

                myConnection.Close();
            }

            SqlConnection my1Connection = new SqlConnection(this.ConnectionString);

            string PictureCategory = GetCategoryById(id2).Picture;

            SqlCommand cmd = new SqlCommand
            {
                CommandText = "sp_InsertEvent",
                CommandType = CommandType.StoredProcedure,
                Connection = my1Connection
            };

            cmd.Parameters.AddWithValue("@name", newEvent.Name);
            cmd.Parameters.AddWithValue("@userID", id1);
            cmd.Parameters.AddWithValue("@data", newEvent.Date);
            cmd.Parameters.AddWithValue("@description", newEvent.Description);
            cmd.Parameters.AddWithValue("@place", newEvent.Place);
            cmd.Parameters.AddWithValue("@picture", PictureCategory);
            cmd.Parameters.AddWithValue("@category", id2);

            my1Connection.Open();

            int rowsAffected = cmd.ExecuteNonQuery();

            my1Connection.Close();

        }

        public void EditEvent(Event eventToEdit)
        {
            int id1, id2;

            using (this.myConnection = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd1 = new SqlCommand
                {
                    CommandText = "sp_GetIdOfOrganazerByEmail",
                    CommandType = CommandType.StoredProcedure,
                    Connection = myConnection
                };

                cmd1.Parameters.AddWithValue("@Email", eventToEdit.UserName);

                SqlCommand cmd2 = new SqlCommand
                {
                    CommandText = "sp_GetIdOfCategoryByName",
                    CommandType = CommandType.StoredProcedure,
                    Connection = myConnection
                };

                cmd2.Parameters.AddWithValue("@Name", eventToEdit.Category);

                myConnection.Open();

                id1 = (int)cmd1.ExecuteScalar();

                id2 = (int)cmd2.ExecuteScalar();

                myConnection.Close();
            }

            SqlConnection my1Connection = new SqlConnection(this.ConnectionString);

            string PictureCategory = GetCategoryById(id2).Picture;

            SqlCommand cmd = new SqlCommand
            {
                CommandText = "sp_EditEventById",
                CommandType = CommandType.StoredProcedure,
                Connection = my1Connection
            };

            cmd.Parameters.AddWithValue("@id", eventToEdit.ID);
            cmd.Parameters.AddWithValue("@name", eventToEdit.Name);
            cmd.Parameters.AddWithValue("@userID", id1);
            cmd.Parameters.AddWithValue("@data", eventToEdit.Date);
            cmd.Parameters.AddWithValue("@description", eventToEdit.Description);
            cmd.Parameters.AddWithValue("@place", eventToEdit.Place);
            cmd.Parameters.AddWithValue("@picture", PictureCategory);
            cmd.Parameters.AddWithValue("@category", id2);

            my1Connection.Open();

            int rowsAffected = cmd.ExecuteNonQuery();

            my1Connection.Close();

        }

        public void DeleteEvent(Event eventToDelete)
        {
            if (eventToDelete.Date > DateTime.Now)
            {
                using (this.myConnection = new SqlConnection(this.ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand
                    {
                        CommandText = "sp_DeleteEvent",
                        CommandType = CommandType.StoredProcedure,
                        Connection = myConnection
                    };
                    cmd.Parameters.AddWithValue("@id", eventToDelete.ID);

                    myConnection.Open();

                    cmd.ExecuteNonQuery();

                    myConnection.Close();
                }
            }
        }


        public void DeleteEventsOfUser(int userId)
        {        
                using (this.myConnection = new SqlConnection(this.ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand
                    {
                        CommandText = "sp_DeleteEventsOfUser",
                        CommandType = CommandType.StoredProcedure,
                        Connection = myConnection
                    };
                    cmd.Parameters.AddWithValue("@id", userId);

                    myConnection.Open();

                    cmd.ExecuteNonQuery();

                    myConnection.Close();
              
            }
        }

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

                myConnection.Close();
            }

            return res;
        }

        public void EditRole(Role roleToEdit)
        {
            using (this.myConnection = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "sp_EditRoleById",
                    CommandType = CommandType.StoredProcedure,
                    Connection = myConnection
                };

                cmd.Parameters.AddWithValue("@id", roleToEdit.ID);
                cmd.Parameters.AddWithValue("@name", roleToEdit.Name);
                cmd.Parameters.AddWithValue("@code", roleToEdit.Code);

                myConnection.Open();

                int rowsAffected = cmd.ExecuteNonQuery();

                myConnection.Close();

            }
        }

        public void DeleteRole(Role roleToDelete)
        {
            using (this.myConnection = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "sp_DeleteRole",
                    CommandType = CommandType.StoredProcedure,
                    Connection = myConnection
                };

                cmd.Parameters.AddWithValue("@id", roleToDelete.ID);

                myConnection.Open();

                int roewsaffected = cmd.ExecuteNonQuery();

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

                myConnection.Close();
            }

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
                        res.Picture = (string)reader["PicturePath"];

                        result.Add(res);
                    }
                }

                myConnection.Close();
            }
            
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
                            Name = (string)reader["Name"],
                            Picture = (string)reader["PicturePath"]
                        };

                    }
                }

                myConnection.Close();
            }
            
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

                int rows = cmd.ExecuteNonQuery();

                myConnection.Close();
            }
        }

        public void EditCategory(Category categoryToEdit)
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

                cmd.Parameters.AddWithValue("@id", categoryToEdit.CategoryID);
                cmd.Parameters.AddWithValue("@name", categoryToEdit.Name);

                myConnection.Open();

                int rowsAffected = cmd.ExecuteNonQuery();

                myConnection.Close();
            }
        }

        public void DeleteCategory(Category categoryToDelete)
        {
            using (this.myConnection = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "sp_DeleteCategory",
                    CommandType = CommandType.StoredProcedure,
                    Connection = myConnection
                };

                cmd.Parameters.AddWithValue("@id", categoryToDelete.CategoryID);

                myConnection.Open();

                int roewsaffected = cmd.ExecuteNonQuery();

                myConnection.Close();
            }
        }

    }
}

