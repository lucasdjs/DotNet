namespace Atividades_.NET.Models
{
    public class Musica
    {
        public string Nome { get; set; }
        public DateTime DataLancamento { get; set; }
        public Artistas Artista { get; set; }
        public Album? Album { get; set; }
    }
}
