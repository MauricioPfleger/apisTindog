using TindogService.Interfaces;

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
    }
}
