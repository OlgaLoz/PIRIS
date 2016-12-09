using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;
using Lab1.Models;

namespace Lab1.Infrastucture
{
    public static class DataBase
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public static List<Nationality> Nationalities { get; } 
            = Get<Nationality>("SELECT * FROM Nationality");

        public static List<Town> Town { get; } 
            = Get<Town>("SELECT * FROM Town");

        public static List<FamilyStatus> FamilyStatuses { get; } 
            = Get<FamilyStatus>("SELECT * FROM FamilyStatus");

        public static List<Disability> Disabilities { get; }
            = Get<Disability>("SELECT * FROM Disability");

        public static List<Client> Clients => GetClients();

        private static List<T> Get<T>(string commandText)
        {
            var result = new List<T>();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand
                {
                    CommandText = commandText,
                    Connection = connection
                };

                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var tmp = new object[reader.FieldCount];
                        reader.GetValues(tmp);

                        T instance = (T)Activator.CreateInstance(typeof(T), new object[] {tmp[0], tmp[1]});
                        result.Add(instance);
                    }
                }

            }

            return result;
        }

        private static List<Client> GetClients()
        {
            var result = new List<Client>();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand
                {
                    CommandText = "SELECT * FROM Clients",
                    Connection = connection
                };

                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var client = new Client()
                        {
                             Id = reader.GetInt32(0),
                             LastName = reader.GetString(1),
                             FirstName = reader.GetString(2),
                             MidName = reader.GetString(3),
                             Birthday = reader.GetDateTime(4),
                             PassportNumber = reader.GetString(5),
                             PassportIssuedBy = reader.GetString(6),
                             PassportIssueDate = reader.GetDateTime(7),
                             PassrortIdNumber = reader.GetString(8),
                             BirthPlace = reader.GetString(9),
                             Address = reader.GetString(10),
                             HomePhone = reader.GetString(11),
                             MobilePhone = reader.GetString(12),
                             Mail = reader.GetString(13),
                             WorkPlace = reader.GetString(14),
                             WorkPosition = reader.GetString(15),
                             RegistrationAddress = reader.GetString(16),
                             Pensioner = reader.GetBoolean(17),
                             MounthIncome = reader.GetDecimal(18),
                             //Nationality = reader.GetInt32(19).ToString(),
                             //Disability = reader.GetInt32(20).ToString(),
                             //Town = reader.GetInt32(21).ToString(),
                             //FamilyStatus = reader.GetInt32(22).ToString()
                        };
                       
                        result.Add(client);
                    }
                }

            }

            return result;
        } 
    }
}