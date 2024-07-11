namespace TindogService.Controllers.Request
{
    public class EnderecoRequest
    {
        public int? idCidade { get; set; }
        public string? rua { get; set; }
        public int? numero { get; set; }
        public string? bairro { get; set; }
        public long? cep { get; set; }            
        public string? complemento { get; set; }
    }
}
