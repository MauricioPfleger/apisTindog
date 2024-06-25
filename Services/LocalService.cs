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
            List<Cidade> listaCidade = new List<CidadeResponse>();  

        string connectionString = _configuration.GetConnectionString("MySqlConnection");

        MySqlConnection connection = new MySqlConnection(connectionString);

        string query = Consulta.ConsultaTutorPets();

        MySqlCommand command = new MySqlCommand(query, connection);
        command.Parameters.Add(new MySqlParameter("@id_tutor", idTutor));
            connection.Open();

            try
            {
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Pet pet = new Pet();
        pet.Id = reader.GetInt32("id_pet");
                    pet.Nome = reader.GetString("nome_pet");
                    pet.Raca = reader.GetString("nome_raca");
                    pet.DataNascimento = reader.GetDateTime("dt_nascimento_pet");
                    pet.Peso = reader.GetDouble("peso_pet");
                    pet.Genero = reader.GetString("genero_pet");
                    pet.QtdVacinas = reader.GetInt32("qtd_vacinas_pet");
                    pet.Pedigree = reader.GetInt32("pedigree_pet") == 1 ? true : false;

                    listaPets.Add(pet);
                }
}
            catch
            {
                // connection.Close();
            }

            connection.Close();

            return listaPets;
        }

    }
}
