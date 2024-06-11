namespace TindogService.Objetos
{
    public class Pet
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Raca { get; set; }
        public DateTime DataNascimento { get; set; }
        public double Peso { get; set; }
        public string? Genero { get; set; }
        public int QtdVacinas { get; set; }
        public bool Pedigree {  get; set; }

        public Pet()
        {
        }
    }
}
