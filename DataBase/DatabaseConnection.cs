using Business.Entities;
using Business.Models;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace DataBase
{
    public class DatabaseConnection : IDatabaseConnection
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["FligthsDB"].ConnectionString;

        public List<Fligth> GetFligths()
        {
            List<Fligth> fligths = new List<Fligth>();

            string query = "SELECT * FROM [DbFligths].[dbo].[vwfligths]";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Fligth fligth = new Fligth();
                        fligth.FligthId = reader.GetInt32(0);
                        fligth.Date =DateOnly.FromDateTime(reader.GetDateTime(1));
                        fligth.DepartureTime = TimeOnly.FromDateTime(reader.GetDateTime(2));
                        fligth.ArrivalTime = TimeOnly.FromDateTime(reader.GetDateTime(3));
                        fligth.Airline = reader.GetString(4);
                        fligth.DestinationCity = reader.GetString(5);
                        fligth.OriginCity = reader.GetString(6);
                        fligth.FlightStatus = reader.GetString(7);
                        fligths.Add(fligth);
                    }
                    reader.Close();

                    connection.Close();
                }
                catch 
                {
                    return null;
                }
            }
            return fligths;
        }

        public List<string> GetEntitiesName(string fieldName, string tableName)
        {
            List<string> entitiesName = new List<string>();

            string query = $"SELECT {fieldName} FROM [DbFligths].[dbo].[{tableName}]";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string name = string.Empty;
                        name = reader.GetString(0);
                        entitiesName.Add(name);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch 
                {
                    return null;
                }
            }
            return entitiesName;
        }

        public bool AddFligth(FligthDto fligthDto)
        {
            string query = "Insert into [DbFligths].[dbo].[Fligths] values (@Date, @DepartureTime, @ArrivalTime, @OriginCityId, @DestinationCityId, @AirlineId, @StatusId)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Date", fligthDto.Date);
                cmd.Parameters.AddWithValue("@DepartureTime", fligthDto.DepartureTime);
                cmd.Parameters.AddWithValue("@ArrivalTime",fligthDto.ArrivalTime);
                cmd.Parameters.AddWithValue("@OriginCityId", fligthDto.OriginCityId);
                cmd.Parameters.AddWithValue("@DestinationCityId", fligthDto.DestinationCityId);
                cmd.Parameters.AddWithValue("@AirlineId", fligthDto.AirlineId);
                cmd.Parameters.AddWithValue("@StatusId", fligthDto.FlightStatusId);

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    return true;
                }
                catch 
                {
                    return false;
                }
            }

        }

        public UserResultDto ValidateUser(string userName)
        {
            string query = $"SELECT * FROM [DbFligths].[dbo].[Users] where UserName = '{userName}'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                var userResult = new UserResultDto();

                try
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        userResult.UserName = reader.GetString(1);
                        userResult.PasswordHash = (byte[])reader[2];
                        userResult.PasswordSalt = (byte[])reader[3];
                    }
                    reader.Close();
                    connection.Close();
                    return userResult;

                }
                catch 
                {
                    return null;
                }
            }
        }

        public bool AddUser(UserToAdd user)
        {
            string query = "Insert into [DbFligths].[dbo].[Users] values (@UserName, @PasswordHash, @PasswordSalt)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@UserName", user.UserName);
                cmd.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
                cmd.Parameters.AddWithValue("@PasswordSalt", user.PasswordSalt);

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public bool AddAirline(string airline)
        {
            string query = "Insert into [DbFligths].[dbo].[AirLines] values (@AirlineName)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@AirlineName", airline);

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool AddCity(string city)
        {
            string query = "Insert into [DbFligths].[dbo].[Cities] values (@City)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@City", city);

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    return true;
                }
                catch 
                {
                    return false;
                }
            }
        }

        public bool AddStatus(string status)
        {
            string query = "Insert into [DbFligths].[dbo].[FligthStatus] values (@Status)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Status", status);

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public bool ValidateIfExists(string entityName, string fieldName, string tableName)
        {
            string query = $"SELECT COUNT(*) FROM [DbFligths].[dbo].[{tableName}] WHERE {fieldName}= '{entityName}'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    var result = Convert.ToInt32(cmd.ExecuteScalar());
                    connection.Close();
                    if (result == 0)
                        return false;

                    return true;

                }
                catch 
                {
                    return true;
                }
            }
        }

        public int GetEntityId(string name, string columnName, string table) 
        {
            string query = $"SELECT Id FROM [DbFligths].[dbo].[{table}] WHERE {columnName}= '{name}'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                int id = new int();

                try
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                       id = reader.GetInt32(0);     
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    return 0;
                }
                return id;
            }
        }

        public Fligth GetFligthById(int id)
        {
            Fligth fligth = new Fligth();
            string query = $"SELECT * FROM [DbFligths].[dbo].[vwFlight] WHERE FligthId= {id}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        fligth.FligthId = reader.GetInt32(0);
                        fligth.Date = DateOnly.FromDateTime(reader.GetDateTime(1));
                        fligth.DepartureTime = TimeOnly.FromDateTime(reader.GetDateTime(2));
                        fligth.ArrivalTime = TimeOnly.FromDateTime(reader.GetDateTime(3));
                        fligth.Airline = reader.GetString(4);
                        fligth.DestinationCity = reader.GetString(5);
                        fligth.OriginCity = reader.GetString(6);
                        fligth.FlightStatus = reader.GetString(7);
                    }
                    reader.Close();

                    connection.Close();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            return fligth;
        }
    }
}
