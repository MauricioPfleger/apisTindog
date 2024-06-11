namespace TindogService.Objetos
{
    public class Cidade
    {
        public int Id { get; set; }
        public Estado? Estado { get; set; }
        public string? Nome { get; set; }

        public Cidade()
        {
            Estado = new Estado();
        }
    }
}
