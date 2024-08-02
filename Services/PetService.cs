using MySql.Data.MySqlClient;
using TindogService.Controllers.Request;
using TindogService.Interfaces;
using TindogService.Querys;

namespace TindogService.Services
{
    public class PetService : IPetService
    {
        private readonly IConfiguration _configuration;
        private readonly DataBaseConnection _connection;

        public PetService(IConfiguration configuration, DataBaseConnection connection)
        {
            _configuration = configuration;
            _connection = connection;
        }
        public bool inserirPet(int idTutor, PetRequest pet)
        {
            using (MySqlConnection connection = _connection.CreateConnection())
            {
                string comando = Executa.inserirPet();
                MySqlCommand command = new MySqlCommand(comando, connection);
                command.Parameters.Add(new MySqlParameter("@id_tutor",idTutor ));
                command.Parameters.Add(new MySqlParameter("@nome_pet", pet.Nome));
                command.Parameters.Add(new MySqlParameter("@id_raca", pet.raca));
                command.Parameters.Add(new MySqlParameter("@dt_nascimento_pet", pet.DtNascimento));
                command.Parameters.Add(new MySqlParameter("@peso_pet", pet.Peso));
                command.Parameters.Add(new MySqlParameter("@id_genero", pet.Genero));
                command.Parameters.Add(new MySqlParameter("@qtd_vacinas_pet", pet.QtdVacinas));
                command.Parameters.Add(new MySqlParameter("@pedigree_pet", pet.Pedigree? 1:0));

                connection.Open();

                var linhasAfetadas = command.ExecuteNonQuery();

                return linhasAfetadas > 0;
            }
        }
    }
}
