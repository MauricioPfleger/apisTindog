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

        public List<Pais> ConsultaPaises()
        {
            List<Pais> listaPaises = new List<Pais>();

            string connectionString = _configuration.GetConnectionString("MySqlConnection");

            MySqlConnection connection = new MySqlConnection(connectionString);

            string query = Consulta.ConsultaPaises();

            MySqlCommand command = new MySqlCommand(query, connection);

            connection.Open();

            try
            {
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Pais pais = new Pais();
                    pais.Id = reader.GetInt32("id_pais");
                    pais.Nome = reader.GetString("nome_pais");

                    listaPaises.Add(pais);
                }
            }
            catch
            {
                // connection.Close();
            }

            connection.Close();

            return listaPaises;
        }

        public List<CidadeResponse> ConsultaCidades(int idEstado)
        {
            List<CidadeResponse> listaCidade = new List<CidadeResponse>();

            string connectionString = _configuration.GetConnectionString("MySqlConnection");

            MySqlConnection connection = new MySqlConnection(connectionString);

            string query = Consulta.ConsultaCidades();

            MySqlCommand command = new MySqlCommand(query, connection);
            command. Parameters.Add(new MySqlParameter("@id_estado", idEstado));

            connection.Open();

            try
            {
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    CidadeResponse cidade = new CidadeResponse();
                    cidade.Id = reader.GetInt32("id_cidade");
                    cidade.Nome = reader.GetString("nome_cidade");
                 

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
 

        public List<EstadoResponse> ConsultaEstados(int idPais)
        { 
                List<EstadoResponse> listaEstado = new List<EstadoResponse>();

                string connectionString = _configuration.GetConnectionString("MySqlConnection");

                MySqlConnection connection = new MySqlConnection(connectionString);

                string query = Consulta.ConsultaEstado();

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.Add(new MySqlParameter("id_pais", idPais));
                connection.Open();

                try
                {
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        EstadoResponse estado = new EstadoResponse();
                        estado.Id = reader.GetInt32("id_estado");
                        estado.Nome = reader.GetString("nome_estado");
                       
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
