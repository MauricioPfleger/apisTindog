using MySql.Data.MySqlClient;
using System.Configuration;
using TinDog.Controllers;
using TindogService.Interfaces;
using TindogService.Objetos;
using TindogService.Querys;

namespace TindogService.Services
{
    public class TutorService : ITutorService
    {
        private readonly IConfiguration _configuration;

        public TutorService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Tutor> ConsultarTutor(string nome)
        {
            List<Tutor> listaTutores = new List<Tutor>();

            string connectionString = _configuration.GetConnectionString("MySqlConnection");

            MySqlConnection connection = new MySqlConnection(connectionString);

            string query = Consulta.ConsultaTutor();

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.Add(new MySqlParameter("@nome_tutor", nome));
            connection.Open();

            try
            {
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var tutor = listaTutores.FirstOrDefault(objeto => objeto.Id == reader.GetInt32("id_tutor"));
                    if (tutor == null)
                    {
                        tutor = new Tutor();

                        tutor.Id = reader.GetInt32("id_tutor");
                        tutor.Nome = reader.GetString("nome_tutor");
                        tutor.Sobrenome = reader.GetString("sobrenome_tutor");
                        tutor.DataNascimento = reader.GetDateTime("dt_nascimento_tutor");
                        tutor.Telefone = reader.GetInt64("telefone_tutor");
                        tutor.Genero = reader.GetString("genero_tutor");
                        tutor.Endereco.Id = reader.GetInt32("id_endereco");
                        tutor.Endereco.Rua = reader.GetString("rua_endereco");
                        tutor.Endereco.Numero = reader.GetInt32("numero_endereco");
                        tutor.Endereco.Bairro = reader.GetString("bairro_endereco");
                        tutor.Endereco.Cidade = reader.GetString("nome_cidade");
                        tutor.Endereco.Estado = reader.GetString("nome_estado");
                        tutor.Endereco.Cep = reader.GetInt32("cep_endereco");
                        tutor.Endereco.Pais = reader.GetString("nome_pais");
                    }

                    Pet pet = new Pet();
                    pet.Id = reader.GetInt32("id_pet");
                    pet.Nome = reader.GetString("nome_pet");
                    pet.Raca = reader.GetString("nome_raca");
                    pet.DataNascimento = reader.GetDateTime("dt_nascimento_pet");
                    pet.Peso = reader.GetDouble("peso_pet");
                    pet.Genero = reader.GetString("genero_pet");
                    pet.QtdVacinas = reader.GetInt32("qtd_vacinas_pet");
                    pet.Pedigree = reader.GetInt32("pedigree_pet") == 1 ? true : false;

                    tutor.Pets.Add(pet);

                    listaTutores.Add(tutor);
                }
            }
            catch
            {
                connection.Close();
            }           

            return listaTutores;
        }
    }
}
