using System.Text.Json;
using MyLittlePony.Models;
using MyLittlePony.Services;

public class PonyService : IPonyService
{
    private readonly IHttpContextAccessor _session;
    private readonly string ponyFile = @"Data\pony.json";
    private readonly string tiposFile = @"Data\tipos.json";

    public PonyService(IHttpContextAccessor session)
    {
        _session = session;
        PopularSessao();
    }

    public List<Pony> GetPonys()
    {
        PopularSessao();
        var ponys = JsonSerializer.Deserialize<List<Pony>>(_session.HttpContext.Session.GetString("Ponys"));
        return ponys;
    }

    public List<Tipo> GetTipos()
    {
        PopularSessao();
        var tipos = JsonSerializer.Deserialize<List<Tipo>>(_session.HttpContext.Session.GetString("Tipos"));
        return tipos;
    }

    public Pony GetPony(int Numero)
    {
        var pony = GetPonys();
        return pony.Where(p => p.Numero == Numero).FirstOrDefault();
    }

    public PonyDto GetPonyDto()
    {
        var pony = new PonyDto()
        {
            Ponys = GetPonys(),
            Tipos = GetTipos()
        };
        return pony;
    }

    public DetailsDto GetDetailedPony(int Numero)
    {
        var ponys = GetPonys();
        var pony = new DetailsDto()
        {
            Current = ponys.Where(p => p.Numero == Numero).FirstOrDefault(),
            Prior = ponys.OrderByDescending(p => p.Numero).FirstOrDefault(p => p.Numero < Numero),
            Next = ponys.OrderBy(p => p.Numero).FirstOrDefault(p => p.Numero > Numero),
        };
        return pony;
    }

    public Tipo GetTipo(string Nome)
    {
        var tipos = GetTipos();
        return tipos.Where(t => t.Nome == Nome).FirstOrDefault();
    }

    private void PopularSessao()
    {
        if (string.IsNullOrEmpty(_session.HttpContext.Session.GetString("Tipos")))
        {
            _session.HttpContext.Session.SetString("Ponys", LerArquivo(ponyFile));
            _session.HttpContext.Session.SetString("Tipos", LerArquivo(tiposFile));
        }
    }

    private string LerArquivo(string fileName)
    {
        using (StreamReader leitor = new StreamReader(fileName))
        {
            string dados = leitor.ReadToEnd();
            return dados;
        }
    }
}