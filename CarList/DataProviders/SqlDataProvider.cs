using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CarList.Models;

namespace CarList.DataProviders
{
    public class SqlDataProvider : ICustomDataProvider
    {
        private string ConnectionString { get; }

        public SqlDataProvider(string dbConnectionString)
        {
            ConnectionString = dbConnectionString;
        }
        
        public IEnumerable<Car> GetAllCars()
        {
            var cars = new List<Car>();

            using var connection = new SqlConnection(ConnectionString);
            var command = new SqlCommand("SELECT * FROM dbo.Car", connection);
            command.CommandType = CommandType.Text;

            connection.Open();
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var car = new Car
                {
                    ID = Convert.ToInt32(reader["ID"]),
                    Brand = reader["Brand"].ToString(),
                    Model = reader["Model"].ToString(),
                    Production = Convert.ToInt32(reader["Production"])
                };
                cars.Add(car);
            }
            connection.Close();

            return cars;
        }

        public void CreateNewCar(Car car)
        {
            using var connection = new SqlConnection(ConnectionString);
            using var command = connection.CreateCommand();
            command.CommandText =
                "INSERT INTO dbo.Car (Brand, Model, Production) VALUES (@brand, @model, @production)";

            command.Parameters.AddWithValue("@brand", car.Brand);
            command.Parameters.AddWithValue("@model", car.Model);
            command.Parameters.AddWithValue("@production", car.Production);


            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void UpdateCar(Car car)
        {
            using var connection = new SqlConnection(ConnectionString);
            using var command = connection.CreateCommand();
            command.CommandText = 
                "UPDATE dbo.Car SET Brand = @brand, Model = @model, Production = @production WHERE ID =  @id";

            command.Parameters.AddWithValue("@brand", car.Brand);
            command.Parameters.AddWithValue("@model", car.Model);
            command.Parameters.AddWithValue("@production", car.Production);
            command.Parameters.AddWithValue("@id", car.ID);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public Car GetCarData(int? id)
        {
            var car = new Car();

            using var connection = new SqlConnection(ConnectionString);
            var sqlQuery = "SELECT * FROM dbo.Car WHERE Id = " + id;
            var command = new SqlCommand(sqlQuery, connection);

            connection.Open();
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                car.ID = Convert.ToInt32(reader["ID"]);
                car.Brand = reader["Brand"].ToString();
                car.Model = reader["Model"].ToString();
                car.Production = Convert.ToInt32(reader["Production"]);
            }

            return car;
        }

        public void DeleteCar(int? id)
        {
            using var connection = new SqlConnection(ConnectionString);
            var command = new SqlCommand($"DELETE FROM dbo.Car WHERE Id = {id}", connection);
            command.CommandType = CommandType.Text;

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}