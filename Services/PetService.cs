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
    }
}
