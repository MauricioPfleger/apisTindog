using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Org.BouncyCastle.Crypto.Macs;
using System.Collections.Generic;
using System.Configuration;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using TinDog.Controllers;
using TindogService.Controllers.Request;
using TindogService.Controllers.Responses;
using TindogService.Interfaces;
using TindogService.Objetos;
using TindogService.Querys;

namespace TindogService.Services
{
    public class TutorService : ITutorService
    {
        private readonly IConfiguration _configuration;
        private readonly DataBaseConnection _connection;

        public TutorService(IConfiguration configuration, DataBaseConnection connection)
        {
            _configuration = configuration;
            _connection = connection;
        }

        public TutorService()
        {
        }

        public List<Tutor> ConsultarTutor(string nome)
        {
            List<Tutor> listaTutores = new List<Tutor>();

            using (MySqlConnection connection = _connection.CreateConnection())
            {
                string query = Consulta.ConsultaTutor();

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.Add(new MySqlParameter("@nome_tutor", nome));

                connection.Open();

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
                                       
                    if (pet.Pedigree)
                        tutor.Pets.Add(pet);

                    listaTutores.Add(tutor);
                }
            }

            return listaTutores;
        }

        public List<Pet> ConsultarTutorPets(int idTutor)
        {
            List<Pet> listaPets = new List<Pet>();

            using (MySqlConnection connection = _connection.CreateConnection())
            {
                string query = Consulta.ConsultaTutorPets();

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.Add(new MySqlParameter("@id_tutor", idTutor));

                connection.Open();

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

            return listaPets;
        }

        public Endereco? ConsultarTutorEndereco(int idTutor)
        {
            using (MySqlConnection connection = _connection.CreateConnection())
            {
                string query = Consulta.ConsultaTutorEndereco();

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.Add(new MySqlParameter("@id_tutor", idTutor));

                connection.Open();

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Endereco endereco = new Endereco();
                    endereco.Id = reader.GetInt32("id_endereco");
                    endereco.Rua = reader.GetString("rua_endereco");
                    endereco.Numero = reader.GetInt32("numero_endereco");
                    endereco.Bairro = reader.GetString("bairro_endereco");
                    endereco.Cidade = reader.GetString("nome_cidade");
                    endereco.Estado = reader.GetString("nome_estado");
                    endereco.Pais = reader.GetString("nome_pais");
                    endereco.Cep = reader.GetInt32("cep_endereco");
                    endereco.Complemento = reader.GetString("complemento_endereco");
                    connection.Close();
                    return endereco;
                }
                else
                {
                    return null;
                }
            }
        }

        public List<Pet> ConsultarPets(int idPais, int idEstado, int idCidade)
        {
            List<Pet> listaPets = new List<Pet>();

            using (MySqlConnection connection = _connection.CreateConnection())
            {
                string query = Consulta.ConsultaPets();

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.Add(new MySqlParameter("@id_pais", idPais));
                command.Parameters.Add(new MySqlParameter("@id_estado", idEstado));
                command.Parameters.Add(new MySqlParameter("@id_cidade", idCidade));

                connection.Open();

                MySqlDataReader consulta = command.ExecuteReader();

                while (consulta.Read())
                {
                    Pet pet = new Pet();
                    pet.Id = consulta.GetInt32("id_pet");
                    pet.Nome = consulta.GetString("nome_pet");
                    pet.Raca = consulta.GetString("nome_raca");
                    pet.DataNascimento = consulta.GetDateTime("dt_nascimento_pet");
                    pet.Peso = consulta.GetDouble("peso_pet");
                    pet.Genero = consulta.GetString("nome_genero");
                    pet.QtdVacinas = consulta.GetInt32("qtd_vacinas_pet");
                    pet.Pedigree = consulta.GetInt32("pedigree_pet") == 1 ? true : false;

                    listaPets.Add(pet);
                }
            }

            return listaPets;
        }

        public EnderecoResponse CadastrarEndereco(EnderecoRequest enderecoRequest)
        {
            EnderecoResponse endereco = new EnderecoResponse();

            using (MySqlConnection connection = _connection.CreateConnection())
            {
                string comando = Executa.CadastrarEndereco(enderecoRequest);

                MySqlCommand command = new MySqlCommand(comando, connection);
                command.Parameters.Add(new MySqlParameter("@id_cidade", enderecoRequest.idCidade));
                command.Parameters.Add(new MySqlParameter("@rua_endereco", enderecoRequest.rua));
                if (enderecoRequest.numero > 0)
                {
                    command.Parameters.Add(new MySqlParameter("@numero_endereco", enderecoRequest.numero));
                }
                command.Parameters.Add(new MySqlParameter("@bairro_endereco", enderecoRequest.bairro));
                if (enderecoRequest.cep > 0)
                {
                    command.Parameters.Add(new MySqlParameter("@cep_endereco", enderecoRequest.cep));
                }
                if (!String.IsNullOrEmpty(enderecoRequest.complemento))
                {
                    command.Parameters.Add(new MySqlParameter("@complemento_endereco", enderecoRequest.complemento));
                }

                connection.Open();

                endereco.idEndereco = Convert.ToInt32(command.ExecuteScalar());
            }

            return endereco;
        }

        public void ValidarTutorEndereco(EnderecoRequest enderecoRequest)
        {
            if (enderecoRequest.idCidade == null || enderecoRequest.idCidade == 0)
            {
                throw new Exception("É necessário informar o Id da Cidade");
            }

            if (String.IsNullOrEmpty(enderecoRequest.rua))
            {
                throw new Exception("É necessário informar a Rua");
            }

            if (String.IsNullOrEmpty(enderecoRequest.bairro))
            {
                throw new Exception("É necessário informar o Bairro");
            }

            if (
                (enderecoRequest.numero == null || enderecoRequest.numero == 0) &&
                String.IsNullOrEmpty(enderecoRequest.complemento)
               )
            {
                throw new Exception("É necessário informar o Número ou o Complemento");
            }
        }

        public bool Logar(LoginRequest loginRequest)
        {
            using (MySqlConnection connection = _connection.CreateConnection())
            {
                MySqlCommand comando = new MySqlCommand(Consulta.Login(), connection);
                comando.Parameters.AddWithValue("@email", loginRequest.email);
                comando.Parameters.AddWithValue("@senha", loginRequest.senha);

                connection.Open();

                MySqlDataReader consulta = comando.ExecuteReader();

                return consulta.Read();
            }
        }

        public bool AtualizarEndereco(int idEndereco, EnderecoRequest endereco)
        {
            using (MySqlConnection connection = _connection.CreateConnection())
            {
                MySqlCommand comando = new MySqlCommand(Executa.UpdateEndereco(), connection);
                comando.Parameters.AddWithValue("@cidade", endereco.idCidade);
                comando.Parameters.AddWithValue("@rua", endereco.rua);
                comando.Parameters.AddWithValue("@numero", endereco.numero);
                comando.Parameters.AddWithValue("@bairro", endereco.bairro);
                comando.Parameters.AddWithValue("@cep", endereco.cep);
                comando.Parameters.AddWithValue("@complemento", endereco.complemento);
                comando.Parameters.AddWithValue("@id", idEndereco);

                connection.Open();

                var linhasAfetadas = comando.ExecuteNonQuery();

                if (linhasAfetadas > 0)
                    return true;

                return false;
            }
        }
    }
}
    

