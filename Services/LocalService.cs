using MySql.Data.MySqlClient;
using System.Data.Common;
using TindogService.Controllers.Responses;
using TindogService.Interfaces;
using TindogService.Objetos;
using TindogService.Querys;

namespace TindogService.Services
{
    public class LocalService : ILocalService
    {
        private readonly IConfiguration _configuration;
        private readonly DataBaseConnection _connection;

        public LocalService(IConfiguration configuration, DataBaseConnection connection)
        {
            _configuration = configuration;
            _connection = connection;
        }

        public List<Pais> ConsultaPaises()
        {
            List<Pais> listaPaises = new List<Pais>();

            using (MySqlConnection connection = _connection.CreateConnection())
            {
                string query = Consulta.ConsultaPaises();

                MySqlCommand command = new MySqlCommand(query, connection);

                connection.Open();

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Pais pais = new Pais();
                    pais.Id = reader.GetInt32("id_pais");
                    pais.Nome = reader.GetString("nome_pais");

                    listaPaises.Add(pais);
                }
            }

            return listaPaises;
        }

        public List<CidadeResponse> ConsultaCidades(int idEstado)
        {
            List<CidadeResponse> listaCidade = new List<CidadeResponse>();

            using (MySqlConnection connection = _connection.CreateConnection())
            {
                string query = Consulta.ConsultaCidades();

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.Add(new MySqlParameter("@id_estado", idEstado));

                connection.Open();

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    CidadeResponse cidade = new CidadeResponse();
                    cidade.Id = reader.GetInt32("id_cidade");
                    cidade.Nome = reader.GetString("nome_cidade");


                    listaCidade.Add(cidade);
                }
            }

            return listaCidade;
        }


        public List<EstadoResponse> ConsultaEstados(int idPais)
        {
            List<EstadoResponse> listaEstado = new List<EstadoResponse>();

            using (MySqlConnection connection = _connection.CreateConnection())
            {
                string query = Consulta.ConsultaEstado();

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.Add(new MySqlParameter("id_pais", idPais));

                connection.Open();

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    EstadoResponse estado = new EstadoResponse();
                    estado.Id = reader.GetInt32("id_estado");
                    estado.Nome = reader.GetString("nome_estado");

                    listaEstado.Add(estado);
                }
            }

            return listaEstado;
        }
    }
}
