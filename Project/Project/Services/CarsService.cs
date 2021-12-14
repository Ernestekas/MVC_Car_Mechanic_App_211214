using Dapper;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Project.Services
{
    public class CarsService
    {
        private SqlConnection _connection;
        public CarsService(SqlConnection connection)
        {
            _connection = connection;
        }

        public List<CarModel> GetAllCars()
        {
            string query = "SELECT * FROM dbo.Cars";
            return _connection.Query<CarModel>(query).ToList();
        }

        public void AddNewCar(CarModel model)
        {
            if (model.YearManufactured < 1900 || string.IsNullOrWhiteSpace(model.Manufacturer) || string.IsNullOrWhiteSpace(model.PlateNumbers))
            {
                throw new Exception();
            }
            string query = $"INSERT INTO dbo.Cars (YearManufactured, Manufacturer, PlateNumbers, MechanicId) " +
                             $"VALUES ({model.YearManufactured},'{model.Manufacturer}','{model.PlateNumbers}',{model.MechanicId})";
            _connection.Query<MechanicModel>(query);
        }

        public void DeleteCar(CarModel model)
        {
            string query = $"DELETE FROM dbo.Cars WHERE Id={model.Id}";
            _connection.Query<MechanicModel>(query);
        }

        public void UpdateCar(CarModel model)
        {
            if (model.YearManufactured < 1900 || string.IsNullOrWhiteSpace(model.Manufacturer) || string.IsNullOrWhiteSpace(model.PlateNumbers))
            {
                throw new Exception();
            }
            string query =
                $"UPDATE dbo.Cars " +
                $"SET YearManufactured={model.YearManufactured}, Manufacturer='{model.Manufacturer}', PlateNumbers='{model.PlateNumbers}',MechanicId={model.MechanicId} " +
                $"WHERE Id={model.Id}";
            _connection.Query<MechanicModel>(query);
        }
    }
}
