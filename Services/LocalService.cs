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

        public List<CidadeResponse> ConsultaCidades()
        {
            throw new NotImplementedException();
        }

        // Acrescertar cada 1 o seu método de operação da integração com o banco de dados

        public List<EstadoResponse> ConsultaEstados()
        { 
                List<EstadoResponse> listaEstado = new List<EstadoResponse>();

                string connectionString = _configuration.GetConnectionString("MySqlConnection");

                MySqlConnection connection = new MySqlConnection(connectionString);

                string query = Consulta.ConsultaEstado();

                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();

                try
                {
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        EstadoResponse estado = new EstadoResponse();
                        estado.Id = reader.GetInt32("id_estado");
                        estado.Nome = reader.GetString("nome_estado");
                        estado.NomePais = reader.GetString("nome_pais");
                       
                        listaEstado.Add(estado);
                    }
                }
                catch
                {
                    // connection.Close();
                }

                connection.Close();

                return listaEstado;
            }
    }
}
