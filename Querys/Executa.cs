namespace TindogService.Querys
{
    public class Executa
    {
        public static string CadastrarEndereco()
        {
            return @"INSERT INTO dbtindog.endereco
                        (id_cidade,
                        rua_endereco,
                        numero_endereco,
                        bairro_endereco,
                        cep_endereco,
                        complemento_endereco)
                        VALUES
                        (@id_cidade,
                        @rua_endereco,
                        @numero_endereco,
                        @bairro_endereco,
                        @cep_endereco,
                        @complemento_endereco);
                     SELECT last_insert_id();";
        }
    }
}
