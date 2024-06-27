using MySql.Data.MySqlClient;
using TindogService.Controllers.Responses;
using TindogService.Interfaces;
using TindogService.Objetos;
using TindogService.Querys;

namespace TindogService.Services
{
    public class LocalService : ILocalService
    {
        private readonly IConfiguration _configuration;

        public LocalService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Acrescertar cada 1 o seu método de operação da integração com o banco de dados

        public List<CidadeResponse> ConsultaCidades()
        {
            List<CidadeResponse> listaCidade = new List<CidadeResponse>();

            string connectionString = _configuration.GetConnectionString("MySqlConnection");

            MySqlConnection connection = new MySqlConnection(connectionString);

            string query = Consulta.ConsultaTutorPets();

            MySqlCommand command = new MySqlCommand(query, connection);

            connection.Open();

            try
            {
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    CidadeResponse cidade = new CidadeResponse();
                    cidade.Id = reader.GetInt32("id_cidade");
                    cidade.Nome = reader.GetString("nome_cidade");
                    cidade.NomeEstado = reader.GetString("nome_estado");

                    listaCidade.Add(cidade);
                }
            }
            catch
            {
                // connection.Close();
            }

            connection.Close();

            return listaCidade;
        }

        public List<EstadoResponse> ConsultaEstados()
        {
            throw new NotImplementedException();
        }
    }
}
