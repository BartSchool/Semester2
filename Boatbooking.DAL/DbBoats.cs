﻿using BoatBookingCore;
using Microsoft.Data.SqlClient;

namespace BoatbookingDAL
{
    public class DbBoats
    {
        private readonly string connectionString = @"Server=LAPTOP-1JC5056U\SQLEXPRESS; Database=Bootbooking; Trusted_Connection=True";

        public void addBoatToDb(string name, string type)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            var command = new SqlCommand(
                "IF not exists (SELECT * FROM Boats WHERE Name = '" + name + "') " +
                "BEGIN " +
                "INSERT INTO Boats(name, type, weightMax, weightMin, Authorizations) " +
                "VALUES ('" + name + "','" + type + "', null, null, null) " +
                "END",
                connection);
            var reader = command.ExecuteReader();

            connection.Close();
        }
        public void addBoatToDb(string name, string type, string Authorised)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            var command = new SqlCommand(
                "IF not exists (SELECT * FROM Boats WHERE Name = '" + name + "') " +
                "BEGIN " +
                "INSERT INTO Boats(name, type, weightMax, weightMin, Authorizations) " +
                "VALUES ('" + name + "','" + type + "', null, null, '" + Authorised + "') " +
                "END",
                connection);
            var reader = command.ExecuteReader();

            connection.Close();
        }
        public void addBoatToDb(string name, string type, int? weightMin, int? weightMax)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            var command = new SqlCommand(
                "IF not exists (SELECT * FROM Boats WHERE Name = '" + name + "') " +
                "BEGIN " +
                "INSERT INTO Boats(name, type, weightMax, weightMin, Authorizations) " +
                "VALUES ('" + name + "','" + type + "'," + weightMin + "," + weightMax + ", null) " +
                "END",
                connection);
            var reader = command.ExecuteReader();

            connection.Close();
        }
        public void addBoatToDb(string name, string type, int? weightMin, int? weightMax, string? Authorised)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            var command = new SqlCommand(
                "IF not exists (SELECT * FROM Boats WHERE Name = '" + name + "') " +
                "BEGIN " +
                "INSERT INTO Boats(name, type, weightMax, weightMin, Authorizations) " +
                "VALUES ('" + name + "','" + type + "'," + weightMin + "," + weightMax + ",'" + Authorised + "') " +
                "END",
                connection);
            var reader = command.ExecuteReader();

            connection.Close();
        }
        public void removeBoatFromDb(string name, string type)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            var command = new SqlCommand(" DELETE FROM Boats WHERE Name = '" + name + "' and Type = '" + type + "'", connection);
            var reader = command.ExecuteReader();

            connection.Close();
        }

        public List<Boat> GetBoatsFromDataBase()
        {
            List<Boat> boatList = new List<Boat>();

            using var connection = new SqlConnection(connectionString);

            connection.Open();

            var command = new SqlCommand(" SELECT * FROM Boats", connection);
            var reader = command.ExecuteReader();

            if (reader != null)
                while (reader.Read())
                {
                    string name = reader.GetString(1);

                    string type = reader.GetString(2);

                    int? max = null;
                    if (!reader.IsDBNull(3))
                        max = reader.GetInt32(3);

                    int? min = null;
                    if (!reader.IsDBNull(4))
                        min = reader.GetInt32(4);

                    string? authorised = null;
                    if (!reader.IsDBNull(5))
                        authorised = reader.GetString(5);


                    boatList.Add(new Boat(name, type, max, min, authorised));
                }
            connection.Close();

            return boatList;
        }
        public List<Boat> GetBoatsFromDataBase(string Name)
        {
            List<Boat> boatList = new List<Boat>();

            using var connection = new SqlConnection(connectionString);

            connection.Open();

            var command = new SqlCommand(" SELECT * FROM Boats WHERE name = " + Name, connection);
            var reader = command.ExecuteReader();

            if (reader != null)
                while (reader.Read())
                {
                    string name = reader.GetString(1);

                    string type = reader.GetString(2);

                    int? max = null;
                    if (!reader.IsDBNull(3))
                        max = reader.GetInt32(3);

                    int? min = null;
                    if (!reader.IsDBNull(4))
                        min = reader.GetInt32(4);

                    string? authorised = null;
                    if (!reader.IsDBNull(5))
                        authorised = reader.GetString(5);


                    boatList.Add(new Boat(name, type, max, min, authorised));
                }
            connection.Close();

            return boatList;
        }
        public List<Boat> GetBoatsFromDataBase(int id)
        {
            List<Boat> boatList = new List<Boat>();

            using var connection = new SqlConnection(connectionString);

            connection.Open();

            var command = new SqlCommand(" SELECT * FROM Boats WHERE id = " + id, connection);
            var reader = command.ExecuteReader();

            if (reader != null)
                while (reader.Read())
                {
                    string name = reader.GetString(1);

                    string type = reader.GetString(2);

                    int? max = null;
                    if (!reader.IsDBNull(3))
                        max = reader.GetInt32(3);

                    int? min = null;
                    if (!reader.IsDBNull(4))
                        min = reader.GetInt32(4);

                    string? authorised = null;
                    if (!reader.IsDBNull(5))
                        authorised = reader.GetString(5);


                    boatList.Add(new Boat(name, type, max, min, authorised));
                }
            connection.Close();

            return boatList;
        }

        public List<string> getBoatTypes()
        {
            List<string> boatTypes = new List<string>();
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            var command = new SqlCommand(" SELECT * FROM boatTypes", connection);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                boatTypes.Add(reader.GetString(0));
            }

            connection.Close();
            return boatTypes;
        }

        public bool DoesBoatExistInDataBase(string name)
        {
            using var connection = new SqlConnection(connectionString);

            connection.Open();

            var command = new SqlCommand(" SELECT * FROM Boats where name = '" + name + "'", connection);
            var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                connection.Close();
                return true;
            }

            connection.Close();
            return false;
        }
    }
}
