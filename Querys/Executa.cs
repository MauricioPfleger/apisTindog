using System.Text;
using TindogService.Controllers.Request;

namespace TindogService.Querys
{
    public class Executa
    {
        public static string CadastrarEndereco(EnderecoRequest enderecoRequest)
        {
            StringBuilder comando = new StringBuilder();
            comando.Append("INSERT INTO dbtindog.endereco (id_cidade, rua_endereco, bairro_endereco,");

            if (enderecoRequest.numero > 0)
            {
                comando.Append(", numero_endereco");
            }

            if (enderecoRequest.cep > 0)
            {
                comando.Append(", cep_endereco");
            }

            if (!String.IsNullOrEmpty(enderecoRequest.complemento))
            {
                comando.Append(", complemento_endereco");
            }

            comando.Append(") VALUES (@id_cidade, @rua_endereco, @bairro_endereco");

            if (enderecoRequest.numero > 0)
            {
                comando.Append(", @numero_endereco");
            }

            if (enderecoRequest.cep > 0)
            {
                comando.Append(", @cep_endereco");
            }

            if (!String.IsNullOrEmpty(enderecoRequest.complemento))
            {
                comando.Append(", @complemento_endereco");
            }

            comando.Append("); SELECT last_insert_id();");

            return comando.ToString();
        }
        public static string inserirPet() 
            {
            return @"INSERT INTO `dbtindog`.`pet`
                    (
                    `id_tutor`,
                    `nome_pet`,
                    `id_raca`,
                    `dt_nascimento_pet`,
                    `peso_pet`,
                    `id_genero`,
                    `qtd_vacinas_pet`,
                    `pedigree_pet`)
                    VALUES
                    (
                    @id_tutor,
                    @nome_pet,
                    @id_raca,
                    @dt_nascimento_pet,
                    @peso_pet,
                    @id_genero,
                    @qtd_vacinas_pet,
                    @pedigree_pet)
                    ";
        
            }


        public static string UpdateEndereco()
        {
            return @"UPDATE endereco SET id_cidade = @cidade, rua_endereco = @rua, numero_endereco = @numero, 
                        bairro_endereco = @bairro, cep_endereco = @cep, complemento_endereco = @complemento
                        where id_endereco = @id";
        }

        public static string DeletarEndereco()
        {
            return "DELETE FROM endereco WHERE id_endereco = @id";
        }
        public static string DeletarTutor()
        {
            return "DELETE FROM tutor WHERE id_tutor = @id";
        }
        public static string AtualizarPet()
        {
            return @"UPDATE `dbtindog`.`pet`
                SET
                `nome_pet` = @nomePet, 
                `id_raca` = @raca,
                `dt_nascimento_pet` = @DataPet,
                `peso_pet` = @pesoPet,
                `id_genero` = @genero,
                `qtd_vacinas_pet` = @qtdVacinas,
                `pedigree_pet` = @pedigree
                WHERE `id_pet` = @idPet;";  
        }
    }
}
