namespace MyLittlePony.Models;

public class Pony
{
    // Atributos
    public int Numero { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string  Residencia { get; set; }
    public List<string> Tipo { get; set; }
    public string Ocupacao { get; set; }
    public string Imagem { get; set; }
    // Método Construtor
    public Pony()
    {
        Tipo = new List<string>();
    }
}