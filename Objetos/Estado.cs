namespace TindogService.Objetos
{
    public class Estado
    {
        public int Id { get; set; }
        public Pais? Pais { get; set; }
        public string? Nome { get; set; }

        public Estado()
        {
            Pais = new Pais();
        }
    }
}
