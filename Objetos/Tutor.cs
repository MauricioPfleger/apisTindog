namespace TindogService.Objetos
{
    public class Tutor
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public long Telefone { get; set; }
        public string? Genero { get; set; }
        public Endereco? Endereco { get; set; }
        public List<Pet> Pets { get; set; }

        public Tutor()
        {
            Endereco = new Endereco();
            Pets = new List<Pet>();
        }
    }
}
