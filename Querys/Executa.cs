using System.Text;
using TindogService.Controllers.Request;

namespace TindogService.Querys
{
    public class Executa
    {
        public static string CadastrarEndereco(EnderecoRequest enderecoRequest)
        {
            StringBuilder comando = new StringBuilder();
            comando.Append("INSERT INTO dbtindog.endereco (id_cidade, rua_endereco, bairro_endereco");

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
    }
}
