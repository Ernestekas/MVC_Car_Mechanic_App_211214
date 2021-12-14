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
        
        public List<Mechanic> GetAllMechanics()
        {
            string query = "SELECT * FROM dbo.Mechanics";
            return _connection.Query<Mechanic>(query).ToList();
        }
    }
}
