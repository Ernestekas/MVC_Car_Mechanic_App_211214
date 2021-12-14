using System.Collections.Generic;
using System.Data.SqlClient;
using Project.Models;
using Dapper;
using System.Linq;
using System;

namespace Project.Services
{
    public class RepairshopService
    {
        private SqlConnection _connection;
        public RepairshopService(SqlConnection connection)
        {
            _connection = connection;
        }
        
        public List<MechanicModel> GetAllMechanics()
        {
            string query = "SELECT * FROM dbo.Mechanics";
            return _connection.Query<MechanicModel>(query).ToList();
        }

        public void AddNewMechanic(MechanicModel model)
        {
            if (string.IsNullOrWhiteSpace(model.FirstName) || string.IsNullOrWhiteSpace(model.Surname) || model.Experience < 0)
            {
                throw new Exception();
            }
            string query = $"INSERT INTO dbo.Mechanics (FirstName, Surname, Experience) VALUES ('{model.FirstName}','{model.Surname}',{model.Experience})";
            _connection.Query<MechanicModel>(query);
        }

        public void DeleteMechanic(MechanicModel model)
        {
            string query = $"DELETE FROM dbo.Mechanics WHERE Id={model.Id}";
            _connection.Query<MechanicModel>(query);
        }

        public void UpdateMechanic(MechanicModel model)
        {
            if (string.IsNullOrWhiteSpace(model.FirstName) || string.IsNullOrWhiteSpace(model.Surname) || model.Experience < 0)
            {
                throw new Exception();
            }
            string query =
                $"UPDATE dbo.Mechanics SET FirstName='{model.FirstName}', Surname='{model.Surname}', Experience={model.Experience} WHERE Id={model.Id}";
            _connection.Query<MechanicModel>(query);
        }
    }
}
