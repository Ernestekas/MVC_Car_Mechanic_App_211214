using System.Collections.Generic;
using System.Data.SqlClient;
using Project.Models;
using Dapper;
using System.Linq;

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
            string query = $"INSERT INTO dbo.Mechanics (FirstName, Surname, Experience) VALUES ('{model.FirstName}','{model.Surname}',{model.Experience})";
            _connection.Query<MechanicModel>(query);
        }
    }
}
