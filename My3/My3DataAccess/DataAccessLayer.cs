using My3Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My3DataAccess
{
    public class DataAccessLayer : IDataAccessLayer
    {
        private SqlConnection myConnection;

        public DataAccessLayer()
        {
            try
            {
                myConnection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            myConnection.Close();
        }

        private readonly string ConnectionString = ConfigurationManager.ConnectionStrings["My3EventDataBase"].ConnectionString;

        public User GetUserByLogin(string userName, string userPassword)
        {
    
            User result = null;

            using (this.myConnection = new SqlConnection(this.ConnectionString))
            {
                string sqlCommand = "exec sp_GetUserById @Name, @Password";

                SqlCommand cmd = new SqlCommand(sqlCommand, this.myConnection);
                cmd.Parameters.AddWithValue("@Name", userName);
                cmd.Parameters.AddWithValue("@Password", userPassword);

                this.myConnection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result = new User
                        {
                            Name = (string)reader["Name"],
                            ID = (int)reader["UserID"],
                            Email = (string)reader["E-mail"]
                        };
                    }
                }
            }
            return result;
        }

        public void GetEvents()
        {
            Event result = null;

            using (this.myConnection = new SqlConnection(this.ConnectionString))
            {
                string sqlCommand = "exec sp_GetEvent";

                SqlCommand cmd = new SqlCommand(sqlCommand, this.myConnection);
            
                this.myConnection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result = new Event
                        {
                            Name = (string)reader["Name"],
                            ID = (int)reader["Id"],
                            Place = (string)reader["Place"],
                            UserID = (int)reader["UserID"],
                            Date = (DateTime)reader["Date"],
                            Description = (string)reader["Description"],
                            Picture = (string)reader["Picture"]
                        };
                    }
                }
            }
           // return result;
        }

        public Event GetEventById(int id)
        {

            Event result = null;

            using (this.myConnection = new SqlConnection(this.ConnectionString))
            {
                string sqlCommand = "exec sp_GetEventById @id";

                SqlCommand cmd = new SqlCommand(sqlCommand, this.myConnection);
                cmd.Parameters.AddWithValue("@id", id);
                this.myConnection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result = new Event
                        {
                            Name = (string)reader["Name"],
                            ID = (int)reader["Id"],
                            Place = (string)reader["Place"],
                            UserID=(int)reader ["UserID"],
                            Date=(DateTime)reader["Date"],
                            Description=(string)reader ["Description"],
                            Picture=(string)reader["Picture"]
                        };
                    }
                }
            }
            return result;
        }

        //private static void GetUsers()
        //{
        //    // название процедуры
        //    string sqlExpression = "sp_GetUsers";

        //    using (this.myConnection = new SqlConnection(this.ConnectionString))
        //    {
        //        myConnection.Open();
        //        SqlCommand command = new SqlCommand(sqlExpression, myConnection);
        //        // указываем, что команда представляет хранимую процедуру
        //        command.CommandType = System.Data.CommandType.StoredProcedure;
        //        var reader = command.ExecuteReader();

        //        if (reader.HasRows)
        //        {
        //           while (reader.Read())
        //            {
        //                int id = reader.GetInt32(0);
        //                string name = reader.GetString(1);
        //                int age = reader.GetInt32(2);
        //            }
        //        }
        //        reader.Close();
        //    }
        //}

        public void AddCategory(string category)
        {
            // название процедуры
            string sqlExpression = "sp_InsertCategory";

            using (myConnection)
            {
                myConnection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, myConnection);
                // указываем, что команда представляет хранимую процедуру
                command.CommandType = System.Data.CommandType.StoredProcedure;
                // параметр для ввода имени
                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "@name",
                    Value = category
                };
                // добавляем параметр
                command.Parameters.Add(nameParam);
                var result = command.ExecuteNonQuery();
            }
        }

        public Category GetCategory(int id)
        {
            // Get data from DataBase

            // Mapping from DB entity to category

            // Exception handling

            return new Category { ID = 5 };
        }

        public User GetUser(int id)
        {
            
            // Get data from DataBase

            // Mapping from DB entity to category

            // Exception handling

            return new User { ID=1, Email="email", AddedDate=DateTime.Today, Name="name", Password="password", PhoneNumber="phonenumber" };
        }
    }
}

