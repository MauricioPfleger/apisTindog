namespace TindogService.Controllers.Request
{
    public class PetRequest
    {
        public string? Nome { get; set; }
        public int? raca { get; set;}
        public DateTime? DtNascimento { get; set; }
        public double? Peso { get; set; }
        public int? Genero { get; set; }
        public int? QtdVacinas{ get; set; }
        public bool Pedigree { get; set; }
    }
}
