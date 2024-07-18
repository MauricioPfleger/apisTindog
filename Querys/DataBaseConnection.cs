using MySql.Data.MySqlClient;

namespace TindogService.Querys
{
    public class DataBaseConnection
    {
        private readonly IConfiguration _configuration;

        public DataBaseConnection(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public MySqlConnection CreateConnection()
        {
            string connectionString = _configuration.GetConnectionString("MySqlConnection");
            return new MySqlConnection(connectionString);
        }
    }
}
